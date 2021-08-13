using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    public class Settings : UserControl, ISettings
    {
        public Settings()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void LoadSettings()
        {
            throw new System.NotImplementedException();
        }
    }
}