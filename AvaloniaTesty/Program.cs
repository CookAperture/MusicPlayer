using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    static class Program
    {

        public static IApplication app;
        public static IMainUI mainUI;
        public static IMainController MainController { get; set; }
        public static ISoundControlBarController SoundControlBarController { get; set; }
        public static ICustomDecorationController CustomDecorationController { get; set; }
        public static IContentPresenterController ContentPresenterController { get; set; }
        public static ISettingsController SettingsController { get; set; }
        public static ISongCoverController SongCoverController { get; set; }
        public static void Main(string[] args)
        {
            MusicPlayerApp.Init(args, MusicPlayerAppInit);
        }

        private static MainUI MusicPlayerAppInit()
        {
            //init controller here
            mainUI = new MainUI();
            SoundControlBarController = new SoundControlBarController(mainUI.SoundControlBar);
            CustomDecorationController = new CustomDecorationController(mainUI.CustomDecoration);
            ContentPresenterController = new ContentPresenterController(mainUI.ContentPresenter);
            SettingsController = new SettingsController(mainUI.ContentPresenter.Settings);
            SongCoverController = new SongCoverController(mainUI.ContentPresenter.SongCover);
            MainController = new MainController(ref mainUI, ref app);

            SettingsController.onChangeTheme += (APPLICATION_STYLE appStyle) => MainController.ChangeTheme(appStyle);

            return (MainUI)mainUI;
        }
    }
}