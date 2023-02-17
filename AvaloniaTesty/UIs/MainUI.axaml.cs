using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicPlayer.UIs;
public class MainUI : Window, IMainUI, INotifyPropertyChanged, INotifyUI
{
    public new event PropertyChangedEventHandler PropertyChanged;
    public event Action<APPLICATION_STYLE> onThemeChange;

    public ICustomDecoration CustomDecoration { get; set; }
    public ISoundControlBar SoundControlBar { get; set; }
    public IContentPresenter ContentPresenter { get; set; }

    IManagedNotificationManager ManagedNotificationManager { get; set; }

    bool _paneOpen = false;
    public bool PaneState
    {            
        get => _paneOpen;
        set => RaiseAndSetIfChanged(ref _paneOpen, value);
    }

    public MainUI()
    {
        AvaloniaXamlLoader.Load(this);

        ManagedNotificationManager = new WindowNotificationManager(this) { Position = NotificationPosition.BottomRight, MaxItems = 5 };
                
        CustomDecoration = (ICustomDecoration)this.FindControl<UserControl>("CustomDecoration");
        SoundControlBar = (ISoundControlBar)this.FindControl<UserControl>("SoundControlBar");
        ContentPresenter = (IContentPresenter)this.FindControl<UserControl>("ContentPage");

        CustomDecoration.onDrag += (i, e) => { PlatformImpl?.BeginMoveDrag((PointerPressedEventArgs)e);};
        CustomDecoration.onMinimize += delegate { WindowState = WindowState.Minimized; };
        CustomDecoration.onMaximize += delegate { WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized; };
        CustomDecoration.onClose += delegate { Close(); };

        ContentPresenter.MediaList.onSelection += (AudioMetaData data) => { SoundControlBar.SetAudioMetaData(data); };
        ContentPresenter.Settings.onSettingsChanged += (AppSettings data) => { onThemeChange.Invoke(data.AppStyle); };

        ((INotifyError)ContentPresenter.SongCover).onError += (NotificationModel model) => Notify(model);
        ((INotifyError)ContentPresenter.Settings).onError += (NotificationModel model) => Notify(model);
        ((INotifyError)ContentPresenter.MediaList).onError += (NotificationModel model) => Notify(model);
        ((INotifyError)SoundControlBar).onError += (NotificationModel model) => Notify(model);

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
        
    public async void Notify(NotificationModel message)
    {            
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            ManagedNotificationManager.Show(new Notification(message.Title, message.Message, MapNotificationLevelToNotificationType(message.Level)));
        });
    }

    private NotificationType MapNotificationLevelToNotificationType(NotificationModel.NotificationLevel notificationLevel)
    {
        switch (notificationLevel)
        {
            case NotificationModel.NotificationLevel.Information:
                return NotificationType.Information;
            case NotificationModel.NotificationLevel.Warning:
                return NotificationType.Warning;
            case NotificationModel.NotificationLevel.Error:
                return NotificationType.Error;
            default:
                return NotificationType.Information;
        }
    }
}