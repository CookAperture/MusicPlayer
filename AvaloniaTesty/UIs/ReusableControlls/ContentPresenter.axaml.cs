using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend.Contracts;

namespace MusicPlayer
{
    public class ContentPage : UserControl, IContentPresenter
    {
        public ISongCover SongCover { get; set; }
        public ISettings Settings { get; set; }
        public IMediaList MediaList { get; set; }

        public ContentPage()
        {
            AvaloniaXamlLoader.Load(this);

            SongCover = new SongCover();
            Settings = new Settings();
            MediaList = new MediaList();

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

        public void ShowMediaListPage()
        {
            Content = MediaList;
        }
    }
}