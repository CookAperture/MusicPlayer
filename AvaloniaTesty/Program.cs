using Avalonia;
using Avalonia.ReactiveUI;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Runtime;

namespace MusicPlayer
{
    static class Program
    {
        public static AppBuilder BuildAvaloniaApp() => 
            AppBuilder.Configure<App>().UsePlatformDetect()
                .UseSkia()
                .UseReactiveUI()
                .With(new X11PlatformOptions() { UseDeferredRendering = true })
                .With(new MacOSPlatformOptions() { ShowInDock = true })
                .With(new Win32PlatformOptions() { AllowEglInitialization = true, UseDeferredRendering = true, UseWindowsUIComposition = true, UseWgl = true })
                .LogToTrace();

        public static IApplication app;
        public static IMainUI mainUI;
        public static IMainController MainController { get; set; }
        public static ISoundControlBarController SoundControlBarController { get; set; }
        public static ICustomDecorationController CustomDecorationController { get; set; }
        public static IContentPresenterController ContentPresenterController { get; set; }
        public static IMediaListController MediaListController { get; set; }
        public static ISettingsController SettingsController { get; set; }
        public static ISongCoverController SongCoverController { get; set; }
        public static IAudioFileInteractor AudioFileInteractor { get; set; }
        public static ISettingsInteractor SettingsInteractor { get; set; }
        public static IMediaListInteractor MediaListInteractor { get; set; }
        public static IDataConverter DataConverter { get; set; }
        public static IFileReader FileReader { get; set; }
        public static IFileWriter FileWriter { get; set; }
        public static IJSONSerializer JSONSerializer { get; set; }
        public static IJSONDeserializer JSONDeserializer { get; set; }
        public static IMetaDataReader MetaDataReader { get; set; }
        public static ISoundEngine SoundEngine { get; set; }
        public static IFileSystemHandler FileSystemHandler { get; set; }

        public static void Main(string[] args)
        {
            MusicPlayerApp.Init(args, MusicPlayerAppInit);
        }

        private static MainUI MusicPlayerAppInit()
        {
            //init controller here
            mainUI = new MainUI();
            DataConverter = new DataConverter();
            FileReader = new FileReader();
            FileWriter = new FileWriter();
            JSONSerializer = new JSONSerializer();
            JSONDeserializer = new JSONDeserializer();
            MetaDataReader = new MetaDataReader();
            SoundEngine = new SoundEngine();
            FileSystemHandler = new FileSystemHandler();
            AudioFileInteractor = new AudioFileInteractor(SoundEngine, DataConverter, MetaDataReader);
            SettingsInteractor = new SettingsInteractor(DataConverter, JSONDeserializer, JSONSerializer, FileReader, FileWriter, SoundEngine);
            MediaListInteractor = new MediaListInteractor(FileSystemHandler, MetaDataReader);
            SoundControlBarController = new SoundControlBarController(mainUI.SoundControlBar, AudioFileInteractor);
            CustomDecorationController = new CustomDecorationController(mainUI.CustomDecoration);
            ContentPresenterController = new ContentPresenterController(mainUI.ContentPresenter);
            SettingsController = new SettingsController(mainUI.ContentPresenter.Settings, SettingsInteractor);
            SongCoverController = new SongCoverController(mainUI.ContentPresenter.SongCover, AudioFileInteractor);
            MediaListController = new MediaListController(mainUI.ContentPresenter.MediaList, MediaListInteractor);
            MainController = new MainController(ref mainUI, ref app);

            //connect controller here
            SettingsController.onChangeTheme += (APPLICATION_STYLE appStyle) => MainController.ChangeTheme(appStyle);
            SettingsController.onSettingsLoaded += (AppSettings appSetting) => { MediaListController.SetMediaList(appSetting.MediaPath); }; //clear the list or diff from cache
            SettingsController.onRequestCurrentThemeSet += () => { SettingsController.SetCurrentTheme(app.GetCurrentApplicationStyle()); };

            CustomDecorationController.onSwitchedToSettings += () => { SettingsController.LoadSettings(); };
            CustomDecorationController.onSwitchedToCover += () => { SongCoverController.SetCover(); };
            CustomDecorationController.onSwitchedToMediaList += () => { MediaListController.SetMediaList(SettingsController.GetSettings().MediaPath); }; //remember if was loaded -> cache in file

            MediaListController.onAudioSelected += (AudioMetaData selected) => { SoundControlBarController.UpdateInformation(selected); };

            return (MainUI)mainUI;
        }
    }
}