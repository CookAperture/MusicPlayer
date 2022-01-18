using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace MusicPlayer
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

        public void AddSongToList(AudioMetaData song)
        {
            songs.Add(new AudioDataModel() 
            { 
                Title = song.Title,
                Duration = song.Duration.ToString()
            });
        }

        public void SetPlaying(AudioMetaData selection)
        {
            SelectedSong = Songs[Songs.IndexOf(new AudioDataModel() { Title = selection.Title, Duration = selection.Duration.ToString() })];
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedSong")
                onSelection.Invoke(new AudioMetaData() 
                { 
                    AudioFilePath = "", 
                    Duration = TimeSpan.Parse(SelectedSong.Duration), 
                    Title = SelectedSong.Title
                });
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
