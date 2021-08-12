using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    static class Program
    {
        public static IMusicPlayerInteractor musicPlayerInteractor;
        public static IMainUI mainUI;
        public static ICustomDecoration customDecoration;
        public static ISongCover songCover;
        public static ISoundControlBar soundControlBar;
        public static IMainController mainController;
        public static void Main(string[] args)
        {
            MusicPlayerApp.Init(args, MusicPlayerAppInit);
        }

        private static MainUI MusicPlayerAppInit()
        {
            //init controller here
            musicPlayerInteractor = new MusicPlayerInteractor();
            customDecoration = new CustomDecoration();
            songCover = new SongCover();
            soundControlBar = new SoundControlBar();
            mainUI = new MainUI();
            ((MainUI)mainUI).CustomDecoration = customDecoration;
            ((MainUI)mainUI).SoundControlBar = soundControlBar;
            ((MainUI)mainUI).SongCover = ((SongCover)songCover);
            mainController = new MainController(ref musicPlayerInteractor, ref mainUI, ref customDecoration, ref songCover, ref soundControlBar);
            return (MainUI)mainUI;
        }
    }
}