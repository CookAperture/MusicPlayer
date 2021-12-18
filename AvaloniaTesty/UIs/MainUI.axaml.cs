using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTesty
{
    public class MainUI : Window, IMainUI, INotifyPropertyChanged
    {
        public event IMainUI.OnPlay onPlay = delegate { };

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
            SoundControlBar.onPlay += () => { onPlay.Invoke(); };

            Title = "MusicPlayer";
            DataContext = this;
            SetDark();

            this.AttachDevTools();
        }

        public override void Show()
        {
            base.Show();
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

        public void SetDark()
        {
            Background = new SolidColorBrush(new Color(120, 40, 40, 40));
            //HighlightedBackgound = new SolidColorBrush(new Color(255, 40, 40, 40));
            Foreground = new SolidColorBrush(new Color(255, 250, 250, 250));

            Application.Current.Styles.Insert(0, App.DefaultDark);
        }

        public void SetLight()
        {
            Background = new SolidColorBrush(new Color(120, 238, 238, 238));
            //HighlightedBackgound = new SolidColorBrush(new Color(255, 255, 255, 255));
            Foreground = new SolidColorBrush(new Color(255, 70, 70, 70));

            Application.Current.Styles.Insert(0, App.DefaultLight);

        }
    }
}