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

        /// <summary>
        /// Routes the selection from the ui.
        /// </summary>
        public event IMediaListController.OnAudioSelected onAudioSelected;

        /// <summary>
        /// Connects <paramref name="mediaList"/> with <paramref name="mediaListInteractor"/>.
        /// </summary>
        /// <param name="mediaList">A reference to the media list ui.</param>
        /// <param name="mediaListInteractor">A reference to the media list interactor.</param>
        public MediaListController(IMediaList mediaList, IMediaListInteractor mediaListInteractor)
        {
            MediaList = mediaList;
            MediaListInteractor = mediaListInteractor;

            MediaList.onSelection += (AudioMetaData sel) => { onAudioSelected.Invoke(sel); };
        }

        /// <summary>
        /// Sets the found media files to the ui.
        /// </summary>
        /// <param name="rootpath"></param>
        public void SetMediaList(string rootpath)
        {
            var files = MediaListInteractor.GetMediaList(rootpath);
            MediaList.SetList(files);
        }

        /// <summary>
        /// Sets the currently playing song.
        /// </summary>
        /// <param name="audioMetaData"></param>
        public void SetPlaying(AudioMetaData audioMetaData)
        {
            MediaList.SetPlaying(audioMetaData);
        }
    }
}
