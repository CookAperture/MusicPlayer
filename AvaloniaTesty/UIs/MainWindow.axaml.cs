using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTesty
{
    public class MainWindow : Window, IMainUI, INotifyPropertyChanged
    {
        public event IMainUI.OnPlay onPlay = delegate { };
        public event IMainUI.OnAddSong onAddSong = (path) => { };

        public ICustomDecoration CustomDecoration { get; set; }
        public ISoundControlBar SoundControlBar { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.AttachDevTools();
        }

        public override void Show()
        {
            base.Show();
        }

        private void OnAddSong(object sender, RoutedEventArgs args)
        {
            onAddSong?.Invoke("");
        }

        public void OnSongAdded(SongMetaData meta)
        {
            throw new System.NotImplementedException();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            CustomDecoration = this.ConnectCustomDecoration("CustomDecoration", this.LogicalChildren);
            SoundControlBar = WindowExtensions.ConnectSoundControlBar(delegate { onPlay?.Invoke(); }, "SoundControlBar", this.LogicalChildren);

            this.Background = new SolidColorBrush(new Color(90, 124, 124, 124), 1);
            this.Title = "MusicPlayer";
        }

        new public event PropertyChangedEventHandler PropertyChanged;

        protected bool RaiseAndSetIfChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
