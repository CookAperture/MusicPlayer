using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    public class MainController : IMainController
    {
        IMainUI MainUI { get; set; }
        IApplication Application { get; set; }

        public MainController(ref IMainUI mainUI, ref IApplication app)
        {
            MainUI = mainUI;
            Application = app;

            Application.SetStyle(APPLICATION_STYLE.DARK);
        }

        public void ChangeTheme(APPLICATION_STYLE appStyle)
        {
            Application.SetStyle(appStyle);
        }
    }
}
