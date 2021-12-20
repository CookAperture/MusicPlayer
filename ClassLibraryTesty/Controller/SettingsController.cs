using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class SettingsController : ISettingsController
    {
        public event ISettingsController.OnChangeTheme onChangeTheme;

        ISettings Settings { get; set; }

        public SettingsController(ISettings settings)
        {
            Settings = settings;
            Settings.onChangeTheme += (APPLICATION_STYLE appStyle) => onChangeTheme.Invoke(appStyle);
        }

    }
}
