using Avalonia;
using Avalonia.Controls;
using MusicPlayerBackend.Contracts;

namespace MusicPlayer
{
    public static class MusicPlayerApp
    {
        // Avalonia configuration, don't remove; also used by visual designer.
        public static void Init(string[] args, OnReady onReadyDelegate)
        {
            // Initialization code. Don't use any Avalonia, third-party APIs or any
            // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
            // yet and stuff might break.
            onReady += onReadyDelegate;
            AppBuilder = Program.BuildAvaloniaApp();
            AppBuilder.Start(AppMain, args);
        }

        static void AppMain(Application app, string[] args)
        {
            // Do you startup code here
            Application = app;
            Program.app = (IApplication)app;
            MainUI = onReady?.Invoke();
            MainUI.Show();

            app.Run(MainUI);
        }

        public static Window MainUI { get; set; }
        public static AppBuilder AppBuilder { get; set; }
        public static Application Application { get; set; }

        public delegate Window OnReady();
        public static event OnReady onReady;
    }
}