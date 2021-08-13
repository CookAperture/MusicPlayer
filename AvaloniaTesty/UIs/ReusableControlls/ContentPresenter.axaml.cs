using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    public class ContentPage : UserControl, IContentPresenter
    {
        public ISongCover SongCover { get; set; }
        public ISettings Settings { get; set; }

        public ContentPage()
        {
            AvaloniaXamlLoader.Load(this);

            SongCover = new SongCover();
            Settings = new Settings();

            DataContext = this;
            Content = SongCover;
        }

        public void ShowCoverPage()
        {
            Content = SongCover;
        }

        public void ShowSettingsPage()
        {
            Content = Settings;
        }
    }
}