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
            if (Application.Current.Styles.Contains(App.FluentDark)
               || Application.Current.Styles.Contains(App.FluentLight))
            {
                var theme = new Avalonia.Themes.Fluent.Controls.FluentControls();
                theme.TryGetResource("Button", out _);
            }
            else
            {
                var theme = new Avalonia.Themes.Default.DefaultTheme();
                theme.TryGetResource("Button", out _);
            }
            AvaloniaXamlLoader.Load(this);

            this.AddMinimizeMaximizeCloseDragToCustomDecoration("TitleBar", "MinimizeButton", "MaximizeButton", "CloseButton", "CustomDecoration", this.LogicalChildren);

            this.Background = new SolidColorBrush(new Color(90, 124, 124, 124), 1);
            this.Title = "MusicPlayer";
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
