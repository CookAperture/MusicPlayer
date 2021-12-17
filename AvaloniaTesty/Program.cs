using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    static class Program
    {
        public static IMainUI mainUI;
        public static IMainController mainController;
        public static ISoundControlBarController soundControlBarController;
        public static ICustomDecorationController customDecorationController;
        public static IContentPresenterController contentPresenterController;
        public static ISettingsController settingsController;
        public static ISongCoverController songCoverController;
        public static void Main(string[] args)
        {
            MusicPlayerApp.Init(args, MusicPlayerAppInit);
        }

        private static MainUI MusicPlayerAppInit()
        {
            //init controller here
            mainUI = new MainUI();
            mainController = new MainController(ref mainUI);
            soundControlBarController = new SoundControlBarController(mainUI.SoundControlBar);
            customDecorationController = new CustomDecorationController(mainUI.CustomDecoration);
            contentPresenterController = new ContentPresenterController(mainUI.ContentPresenter);
            settingsController = new SettingsController(mainUI.ContentPresenter.Settings);
            songCoverController = new SongCoverController(mainUI.ContentPresenter.SongCover);
            return (MainUI)mainUI;
        }
    }
}