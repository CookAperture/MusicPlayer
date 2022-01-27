using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IMediaListController"/>.
    /// </summary>
    public class MediaListController : IMediaListController
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

            MediaListInteractor.onMediaFound += (AudioMetaData found) => { InvokeAddSongToList(found); };
            MediaList.onLoadMediaList += () => { SetMediaList(); };
            MediaList.onLoadMediaListFromNewPath += (string path) => { SetMediaListCustomMediaPath(path); };
            MediaList.onSelection += (AudioMetaData data) => { }; //TODO
        }

        void InvokeAddSongToList(AudioMetaData found)
        {
            MediaList.AddSongToList(found);
        }

        /// <summary>
        /// Sets the found media files to the ui.
        /// </summary>
        public void SetMediaList()
        {
            var rootpath = SettingsInteractor.ReadSettings().MediaPath;
            MediaListInteractor.GetMediaListAsync(rootpath);
        }

        /// <summary>
        /// Loads from path media files.
        /// </summary>
        /// <param name="path"></param>
        public void SetMediaListCustomMediaPath(string path)
        {
            MediaListInteractor.GetMediaListAsync(path);
        }
    }
}
