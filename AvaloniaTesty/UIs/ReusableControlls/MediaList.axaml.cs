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
        public event IMediaList.OnLoadMediaList onLoadMediaList;
        public event IMediaList.OnLoadMediaListFromNewPath onLoadMediaListFromNewPath;

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

        private List<AudioMetaData> AudioMetaDataState { get; set; } = new List<AudioMetaData>();
        private bool _isLoaded = false;

        public MediaList()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;

            PropertyChanged += (object e, PropertyChangedEventArgs args) => PropertyChangedHandler(e, args);
        }

        public async void AddSongToList(AudioMetaData song)
        {
            await Task.Run(() => {
                songs.Add(new AudioDataModel()
                {
                    Title = song.Title,
                    Duration = song.Duration.ToString()
                });
                AudioMetaDataState.Add(song);
            });
        }

        public void SetPlaying(AudioMetaData selection)
        {
            SelectedSong = Songs[Songs.IndexOf(new AudioDataModel() { Title = selection.Title, Duration = selection.Duration.ToString() })];
        }

        private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedSong")
            {
                var song = AudioMetaDataState.Find( s => s.Title == SelectedSong.Title);
                if(song != new AudioMetaData())
                    onSelection.Invoke(song);
            }
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

        public async void LoadMediaList()
        {
            if(!_isLoaded)
            {
                await Task.Run(async () =>
                {
                    Songs.Clear();
                    AudioMetaDataState.Clear();
                    await onLoadMediaList.Invoke();
                });
                _isLoaded = true;
            }
        }

        public async void LoadMediaListFromNewMediaPath(string path)
        {
            await Task.Run(async () => {
                Songs.Clear();
                AudioMetaDataState.Clear();
                await onLoadMediaListFromNewPath.Invoke(path);
            });
            _isLoaded = true;
        }
    }
}
