using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaTesty
{
    public class MediaList : UserControl, IMediaList, INotifyPropertyChanged
    {
        new public event PropertyChangedEventHandler? PropertyChanged;
        ObservableCollection<string /*MetaDataStruct*/> songs = new ObservableCollection<string>();
        public ObservableCollection<string> Songs
        {
            get => songs;
            set => RaiseAndSetIfChanged(ref songs, value);
        }
        string selectedSong;
        public string SelectedSong
        {
            get => selectedSong;
            set => RaiseAndSetIfChanged(ref selectedSong, value);
        }

        public MediaList()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;
        }

        public event IMediaList.OnSelection onSelection;

        public void SetList()
        {
            throw new System.NotImplementedException();
        }

        public void SetPlaying()
        {
            throw new System.NotImplementedException();
        }

        private void PropertyChangedHandler(object? sender, PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "SelectedPath")
            //    onSingleFilePathSelection?.Invoke(SelectedPath.Path);
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
