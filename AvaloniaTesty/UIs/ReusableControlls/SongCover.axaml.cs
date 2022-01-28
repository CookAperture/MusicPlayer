using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicPlayer
{
    public class SongCover : UserControl, ISongCover, INotifyPropertyChanged
    {

        new public event PropertyChangedEventHandler PropertyChanged;

        private Bitmap _cover;

        public Bitmap Cover
        {
            get => _cover;
            private set => this.RaiseAndSetIfChanged(ref _cover, value);
        }

        public SongCover()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;
        }

        public event ISongCover.OnLoad onLoad;

        public async Task LoadCover(ImageContainer imageContainer)
        {
            if(imageContainer.ImageStream != null)
                Cover = await Task.Run( () => Bitmap.DecodeToWidth(imageContainer.ImageStream, 400));
            else
                Cover = null;
        }

        public void LoadCover(AudioMetaData audioMetaData)
        {
            onLoad.Invoke(audioMetaData);
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