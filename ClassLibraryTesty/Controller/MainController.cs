using System;
using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class MainController : IMainController
    {
        IMusicPlayerInteractor musicPlayerInteractor;
        IMainUI mainUI;
        public MainController(ref IMusicPlayerInteractor musicPlayerInteractor, ref IMainUI mainUI)
        {
            this.musicPlayerInteractor = musicPlayerInteractor;
            this.mainUI = mainUI;

            this.mainUI.onAddSong += (string path) => { this.musicPlayerInteractor.AddSong(path); };
            this.mainUI.onPlay += () => { this.musicPlayerInteractor.PlaySong(); };
            this.musicPlayerInteractor.onSongAdded += (SongMetaData meta) => { this.mainUI.OnSongAdded(meta); };
        }
    }
}
