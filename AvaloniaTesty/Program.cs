using System;
using Avalonia;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    class AvaloniaInit
    {
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
        public static void Init(string[] args)
        {
            // Initialization code. Don't use any Avalonia, third-party APIs or any
            // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
            // yet and stuff might break.
            AppBuilder = BuildAvaloniaApp();
            AppBuilder.StartWithClassicDesktopLifetime(args); //fine so far but pls cast a event which init the rest of the app!!!
            //setup without starting
            //AppBuilder = AppBuilder.SetupWithoutStarting();
        }

        public static AppBuilder? AppBuilder { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            AvaloniaInit.Init(args);
            App? app = AvaloniaInit.AppBuilder?.Instance as App;
            IMusicPlayerInteractor musicPlayerInteractor = new MusicPlayerInteractor();
            IMainUI? mainUI = app?.MainUI as MainWindow;
            //IMainUI mainUI = new MainWindow();
            IMainController mainController = new MainController(ref musicPlayerInteractor, ref mainUI);
            try
            {
                //start with app ? and args
                //AvaloniaInit.AppBuilder.Start(mainUI, args);
            }
            catch (NotImplementedException)
            {
                //hit dlg with notification that something hasnt been impl yet;
            }

        }
    }
}
