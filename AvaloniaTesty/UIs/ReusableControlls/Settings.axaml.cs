using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;

namespace MusicPlayer
{

    public class Settings : NotifyUserControl, ISettings, INotifyPropertyChanged
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
        public ObservableCollection<ThemesModel> Themes { get; set; } = new ObservableCollection<ThemesModel>() 
        { 
            new ThemesModel() { Text = "Dark Theme" }, 
            new ThemesModel() { Text = "Light Theme" }, 
            new ThemesModel() { Text = "Default Light Theme" }, 
            new ThemesModel() { Text = "Default Dark Theme" }, 
        };
        public ObservableCollection<AudioDeviceModel> Devices { get; set; } = new ObservableCollection<AudioDeviceModel>();

        private int _ThemeSelectionIndex = 0;
        private int _DeviceSelectionIndex = 0;
        private string _MediaPath = "";

        public event Action<AppSettings> onSettingsChanged;
        public event Action onLoadSettings;

        public Settings()
        {
            AvaloniaXamlLoader.Load(this);

            DataContext = this;
        }

        public void SaveSettings()
        {
            AppSettings appSettings = new() { MediaPath = MediaPath, AudioDevice = Devices.ToList()[DeviceSelectionIndex].Text };
            
            APPLICATION_STYLE style = APPLICATION_STYLE.DARK;
            if (Themes.ToList()[ThemeSelectionIndex].Text == "Dark Theme")
                style = APPLICATION_STYLE.DARK;
            else if (Themes.ToList()[ThemeSelectionIndex].Text == "Light Theme")
                style = APPLICATION_STYLE.LIGHT;
            else if (Themes.ToList()[ThemeSelectionIndex].Text == "Default Light Theme")
                style = APPLICATION_STYLE.DEFAULT;
            else if (Themes.ToList()[ThemeSelectionIndex].Text == "Default Dark Theme")
                style = APPLICATION_STYLE.DEFAULTDARK;
            
            appSettings.AppStyle = style;
            
            onSettingsChanged?.Invoke(appSettings);
        }

        public void LoadSettings(AppSettings appSettings)
        {
            MediaPath = (appSettings.MediaPath);
            Devices.Clear();
            foreach (var device in appSettings.AudioDevices)
                Devices.Add(new AudioDeviceModel() { Text = device });
            string theme = "Dark Theme";
            if (appSettings.AppStyle == APPLICATION_STYLE.DARK)
                theme = "Dark Theme";
            else if (appSettings.AppStyle == APPLICATION_STYLE.LIGHT)
                theme = "Light Theme";
            else if (appSettings.AppStyle == APPLICATION_STYLE.DEFAULT)
                theme = "Default Light Theme";
            else if (appSettings.AppStyle == APPLICATION_STYLE.DEFAULTDARK)
                theme = "Default Dark Theme";
            DeviceSelectionIndex = Themes.ToList().IndexOf(new ThemesModel() { Text = theme });
            ThemeSelectionIndex = Devices.ToList().IndexOf(new AudioDeviceModel() { Text = appSettings.AudioDevice });
        }

        public void LoadSettings()
        {
            onLoadSettings.Invoke();
        }

        public async void OpenFileChooser(object s, RoutedEventArgs args)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            MediaPath = ( await saveFileDialog.ShowAsync((Window)Program.MainUI));
        }
    }
}