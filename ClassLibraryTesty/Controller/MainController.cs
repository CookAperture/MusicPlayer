using System;
using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class MainController : IMainController
    {
        IMusicPlayerInteractor musicPlayerInteractor;
        IMainUI mainUI;
        ICustomDecoration customDecoration;
        ISongCover songCover;
        ISoundControlBar soundControlBar;
        public MainController(ref IMusicPlayerInteractor musicPlayerInteractor, ref IMainUI mainUI, ref ICustomDecoration customDecoration, ref ISongCover songCover, ref ISoundControlBar soundControlBar)
        {
            this.musicPlayerInteractor = musicPlayerInteractor;
            this.mainUI = mainUI;
            this.customDecoration = customDecoration;
            this.songCover = songCover;
            this.soundControlBar = soundControlBar;

            this.mainUI.onAddSong += (string path) => { this.musicPlayerInteractor.AddSong(path); };
            this.mainUI.onPlay += () => { this.musicPlayerInteractor.PlaySong(); };

            this.musicPlayerInteractor.onSongAdded += (SongMetaData meta) => { this.mainUI.OnSongAdded(meta); };
        }
    }
}
