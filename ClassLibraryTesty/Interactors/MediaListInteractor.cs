using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IMediaListInteractor"/>
    /// </summary>
    public class MediaListInteractor : IMediaListInteractor
    {
        IFileSystemHandler FileSystemHandler { get; set; }
        IMetaDataReader MetaDataReader { get; set; }
        ISoundEngine SoundEngine { get; set; }

        /// <summary>
        /// Gets called when media file gets found in the async call.
        /// </summary>
        public event IMediaListInteractor.OnMediaFound onMediaFound;

        /// <summary>
        /// Connects <paramref name="fileSystemHandler"/> with <paramref name="metaDataReader"/>.
        /// </summary>
        /// <param name="fileSystemHandler"></param>
        /// <param name="metaDataReader"></param>
        public MediaListInteractor(IFileSystemHandler fileSystemHandler, IMetaDataReader metaDataReader)
        {
            FileSystemHandler = fileSystemHandler;
            MetaDataReader = metaDataReader;

            FileSystemHandler.onMediaFound += (string path) => { onMediaFound.Invoke(MetaDataReader.ReadMetaDataFromFile(path)); };

            Logger.Log(LogSeverity.Debug, this, "Initialized!");
        }

        /// <summary>
        /// Fetches all audio filepaths and fetches the meta data from them.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns>List of <see cref="AudioMetaData"/> of all found filepaths.</returns>
        public void GetMediaListAsync(string rootPath)
        {
            FileSystemHandler.FindAudioFilesFromRootPathAsync(rootPath, Globals.ValidAudioFileEndings);

            Logger.Log(LogSeverity.Debug, this, "Get media list async from " + rootPath);
        }
    }
}