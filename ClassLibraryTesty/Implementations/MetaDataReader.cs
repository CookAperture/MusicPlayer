using ClassLibraryTesty.Contracts;
using System;
using TagLib;

namespace ClassLibraryTesty
{
    public class TagReader : ITagReader
    {
        public TagReader()
        {

        }

        public void ReadMetaData(string path)
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