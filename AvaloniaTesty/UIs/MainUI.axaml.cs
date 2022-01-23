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
        public ICustomDecoration CustomDecoration { get; set; }
        public ISoundControlBar SoundControlBar { get; set; }
        public IContentPresenter ContentPresenter { get; set; }

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
            CustomDecoration.onCoverButtonClick += delegate { ContentPresenter.ShowCoverPage(); };
            CustomDecoration.onSettingsButtonClick += delegate { ContentPresenter.ShowSettingsPage(); };
            CustomDecoration.onMediaListButtonClick += delegate { ContentPresenter.ShowMediaListPage(); };

            ContentPresenter.MediaList.onSelection += (AudioMetaData data) => { SoundControlBar.SetAudioMetaData(data); };
            ContentPresenter.Settings.onSettingsChanged += (AppSettings data) => { onThemeChange.Invoke(data.AppStyle); };

            Title = "MusicPlayer";
            DataContext = this;

            this.AttachDevTools();
        }

        public override void Show()
        {
            base.Show();
        }

        new public event PropertyChangedEventHandler PropertyChanged;
        public event IMainUI.OnThemeChange onThemeChange;

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