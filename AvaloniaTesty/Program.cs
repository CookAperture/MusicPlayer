using System;
using Avalonia.Controls;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    class Program
    {
        public static IMusicPlayerInteractor musicPlayerInteractor;
        public static IMainUI mainUI;
        public static IMainController mainController;
        public static void Main(string[] args)
        {
                AvaloniaInit.Init(args, AvaloniaInit_onReady);
        }

        private static MainWindow AvaloniaInit_onReady()
        {
            musicPlayerInteractor = new MusicPlayerInteractor();
            mainUI = new MainWindow();
            mainController = new MainController(ref musicPlayerInteractor, ref mainUI);
            return (MainWindow)mainUI;
        }
    }
}
