using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{
    public class SettingsInteractor : ISettingsInteractor
    {
        IDataConverter DataConverter { get; set; }
        IJSONDeserializer JSONDeserializer { get; set; }
        IJSONSerializer JSONSerializer { get; set; }
        IFileReader FileReader { get; set; }
        IFileWriter FileWriter { get; set; }

        public SettingsInteractor(IDataConverter dataConverter, IJSONDeserializer jsonDeserializer, IJSONSerializer jsonSerializer, IFileReader fileReader, IFileWriter fileWriter)
        {
            DataConverter = dataConverter;
            JSONDeserializer = jsonDeserializer;
            JSONSerializer = jsonSerializer;
            FileReader = fileReader;
            FileWriter = fileWriter;
        }

        public void WriteSettings(AppSettings appSettings)
        {
            throw new NotImplementedException();
        }

        public AppSettings ReadSettings()
        {
            throw new NotImplementedException();
        }
    }
}