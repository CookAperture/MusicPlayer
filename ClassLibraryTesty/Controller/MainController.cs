using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IMainController"/>.
    /// </summary>
    public class MainController : IMainController
    {
        IMainUI MainUI { get; set; }
        IApplication Application { get; set; }

        /// <summary>
        /// Connects the <paramref name="mainUI"/> with the <paramref name="app"/>.
        /// </summary>
        /// <param name="mainUI"></param>
        /// <param name="app"></param>
        public MainController(ref IMainUI mainUI, ref IApplication app)
        {
            MainUI = mainUI;
            Application = app;

            Application.SetStyle(APPLICATION_STYLE.DARK);
        }

        /// <summary>
        /// Sets the theme of the app.
        /// </summary>
        /// <param name="appStyle"></param>
        public void ChangeTheme(APPLICATION_STYLE appStyle)
        {
            Application.SetStyle(appStyle);
        }
    }
}
