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

            MediaList.onSelection += (AudioMetaData sel) => { InvokeAudioSelection(sel); };
            MediaListInteractor.onMediaFound += (AudioMetaData found) => { InvokeAddSongToList(found); };
        }

        List<AudioMetaData> AudioMetaDatas { get; set; } = new List<AudioMetaData> { };

        void InvokeAudioSelection(AudioMetaData sel)
        {
           var f = AudioMetaDatas.Find(pred => pred.Title == sel.Title && pred.Duration == sel.Duration);
            onAudioSelected.Invoke(f);
        }

        void InvokeAddSongToList(AudioMetaData found)
        {
            AudioMetaDatas.Add(found);
            MediaList.AddSongToList(found);
        }

        /// <summary>
        /// Sets the found media files to the ui.
        /// </summary>
        /// <param name="rootpath"></param>
        public void SetMediaList(string rootpath)
        {
            MediaListInteractor.GetMediaListAsync(rootpath);
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
