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
        ISettingsInteractor SettingsInteractor { get; set; }

        /// <summary>
        /// Connects the <paramref name="mainUI"/> with the <paramref name="app"/>.
        /// </summary>
        /// <param name="mainUI"></param>
        /// <param name="app"></param>
        /// <param name="settingsInteractor"></param>
        public MainController(IMainUI mainUI, IApplication app, ISettingsInteractor settingsInteractor)
        {
            MainUI = mainUI;
            Application = app;
            SettingsInteractor = settingsInteractor;

            Application.SetStyle(SettingsInteractor.ReadSettings().AppStyle);

            MainUI.onThemeChange += (APPLICATION_STYLE aps) => OnThemeChange(aps);
        }

        private void OnThemeChange(APPLICATION_STYLE aps)
        {
            Application.SetStyle(aps);
        }
    }
}
