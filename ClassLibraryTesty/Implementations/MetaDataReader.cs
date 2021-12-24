using MusicPlayerBackend.Contracts;
using System;
using TagLib;

namespace MusicPlayerBackend
{
    public class MetaDataReader : IMetaDataReader
    {
        public MetaDataReader()
        {

        }

        public AudioMetaData ReadMetaDataFromFile(string path)
        {
            throw new NotImplementedException();
        }

        //public void ReadTest()
        //{
        //    File tfile = File.Create("G:\\NewMusic\\AWOLNATION - Here Come the Runts.mp3");
        //    TimeSpan duration = tfile.Properties.Duration;
        //}
    }
}