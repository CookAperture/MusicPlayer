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
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            IMainController mainController = new MainController(() => AvaloniaInit.Init(args));

        }
    }
}
