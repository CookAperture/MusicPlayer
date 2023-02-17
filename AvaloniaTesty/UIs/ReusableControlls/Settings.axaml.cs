using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System.Collections.ObjectModel;

namespace MusicPlayer.UIs.ReusableControlls;
public class Settings : NotifyUserControl, ISettings, INotifyUI, INotifyError
{
    public int ThemeSelectionIndex
    {
        get => _ThemeSelectionIndex;
        set => RaiseAndSetIfChanged(ref _ThemeSelectionIndex, value);
    }
    public int DeviceSelectionIndex 
    {
        get => _DeviceSelectionIndex; 
        set => RaiseAndSetIfChanged(ref _DeviceSelectionIndex, value);
    }
    public string MediaPath
    {
        get => _MediaPath; 
        set => RaiseAndSetIfChanged(ref _MediaPath, value); 
    }
    public ObservableCollection<ThemesModel> Themes { get; set; } = new() 
    { 
        new ThemesModel { Text = "Dark Theme" }, 
        new ThemesModel { Text = "Light Theme" }, 
        new ThemesModel { Text = "Default Light Theme" }, 
        new ThemesModel { Text = "Default Dark Theme" }, 
    };
    public ObservableCollection<AudioDeviceModel> Devices { get; set; } = new();

    private int _ThemeSelectionIndex = 0;
    private int _DeviceSelectionIndex = 0;
    private string _MediaPath = "";

    public event Action<AppSettings> onSettingsChanged;
    public event Action onLoadSettings;
    public event Action<NotificationModel> onError;

    public Settings()
    {
        AvaloniaXamlLoader.Load(this);

        DataContext = this;
    }

    public void SaveSettings()
    {
        AppSettings appSettings = new() { MediaPath = MediaPath, AudioDevice = Devices.ToList()[DeviceSelectionIndex].Text };

        var style = Themes.ToList()[ThemeSelectionIndex].Text switch
        {
            "Dark Theme" => APPLICATION_STYLE.DARK,
            "Light Theme" => APPLICATION_STYLE.LIGHT,
            "Default Light Theme" => APPLICATION_STYLE.DEFAULT,
            "Default Dark Theme" => APPLICATION_STYLE.DEFAULTDARK,
            _ => APPLICATION_STYLE.DARK,
        };

        appSettings.AppStyle = style;
            
        onSettingsChanged?.Invoke(appSettings);
    }

    public void LoadSettings(AppSettings appSettings)
    {
        MediaPath = (appSettings.MediaPath);
        Devices.Clear();
        foreach (var device in appSettings.AudioDevices)
            Devices.Add(new AudioDeviceModel { Text = device });
        var theme = appSettings.AppStyle switch
        {
            APPLICATION_STYLE.DARK => "Dark Theme",
            APPLICATION_STYLE.LIGHT => "Light Theme",
            APPLICATION_STYLE.DEFAULT => "Default Light Theme",
            APPLICATION_STYLE.DEFAULTDARK => "Default Dark Theme",
            _ => "Dark Theme",
        };
        DeviceSelectionIndex = Themes.ToList().IndexOf(new ThemesModel { Text = theme });
        ThemeSelectionIndex = Devices.ToList().IndexOf(new AudioDeviceModel { Text = appSettings.AudioDevice });
    }

    public void LoadSettings()
    {
        onLoadSettings.Invoke();
    }

    public async void OpenFileChooser(object s, RoutedEventArgs args)
    {
        var saveFileDialog = new SaveFileDialog();
        MediaPath = ( await saveFileDialog.ShowAsync((Window)Program.MainUI));
    }

    public void Notify(NotificationModel message)
    {
        onError.Invoke(message);
    }
}