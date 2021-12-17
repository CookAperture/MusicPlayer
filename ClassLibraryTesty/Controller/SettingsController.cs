using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class SettingsController : ISettingsController
    {
        ISettings settings;
        public SettingsController(ISettings settings)
        {
            this.settings = settings;
        }
    }
}
