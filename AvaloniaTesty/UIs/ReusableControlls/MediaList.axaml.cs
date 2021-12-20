using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace AvaloniaTesty
{
    public class MediaList : UserControl, IMediaList, INotifyPropertyChanged
    {
        new public event PropertyChangedEventHandler PropertyChanged;

        public event IMediaList.OnSelection onSelection = (AudioMetaData selection) => { };

        ObservableCollection<AudioDataModel> songs = new ObservableCollection<AudioDataModel>();
        public ObservableCollection<AudioDataModel> Songs
        {
            get => songs;
            set => RaiseAndSetIfChanged(ref songs, value);
        }
        AudioDataModel selectedSong;
        public AudioDataModel SelectedSong
        {
            get => selectedSong;
            set => RaiseAndSetIfChanged(ref selectedSong, value);
        }

        public MediaList()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;
        }

        public void SetList(List<AudioMetaData> mediaList)
        {
            Songs.Clear();
            foreach (var song in mediaList)
                Songs.Add(new AudioDataModel() { Title = song.Title, Duration = song.Duration.ToString() });
        }

        public void SetPlaying(AudioMetaData selection)
        {
            SelectedSong = Songs[Songs.IndexOf(new AudioDataModel() { Title = selection.Title, Duration = selection.Duration.ToString() })];
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
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

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
