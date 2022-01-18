using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISettingsController"/>.
    /// </summary>
    public class SettingsController : ISettingsController
    {

        /// <summary>
        /// Send when theme is changed, triggered by the <see cref="ISettings"/>.
        /// </summary>
        public event ISettingsController.OnChangeTheme onChangeTheme;

        /// <summary>
        /// Send when settings loaded.
        /// </summary>
        public event ISettingsController.OnSettingsLoaded onSettingsLoaded;

        ISettings Settings { get; set; }
        ISettingsInteractor SettingsInteractor { get; set; }

        AppSettings _appSettings;

        /// <summary>
        /// Connects <paramref name="settings"/> with <paramref name="settingsInteractor"/>.
        /// </summary>
        /// <param name="settings">A reference to the settings ui.</param>
        /// <param name="settingsInteractor">A reference to the settings interactor.</param>
        public SettingsController(ISettings settings, ISettingsInteractor settingsInteractor)
        {
            Settings = settings;
            SettingsInteractor = settingsInteractor;

            Settings.onSettingsChanged += (AppSettings appSettings) => 
            {
                _appSettings = appSettings; 
                SettingsInteractor.WriteSettings(appSettings); 
                onSettingsLoaded.Invoke(_appSettings);
            };

            Settings.onChangeTheme += (APPLICATION_STYLE appStyle) => onChangeTheme.Invoke(appStyle);

            _appSettings = SettingsInteractor.ReadSettings();
        }

        /// <summary>
        /// Loads the settings from the file and puts it into the ui.
        /// </summary>
        public void LoadSettings()
        {
            var appSettings = SettingsInteractor.ReadSettings();
            Settings.LoadSettings(appSettings);
        }

        /// <summary>
        /// Loads the settings from the settings file.
        /// </summary>
        /// <returns><see cref="AppSettings"/> loaded.</returns>
        public AppSettings LoadAppSettings()
        {
            onSettingsLoaded.Invoke(_appSettings);
            return _appSettings;
        }
    }
}
