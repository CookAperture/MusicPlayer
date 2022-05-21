using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System;
using System.Diagnostics;
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
            Debug.Assert(path != null);

            AudioMetaData audioMetaData = new AudioMetaData();

            try
            {
                TagLib.File tfile = TagLib.File.Create(path);
                audioMetaData.Duration = tfile.Properties.Duration;
                audioMetaData.Title = tfile.Tag.Title;
                audioMetaData.AudioFilePath = path;
                return audioMetaData;
            }
            catch (CorruptFileException)
            {
                throw new ReadAudioMetaDataFailedException(string.Format("Failed to read meta data from file {0}", path));
            }
            catch (UnsupportedFormatException)
            {
                throw new ReadAudioMetaDataFailedException(string.Format("Failed to read meta data from file {0}", path));
            }
        }

        /// <summary>
        /// Reads image from audio file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ImageContainer ReadImageFromAudioFile(string path)
        {
            Debug.Assert(path != null);

            try
            {
                TagLib.File tfile = TagLib.File.Create(path);
                var img = tfile.Tag.Pictures;
                ImageContainer imageContainer = new ImageContainer()
                {
                    FilePath = path,
                    ImageStream = img.Length > 0 ? new MemoryStream(img[0].Data.Data) : null,
                };
                return imageContainer;
            }
            catch (CorruptFileException)
            {
                throw new ReadAudioMetaDataFailedException(string.Format("Failed to read meta data from file {0}", path));
            }
            catch (UnsupportedFormatException)
            {
                throw new ReadAudioMetaDataFailedException(string.Format("Failed to read meta data from file {0}", path));
            }
        }
    }
}