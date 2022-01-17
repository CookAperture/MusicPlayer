using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISettingsInteractor"/>.
    /// </summary>
    public class SettingsInteractor : ISettingsInteractor
    {
        IDataConverter DataConverter { get; set; }
        IJSONDeserializer JSONDeserializer { get; set; }
        IJSONSerializer JSONSerializer { get; set; }
        IFileReader FileReader { get; set; }
        IFileWriter FileWriter { get; set; }

        /// <summary>
        /// Connects <paramref name="dataConverter"/>, <paramref name="fileReader"/>, <paramref name="fileWriter"/>
        /// <paramref name="jsonDeserializer"/> and <paramref name="jsonSerializer"/> with each other.
        /// </summary>
        /// <param name="dataConverter"></param>
        /// <param name="jsonDeserializer"></param>
        /// <param name="jsonSerializer"></param>
        /// <param name="fileReader"></param>
        /// <param name="fileWriter"></param>
        public SettingsInteractor(IDataConverter dataConverter, IJSONDeserializer jsonDeserializer, IJSONSerializer jsonSerializer, IFileReader fileReader, IFileWriter fileWriter)
        {
            DataConverter = dataConverter;
            JSONDeserializer = jsonDeserializer;
            JSONSerializer = jsonSerializer;
            FileReader = fileReader;
            FileWriter = fileWriter;
        }

        /// <summary>
        /// Serializes and writes away the <paramref name="appSettings"/>.
        /// </summary>
        /// <param name="appSettings"></param>
        public void WriteSettings(AppSettings appSettings)
        {
            var serialized = JSONSerializer.Serialize(appSettings);
            FileWriter.Write(serialized, Globals.SettingsPath);
        }

        /// <summary>
        /// Reads settings and deserializes them.
        /// </summary>
        /// <returns><see cref="AppSettings"/> read from settings file.</returns>
        public AppSettings ReadSettings()
        {
            var read = FileReader.ReadWhole(Globals.SettingsPath);
            return JSONDeserializer.Deserialize<AppSettings>(read);
        }
    }
}