using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IContentPresenterController"/>.
    /// </summary>
    public class ContentPresenterController : IContentPresenterController
    {
        IContentPresenter ContentPresenter { get; set; }
        ISongCoverController SongCoverController { get; set; }
        IMediaListController MediaListController { get; set; }
        ISettingsController SettingsController { get; set; }

        /// <summary>
        /// Connects <paramref name="contentPresenter"/>.
        /// </summary>
        /// <param name="contentPresenter"></param>
        /// <param name="mediaListController"></param>
        /// <param name="settingsController"></param>
        /// <param name="songCoverController"></param>
        public ContentPresenterController(IContentPresenter contentPresenter,
            ISongCoverController songCoverController, IMediaListController mediaListController, ISettingsController settingsController)
        {
            ContentPresenter = contentPresenter;
            SongCoverController = songCoverController;
            MediaListController = mediaListController;
        }

    }
}
