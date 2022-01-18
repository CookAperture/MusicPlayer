using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISongCoverController"/>.
    /// </summary>
    public class SongCoverController : ISongCoverController
    {
        ISongCover SongCover { get; set; }
        IAudioFileInteractor AudioFileInteractor { get; set; }

        /// <summary>
        /// Connects <paramref name="audioFileInteractor"/> with <paramref name="songCover"/>.
        /// </summary>
        /// <param name="songCover">A reference to the song cover ui.</param>
        /// <param name="audioFileInteractor">A reference to the audio file interactor.</param>
        public SongCoverController(ISongCover songCover, IAudioFileInteractor audioFileInteractor)
        {
            SongCover = songCover;
            AudioFileInteractor = audioFileInteractor;
        }

        /// <summary>
        /// Loads the cover image from the actual audio file.
        /// </summary>
        public void SetCover(/*Image*/)
        {
            SongCover.LoadCover(/*Image*/);
        }
    }
}
