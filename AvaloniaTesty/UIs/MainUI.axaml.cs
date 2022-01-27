using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicPlayer
{
    public class MainUI : Window, IMainUI, INotifyPropertyChanged
    {
        new public event PropertyChangedEventHandler PropertyChanged;
        public event IMainUI.OnThemeChange onThemeChange;

        public ICustomDecoration CustomDecoration { get; set; }
        public ISoundControlBar SoundControlBar { get; set; }
        public IContentPresenter ContentPresenter { get; set; }

        bool paneOpen = false;

        public bool PaneState
        {            
            get => paneOpen;
            set => RaiseAndSetIfChanged(ref paneOpen, value);
        }

        public MainUI()
        {
            AvaloniaXamlLoader.Load(this);

            CustomDecoration = (ICustomDecoration)WindowHelperFunctions.FindUserControl<UserControl>(LogicalChildren, "CustomDecoration");
            SoundControlBar = (ISoundControlBar)WindowHelperFunctions.FindUserControl<UserControl>(LogicalChildren, "SoundControlBar");
            ContentPresenter = (IContentPresenter)WindowHelperFunctions.FindUserControl<UserControl>(LogicalChildren, "ContentPage");

            CustomDecoration.onDrag += (i, e) => { PlatformImpl?.BeginMoveDrag((PointerPressedEventArgs)e);};
            CustomDecoration.onMinimize += delegate { WindowState = WindowState.Minimized; };
            CustomDecoration.onMaximize += delegate { WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; };
            CustomDecoration.onClose += delegate { Close(); };

            ContentPresenter.MediaList.onSelection += (AudioMetaData data) => { SoundControlBar.SetAudioMetaData(data); };
            ContentPresenter.Settings.onSettingsChanged += (AppSettings data) => { onThemeChange.Invoke(data.AppStyle); };

            this.FindControl<Button>("PaneButton").Click += (i, e) => { if (PaneState) PaneState = false; else PaneState = true; };
            this.FindControl<Button>("CoverButton").Click += (i, e) => ContentPresenter.ShowCoverPage();
            this.FindControl<Button>("SettingsButton").Click += (i, e) => ContentPresenter.ShowSettingsPage();
            this.FindControl<Button>("MediaListButton").Click += (i, e) => ContentPresenter.ShowMediaListPage();

            Title = "MusicPlayer";
            DataContext = this;

            this.AttachDevTools();
        }

        public override void Show()
        {
            base.Show();
        }


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