using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IAudioFileInteractor"/>
    /// </summary>
    public class SongCoverInteractor : ISongCoverInteractor
    {
        IMetaDataReader MetaDataReader { get; set; }

        /// <summary>
        /// Connects to <see cref="IMetaDataReader"/>.
        /// </summary>
        /// <param name="metaDataReader"></param>
        public SongCoverInteractor(IMetaDataReader metaDataReader)
        {
            Logger.Log(LogSeverity.Debug, this, "Initialized!");

            MetaDataReader = metaDataReader;
        }

        /// <summary>
        /// Reads image from meta data.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ImageContainer GetCoverFromAudio(string path)
        {
            Logger.Log(LogSeverity.Informative, this, "Get Cover from " + path);
            return MetaDataReader.ReadImageFromAudioFile(path);
        }
    }
}