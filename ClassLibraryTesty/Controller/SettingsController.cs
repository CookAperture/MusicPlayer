using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    public class SettingsController : ISettingsController
    {
        public event ISettingsController.OnChangeTheme onChangeTheme;

        ISettings Settings { get; set; }
        ISettingsInteractor SettingsInteractor { get; set; }

        public SettingsController(ISettings settings, ISettingsInteractor settingsInteractor)
        {
            Settings = settings;
            SettingsInteractor = settingsInteractor;

            Settings.onSettingsChanged += (AppSettings appSettings) => SettingsInteractor.WriteSettings(appSettings);

            Settings.onChangeTheme += (APPLICATION_STYLE appStyle) => onChangeTheme.Invoke(appStyle);
        }

        public void LoadSettings()
        {
            var appSettings = SettingsInteractor.ReadSettings();
            Settings.LoadSettings(appSettings);
        }
    }
}
