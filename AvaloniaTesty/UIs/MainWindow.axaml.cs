using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
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

        private void OnPlay(object sender, RoutedEventArgs args)
        {
            //TODO
        }

        public void OnSongAdded(SongMetaData meta)
        {
            throw new System.NotImplementedException();
        }

        void SetupSide(string name, StandardCursorType cursor, WindowEdge edge)
        {
            var ctl = this.FindControl<Control>(name);
            ctl.Cursor = new Cursor(cursor);
            ctl.PointerPressed += (i, e) =>
            {
                PlatformImpl?.BeginResizeDrag(edge, e);
            };
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

            this.FindControl<Control>("TitleBar").PointerPressed += (i, e) =>
            {
                PlatformImpl?.BeginMoveDrag(e);
            };
            this.FindControl<Button>("MinimizeButton").Click += delegate
            {
                this.WindowState = WindowState.Minimized;
            };
            this.FindControl<Button>("MaximizeButton").Click += delegate
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };
            this.FindControl<Button>("CloseButton").Click += delegate
            {
                Close();
            };
            //SetupSide("Left", StandardCursorType.LeftSide, WindowEdge.West);
            //SetupSide("Right", StandardCursorType.RightSide, WindowEdge.East);
            //SetupSide("Top", StandardCursorType.TopSide, WindowEdge.North);
            //SetupSide("Bottom", StandardCursorType.BottomSide, WindowEdge.South);
            //SetupSide("TopLeft", StandardCursorType.TopLeftCorner, WindowEdge.NorthWest);
            //SetupSide("TopRight", StandardCursorType.TopRightCorner, WindowEdge.NorthEast);
            //SetupSide("BottomLeft", StandardCursorType.BottomLeftCorner, WindowEdge.SouthWest);
            //SetupSide("BottomRight", StandardCursorType.BottomRightCorner, WindowEdge.SouthEast);
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
