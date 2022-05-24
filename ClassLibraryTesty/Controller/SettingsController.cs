using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISettingsController"/>.
    /// </summary>
    public class SettingsController : ISettingsController, INotifyError
    {
        ISettings Settings { get; set; }
        ISettingsInteractor SettingsInteractor { get; set; }
        IApplication Application { get; set; }

        AppSettings _appSettings = new AppSettings();

        public event Action<NotificationModel> onError;

        /// <summary>
        /// Connects <paramref name="settings"/> with <paramref name="settingsInteractor"/>.
        /// </summary>
        /// <param name="settings">A reference to the settings ui.</param>
        /// <param name="settingsInteractor">A reference to the settings interactor.</param>
        /// <param name="application"></param>
        public SettingsController(ISettings settings, ISettingsInteractor settingsInteractor, IApplication application)
        {
            Settings = settings;
            SettingsInteractor = settingsInteractor;
            Application = application;

            SettingsInteractor.SetAudioDevice(SettingsInteractor.ReadSettings().AudioDevice);
            ((INotifyError)SettingsInteractor).onError += (NotificationModel notificationModel) => ((INotifyUI)Settings).Notify(notificationModel);

            Settings.onSettingsChanged += (AppSettings appSettings) => OnSettingsChanged(appSettings);
            Settings.onLoadSettings += () => LoadSettings();

            onError += (NotificationModel notificationModel) => ((INotifyUI)Settings).Notify(notificationModel);
        }

        private void OnSettingsChanged(AppSettings appSettings)
        {
            _appSettings = appSettings;
            SettingsInteractor.WriteSettings(appSettings);
            SettingsInteractor.SetAudioDevice(appSettings.AudioDevice);
        }

        private AppSettings GetLatestSettings()
        {
            AppSettings appSettings = new AppSettings();

            appSettings = SettingsInteractor.ReadSettings();

            var currStyle = Application.GetCurrentApplicationStyle();
            var devices = SettingsInteractor.GetAudioDevices();

            appSettings.AudioDevices = devices;
            appSettings.AppStyle = currStyle;

            _appSettings = appSettings;
            return _appSettings;
        }

        /// <summary>
        /// Loads the settings from the file and puts it into the ui.
        /// </summary>
        public void LoadSettings()
        {
            var appSettings = GetLatestSettings();
            Settings.LoadSettings(appSettings);
        }
    }
}
