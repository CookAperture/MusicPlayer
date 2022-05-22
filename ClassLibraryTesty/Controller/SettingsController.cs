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

            Settings.onSettingsChanged += (AppSettings appSettings) => OnSettingsChanged(appSettings);
            Settings.onLoadSettings += () => LoadSettings();

            onError += (NotificationModel notificationModel) => ((INotifyUI)Settings).Notify(notificationModel);
        }

        private void OnSettingsChanged(AppSettings appSettings)
        {
            _appSettings = appSettings;
            try
            {
                SettingsInteractor.WriteSettings(appSettings);
            }
            catch (FileWriteFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error"});
            }
            SettingsInteractor.SetAudioDevice(appSettings.AudioDevice);
        }

        private AppSettings GetLatestSettings()
        {
            AppSettings appSettings = new AppSettings();

            try
            {
                appSettings = SettingsInteractor.ReadSettings();
            }
            catch (FileReadFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Warning, Title = "Error" });
            }

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
