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
                .UsePlatformDetect()
                .UseSkia()
                .UseReactiveUI()
                .With(new X11PlatformOptions() { UseDeferredRendering = true })
                .With(new MacOSPlatformOptions() { ShowInDock = true })
                .With(new Win32PlatformOptions() { AllowEglInitialization = true, UseDeferredRendering = true })
                .LogToTrace();

        public static IApplication app;
        public static IMainUI mainUI;
        public static IMainController MainController { get; set; }
        public static ISoundControlBarController SoundControlBarController { get; set; }
        public static ICustomDecorationController CustomDecorationController { get; set; }
        public static IContentPresenterController ContentPresenterController { get; set; }
        public static ISettingsController SettingsController { get; set; }
        public static ISongCoverController SongCoverController { get; set; }
        public static IAudioFileInteractor AudioFileInteractor { get; set; }
        public static ISettingsInteractor SettingsInteractor { get; set; }
        public static IDataConverter DataConverter { get; set; }
        public static IFileReader FileReader { get; set; }
        public static IFileWriter FileWriter { get; set; }
        public static IJSONSerializer JSONSerializer { get; set; }
        public static IJSONDeserializer JSONDeserializer { get; set; }
        public static IMetaDataReader MetaDataReader { get; set; }
        public static ISoundEngine SoundEngine { get; set; }

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
            AudioFileInteractor = new AudioFileInteractor(SoundEngine, DataConverter, MetaDataReader);
            SettingsInteractor = new SettingsInteractor(DataConverter, JSONDeserializer, JSONSerializer, FileReader, FileWriter);
            SoundControlBarController = new SoundControlBarController(mainUI.SoundControlBar, AudioFileInteractor);
            CustomDecorationController = new CustomDecorationController(mainUI.CustomDecoration);
            ContentPresenterController = new ContentPresenterController(mainUI.ContentPresenter);
            SettingsController = new SettingsController(mainUI.ContentPresenter.Settings, SettingsInteractor);
            SongCoverController = new SongCoverController(mainUI.ContentPresenter.SongCover, AudioFileInteractor);
            MainController = new MainController(ref mainUI, ref app);

            SettingsController.onChangeTheme += (APPLICATION_STYLE appStyle) => MainController.ChangeTheme(appStyle);

            return (MainUI)mainUI;
        }
    }
}