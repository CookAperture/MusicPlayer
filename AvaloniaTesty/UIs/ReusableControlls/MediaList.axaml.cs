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
using System.Reactive.Subjects;
using System.Reactive;

namespace MusicPlayer
{
    public class MediaList : NotifyUserControl, IMediaList
    {
        public ObservableCollection<AudioDataModel> Songs { get; set; } = new ObservableCollection<AudioDataModel>();
        public AudioDataModel SelectedSong 
        {
            get => _SelectedSong;
            set => RaiseAndSetIfChanged(ref _SelectedSong, value); 
        }

        private List<AudioMetaData> AudioMetaDataState { get; set; } = new List<AudioMetaData>();
        private bool _isLoaded = false;
        private AudioDataModel _SelectedSong;

        public event Action<AudioMetaData> onSelection;
        public event Func<Task> onLoadMediaList;
        public event Func<string, Task> onLoadMediaListFromNewPath;

        public MediaList()
        {
            DataContext = this;
            AvaloniaXamlLoader.Load(this);
        }

        private void OnSelectionChanged(object s, SelectionChangedEventArgs args)
        {
            var list = args.AddedItems.Cast<AudioDataModel>().ToList();
            var song = AudioMetaDataState.Find(s => s.Title == list.ElementAt(0).Title);
            if (song != new AudioMetaData())
                onSelection.Invoke(song);
        }

        public async void AddSongToList(AudioMetaData song)
        {
            await Task.Run(() => {
                Songs.Add(new AudioDataModel()
                {
                    Title = song.Title,
                    Duration = song.Duration.ToString()
                });
                AudioMetaDataState.Add(song);
            });
        }

        public void SetPlaying(AudioMetaData selection)
        {
            SelectedSong = Songs.ToList().Find((AudioDataModel elem) => elem.Title == selection.Title && elem.Duration == selection.Duration.ToString());
        }

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
