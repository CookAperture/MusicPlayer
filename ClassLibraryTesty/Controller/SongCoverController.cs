using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    public class SongCoverController : ISongCoverController
    {
        ISongCover SongCover { get; set; }
        IAudioFileInteractor AudioFileInteractor { get; set; }
        public SongCoverController(ISongCover songCover, IAudioFileInteractor audioFileInteractor)
        {
            SongCover = songCover;
            AudioFileInteractor = audioFileInteractor;
        }

        public void SetCover(/*Image*/)
        {
            SongCover.LoadCover(/*Image*/);
        }
    }
}
