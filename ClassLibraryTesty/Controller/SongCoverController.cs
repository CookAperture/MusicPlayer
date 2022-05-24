using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISongCoverController"/>.
    /// </summary>
    public class SongCoverController : ISongCoverController, INotifyError
    {
        ISongCover SongCover { get; set; }
        ISongCoverInteractor SongCoverInteractor { get; set; }

        /// <summary>
        /// Connects <paramref name="songCoverInteractor"/> with <paramref name="songCover"/>.
        /// </summary>
        /// <param name="songCover">A reference to the song cover ui.</param>
        /// <param name="songCoverInteractor">A reference to the audio file interactor.</param>
        public SongCoverController(ISongCover songCover, ISongCoverInteractor songCoverInteractor)
        {
            SongCover = songCover;
            SongCoverInteractor = songCoverInteractor;

            SongCover.onLoad += (AudioMetaData data) => SetCover(data);

            ((INotifyError)SongCoverInteractor).onError += (NotificationModel notificationModel) => ((INotifyUI)SongCover).Notify(notificationModel);

            onError += (NotificationModel notificationModel) => ((INotifyUI)SongCover).Notify(notificationModel);
        }

        public event Action<NotificationModel> onError;

        /// <summary>
        /// Loads the cover image from the actual audio file.
        /// </summary>
        public void SetCover(AudioMetaData data)
        {
            ImageContainer imageContainer = SongCoverInteractor.GetCoverFromAudio(data.AudioFilePath);
            SongCover.LoadCover(imageContainer);
        }
    }
}
