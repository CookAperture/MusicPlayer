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

        /// <summary>
        /// Send when current theme set is fetched.
        /// </summary>
        public event ISettingsController.OnRequestCurrentThemeSet onRequestCurrentThemeSet;

        ISettings Settings { get; set; }
        ISettingsInteractor SettingsInteractor { get; set; }

        AppSettings _appSettings = new AppSettings();

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
        }

        AppSettings GetLatestSettings()
        {
            try
            {
                var appSettings = SettingsInteractor.ReadSettings();
                onRequestCurrentThemeSet.Invoke();
                var devices = SettingsInteractor.GetAudioDevices();

                appSettings.AudioDevices = devices;
                appSettings.AppStyle = _appSettings.AppStyle;

                _appSettings = appSettings;
                return _appSettings;
            }
            catch (FileNotFoundException f)
            {
                //log away the err + invoke event

                onRequestCurrentThemeSet.Invoke();
                var devices = SettingsInteractor.GetAudioDevices();
                _appSettings.AudioDevices = devices;
                return _appSettings;
            }
        }

        /// <summary>
        /// Loads the settings from the file and puts it into the ui.
        /// </summary>
        public void LoadSettings()
        {
            var appSettings = GetLatestSettings();
            Settings.LoadSettings(appSettings);
        }

        /// <summary>
        /// Loads the settings from the settings file.
        /// </summary>
        /// <returns><see cref="AppSettings"/> loaded.</returns>
        public AppSettings GetSettings()
        {
            _appSettings = GetLatestSettings();
            onSettingsLoaded.Invoke(_appSettings);
            return _appSettings;
        }

        /// <summary>
        /// Sets the current theme to the current settings.
        /// </summary>
        /// <param name="appStyle"></param>
        public void SetCurrentTheme(APPLICATION_STYLE appStyle)
        {
            _appSettings.AppStyle = appStyle;
        }
    }
}
