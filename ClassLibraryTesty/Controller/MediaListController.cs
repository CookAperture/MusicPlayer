using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IMediaListController"/>.
    /// </summary>
    public class MediaListController : IMediaListController, INotifyError
    {
        IMediaList MediaList { get; set; }
        IMediaListInteractor MediaListInteractor { get; set; }
        ISettingsInteractor SettingsInteractor { get; set; }

        /// <summary>
        /// Connects <paramref name="mediaList"/> with <paramref name="mediaListInteractor"/>.
        /// </summary>
        /// <param name="mediaList">A reference to the media list ui.</param>
        /// <param name="mediaListInteractor">A reference to the media list interactor.</param>
        /// <param name="settingsInteractor"></param>
        public MediaListController(IMediaList mediaList, IMediaListInteractor mediaListInteractor, ISettingsInteractor settingsInteractor)
        {
            MediaList = mediaList;
            MediaListInteractor = mediaListInteractor;
            SettingsInteractor = settingsInteractor;

            MediaListInteractor.onMediaFound += (AudioMetaData found) => InvokeAddSongToList(found);
            MediaList.onLoadMediaList += () => Task.Run(() => SetMediaList());
            MediaList.onLoadMediaListFromNewPath += (string path) => SetMediaListCustomMediaPath(path);
            MediaList.onSelection += (AudioMetaData data) => OnSelection(data);

            onError += (NotificationModel notificationModel) => ((INotifyUI)MediaList).Notify(notificationModel);
        }

        public event Action<NotificationModel> onError;

        private void OnSelection(AudioMetaData data)
        {
        }

        void InvokeAddSongToList(AudioMetaData found)
        {
            MediaList.AddSongToList(found);
        }

        /// <summary>
        /// Sets the found media files to the ui.
        /// </summary>
        public async void SetMediaList()
        {
            try
            {
                await Task.Run(() => {
                    var rootpath = SettingsInteractor.ReadSettings().MediaPath;
                    MediaListInteractor.GetMediaListAsync(rootpath);
                });
            }
            catch (FileReadFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
            }
            catch(ReadAudioMetaDataFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
            }
            catch (EnumerateFilesAbortedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
            }
        }

        /// <summary>
        /// Loads from path media files.
        /// </summary>
        /// <param name="path"></param>
        public async void SetMediaListCustomMediaPath(string path)
        {
            try
            {
                await Task.Run(() => {
                    MediaListInteractor.GetMediaListAsync(path);
                });
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
