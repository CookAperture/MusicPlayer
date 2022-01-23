using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend;
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

            Settings.onSettingsChanged += (AppSettings aps) => { MediaList.LoadMediaListFromNewMediaPath(aps.MediaPath); };
            MediaList.onSelection += (AudioMetaData data) => { SongCover.LoadCover(); };

            DataContext = this;
            Content = SongCover;
        }

        public void ShowCoverPage()
        {
            Content = SongCover;
        }

        public void ShowSettingsPage()
        {
            Settings.LoadSettings();
            Content = Settings;
        }

        public void ShowMediaListPage()
        {
            MediaList.LoadMediaList();
            Content = MediaList;
        }
    }
}