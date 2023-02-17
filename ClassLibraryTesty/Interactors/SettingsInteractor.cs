using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

namespace MusicPlayerBackend.Interactors;
/// <summary>
/// Implements <see cref="ISettingsInteractor"/>.
/// </summary>
public class SettingsInteractor : ISettingsInteractor, INotifyError
{
    IDataConverter DataConverter { get; set; }
    IJSONDeserializer JSONDeserializer { get; set; }
    IJSONSerializer JSONSerializer { get; set; }
    IFileReader FileReader { get; set; }
    IFileWriter FileWriter { get; set; }
    ISoundEngine SoundEngine { get; set; }

    /// <summary>
    /// Connects <paramref name="dataConverter"/>, <paramref name="fileReader"/>, <paramref name="fileWriter"/>
    /// <paramref name="jsonDeserializer"/> and <paramref name="jsonSerializer"/> with each other.
    /// </summary>
    /// <param name="dataConverter"></param>
    /// <param name="jsonDeserializer"></param>
    /// <param name="jsonSerializer"></param>
    /// <param name="fileReader"></param>
    /// <param name="fileWriter"></param>
    /// <param name="soundEngine"></param>
    public SettingsInteractor(IDataConverter dataConverter, IJSONDeserializer jsonDeserializer, IJSONSerializer jsonSerializer, IFileReader fileReader, IFileWriter fileWriter, ISoundEngine soundEngine)
    {
        DataConverter = dataConverter;
        JSONDeserializer = jsonDeserializer;
        JSONSerializer = jsonSerializer;
        FileReader = fileReader;
        FileWriter = fileWriter;
        SoundEngine = soundEngine;
    }

    /// <summary>
    /// Fires on Error.
    /// </summary>
    public event Action<NotificationModel> onError;

    /// <summary>
    /// Serializes and writes away the <paramref name="appSettings"/>.
    /// </summary>
    /// <param name="appSettings"></param>
    public void WriteSettings(AppSettings appSettings)
    {
        var serialized = JSONSerializer.Serialize(appSettings);
        try
        {
            FileWriter.Write(serialized, Globals.SettingsPath);
        }
        catch (FileWriteFailedException ex)
        {
            onError.Invoke(new NotificationModel { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
        }
    }

    /// <summary>
    /// Reads settings and deserializes them.
    /// </summary>
    /// <returns><see cref="AppSettings"/> read from settings file.</returns>
    public AppSettings ReadSettings()
    {

        var read = "";
            
        try
        {
            read = FileReader.ReadWhole(Globals.SettingsPath);
        }
        catch (FileReadFailedException ex)
        {
            onError.Invoke(new NotificationModel { Message = ex.Message, Level = NotificationModel.NotificationLevel.Warning, Title = "Error" });
        }
        var settings = JSONDeserializer.Deserialize<AppSettings>(read);
        return settings;
    }

    /// <summary>
    /// Fetches the audio devices from sound engine.
    /// </summary>
    /// <returns>List of audio devices.</returns>
    public List<string> GetAudioDevices()
    {
        return SoundEngine.GetAudioDevices();
    }

    /// <summary>
    /// Sets the audio device.
    /// </summary>
    /// <param name="audiodevice"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void SetAudioDevice(string audiodevice)
    {
        SoundEngine.SetAudioDevice(audiodevice);
    }
}