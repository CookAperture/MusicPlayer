using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    static class Program
    {
        public static IMainUI mainUI;
        public static IMainController mainController;
        public static void Main(string[] args)
        {
            MusicPlayerApp.Init(args, MusicPlayerAppInit);
        }

        private static MainUI MusicPlayerAppInit()
        {
            //init controller here
            mainUI = new MainUI();
            mainController = new MainController(ref mainUI);
            return (MainUI)mainUI;
        }
    }
}