using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    public class MainWindow : Window, IMainUI
    {
        public event IMainUI.OnPlay onPlay;
        public event IMainUI.OnAddSong onAddSong;
        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
            onPlay = () => { };
            onAddSong = (string path) => { };
        }

        public override void Show()
        {
            base.Show();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnAddSong(object sender, RoutedEventArgs args)
        {
            onAddSong?.Invoke("");
        }

        private void OnPlay(object sender, RoutedEventArgs args)
        {
            //TODO
        }

        public void OnSongAdded(SongMetaData meta)
        {
            throw new System.NotImplementedException();
        }
    }
}
