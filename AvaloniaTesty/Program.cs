using Avalonia;
using Avalonia.Dialogs;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Runtime;

namespace MusicPlayer
{
    static class Program
    {
        public static AppBuilder BuildAvaloniaApp() => 
            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseSkia()
                .UseManagedSystemDialogs()
                .With(new X11PlatformOptions() { UseDeferredRendering = false })
                .With(new MacOSPlatformOptions() { ShowInDock = true })
                .With(new Win32PlatformOptions() { 
                    AllowEglInitialization = true, 
                    UseDeferredRendering = false, 
                    UseWindowsUIComposition = true, 
                    UseWgl = false,
                    OverlayPopups = true
                })
                .With(new AvaloniaNativePlatformOptions() { OverlayPopups = true, UseDeferredRendering = false, UseGpu = true})
                .LogToTrace();

        public static IApplication App { get; set; }
        public static IMainUI MainUI { get; set; }
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
        public static ISongCoverInteractor SongCoverInteractor { get; set; }
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
            System.Reactive.PlatformServices.EnlightenmentProvider.EnsureLoaded();

            //init controller here
            MainUI = new MainUI();
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
            SongCoverInteractor = new SongCoverInteractor(MetaDataReader);
            SoundControlBarController = new SoundControlBarController(MainUI.SoundControlBar, AudioFileInteractor);
            CustomDecorationController = new CustomDecorationController(MainUI.CustomDecoration);
            SettingsController = new SettingsController(MainUI.ContentPresenter.Settings, SettingsInteractor, App);
            SongCoverController = new SongCoverController(MainUI.ContentPresenter.SongCover, SongCoverInteractor);
            MediaListController = new MediaListController(MainUI.ContentPresenter.MediaList, MediaListInteractor, SettingsInteractor);
            ContentPresenterController = new ContentPresenterController(MainUI.ContentPresenter, SongCoverController, MediaListController, SettingsController);
            MainController = new MainController(MainUI, App, SettingsInteractor);

            return (MainUI)MainUI;
        }
    }
}