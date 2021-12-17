using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class SongCoverController : ISongCoverController
    {
        ISongCover songCover;
        public SongCoverController(ISongCover songCover)
        {
            this.songCover = songCover;
        }
    }
}
