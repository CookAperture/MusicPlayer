using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IMediaListInteractor"/>
    /// </summary>
    public class MediaListInteractor : IMediaListInteractor, INotifyError
    {
        IFileSystemHandler FileSystemHandler { get; set; }
        IMetaDataReader MetaDataReader { get; set; }
        ISoundEngine SoundEngine { get; set; }

        /// <summary>
        /// Connects <paramref name="fileSystemHandler"/> with <paramref name="metaDataReader"/>.
        /// </summary>
        /// <param name="fileSystemHandler"></param>
        /// <param name="metaDataReader"></param>
        public MediaListInteractor(IFileSystemHandler fileSystemHandler, IMetaDataReader metaDataReader)
        {
            FileSystemHandler = fileSystemHandler;
            MetaDataReader = metaDataReader;

            FileSystemHandler.onMediaFound += (string path) => { 
                MetaDataReader.ReadMetaDataFromFile(path, onMediaFound,
                    (string msg) => onError.Invoke(new NotificationModel() { Title = "Error", Message = msg, Level = NotificationModel.NotificationLevel.Error }));
            };
        }

        public event Action<AudioMetaData> onMediaFound;
        public event Action<NotificationModel> onError;

        /// <summary>
        /// Fetches all audio filepaths and fetches the meta data from them.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns>List of <see cref="AudioMetaData"/> of all found filepaths.</returns>
        public void GetMediaListAsync(string rootPath)
        {
            try
            {
                FileSystemHandler.FindAudioFilesFromRootPathAsync(rootPath, Globals.ValidAudioFileEndings);
            }
            catch (FileReadFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
            }
            catch (ReadAudioMetaDataFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
            }
            catch (EnumerateFilesAbortedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
            }
        }
    }
}