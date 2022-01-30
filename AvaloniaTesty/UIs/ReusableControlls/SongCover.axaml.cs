using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.ComponentModel;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;

namespace MusicPlayer
{
    public class SongCover : NotifyUserControl, ISongCover
    {
        public Subject<Bitmap> Cover { get; set; } = new Subject<Bitmap>();

        public SongCover()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = this;
        }

        public event ISongCover.OnLoad onLoad;

        public async Task LoadCover(ImageContainer imageContainer)
        {
            if(imageContainer.ImageStream != null)
                Cover.OnNext(await Task.Run(() => Bitmap.DecodeToWidth(imageContainer.ImageStream, 400)));
            else
                Cover.OnNext(null);
        }

        public void LoadCover(AudioMetaData audioMetaData)
        {
            onLoad.Invoke(audioMetaData);
        }
    }
}