using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTesty
{
    public class Settings : UserControl, ISettings, INotifyPropertyChanged
    {
        public event ISettings.OnSettingsChanged onSettingsChanged;

        new public event PropertyChangedEventHandler? PropertyChanged;

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

        ObservableCollection<string> devices = new ObservableCollection<string>() {"Laursprecher", "Kopfhörer"};
        public ObservableCollection<string> Devices
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
            //TODO
        }

        public void LoadSettings()
        {
            throw new System.NotImplementedException();
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

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}