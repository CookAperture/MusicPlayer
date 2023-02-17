using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts to connect <see cref="IFileReader"/>, <see cref="IFileWriter"/>, 
/// <see cref="IJSONSerializer"/>, <see cref="IJSONDeserializer"/> and <see cref="IDataConverter"/> with each other.
/// </summary>
public interface ISettingsInteractor
{

    /// <summary>
    /// Contracts to write <paramref name="appSettings"/> to the settings file.
    /// </summary>
    /// <param name="appSettings"></param>
    public void WriteSettings(AppSettings appSettings);

    /// <summary>
    /// Contracts to read app settings from the settings file.
    /// </summary>
    /// <returns><see cref="AppSettings"/> saved in settings file.</returns>
    public AppSettings ReadSettings();

    /// <summary>
    /// Contracts to fetch audio devices.
    /// </summary>
    /// <returns></returns>
    public List<string> GetAudioDevices();

    /// <summary>
    /// Contracts to set the audio output device to the sound engine.
    /// </summary>
    /// <param name="audiodevice"></param>
    public void SetAudioDevice(string audiodevice);
}