using MusicPlayerBackend.Contracts;
using System;
using TagLib;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IMetaDataReader"/>.
    /// </summary>
    public class MetaDataReader : IMetaDataReader
    {

        /// <summary>
        /// Acquires neccessary resources to read meta data of files. None at the moment.
        /// </summary>
        public MetaDataReader()
        {

        }

        /// <summary>
        /// Implements the reading the meta data from file, in this case specifically media files. 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Returns an <see cref="AudioMetaData"/> struct with all fileds filled if info was available.</returns>
        public AudioMetaData ReadMetaDataFromFile(string path)
        {
            AudioMetaData audioMetaData = new AudioMetaData();

            TagLib.File tfile = TagLib.File.Create(path);
            audioMetaData.Duration = tfile.Properties.Duration;
            audioMetaData.Title = tfile.Tag.Title;
            audioMetaData.AudioFilePath = path;

            return audioMetaData;
        }
    }
}