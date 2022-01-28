using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicPlayer
{
    public class Settings : UserControl, ISettings, INotifyPropertyChanged
    {
        new public event PropertyChangedEventHandler PropertyChanged;

        public event ISettings.OnSettingsChanged onSettingsChanged = (AppSettings settings) => {};
        public event ISettings.OnLoadSettings onLoadSettings = () => { };

        int themeSelection = -1;
        public int ThemeSelection
        {
            get => themeSelection;
            set => RaiseAndSetIfChanged(ref themeSelection, value);
        }

        int deviceSelection = -1;
        public int DeviceSelection
        {
            get => deviceSelection;
            set => RaiseAndSetIfChanged(ref deviceSelection, value);
        }

        string mediaPath = "";
        public string MediaPath
        {
            get => mediaPath;
            set => RaiseAndSetIfChanged(ref mediaPath, value);
        }

        ObservableCollection<ThemesModel> themes = new ObservableCollection<ThemesModel>() { new ThemesModel() { Text = "Dark Theme" }, new ThemesModel() { Text = "Light Theme" }, new ThemesModel() { Text = "Default Light Theme" }, new ThemesModel() { Text = "Default Dark Theme" } };
        public ObservableCollection<ThemesModel> Themes
        {
            get => themes;
            set => RaiseAndSetIfChanged(ref themes, value);
        }

        ObservableCollection<AudioDeviceModel> devices = new ObservableCollection<AudioDeviceModel>() { new AudioDeviceModel() { Text = "Default" } };
        public ObservableCollection<AudioDeviceModel> Devices
        {
            get => devices;
            set => RaiseAndSetIfChanged(ref devices, value);
        }

        public Settings()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;
        }

        public void SaveSettings()
        {
            AppSettings appSettings = new() { MediaPath = MediaPath, AudioDevice = Devices[DeviceSelection].Text};

            APPLICATION_STYLE style = APPLICATION_STYLE.DARK;
            if (Themes[ThemeSelection].Text == "Dark Theme")
                style = APPLICATION_STYLE.DARK;
            else if (Themes[ThemeSelection].Text == "Light Theme")
                style = APPLICATION_STYLE.LIGHT;
            else if (Themes[ThemeSelection].Text == "Default Light Theme")
                style = APPLICATION_STYLE.DEFAULT;
            else if (Themes[ThemeSelection].Text == "Default Dark Theme")
                style = APPLICATION_STYLE.DEFAULTDARK;

            appSettings.AppStyle = style;

            onSettingsChanged?.Invoke(appSettings);
        }

        public void LoadSettings(AppSettings appSettings)
        {
            MediaPath = appSettings.MediaPath;
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
            ThemeSelection = Themes.IndexOf(new ThemesModel() { Text = theme });
            DeviceSelection = Devices.IndexOf(new AudioDeviceModel() { Text = appSettings.AudioDevice });
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

        public void LoadSettings()
        {
            onLoadSettings.Invoke();
        }
    }
}