using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System.Reactive.Subjects;

namespace MusicPlayer.UIs.ReusableControlls;
public class SongCover : NotifyUserControl, ISongCover, INotifyUI, INotifyError
{
    public Subject<Bitmap> Cover { get; set; } = new();

    public SongCover()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = this;
    }

    public event Action<AudioMetaData> onLoad;
    public event Action<NotificationModel> onError;

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

    public void Notify(NotificationModel message)
    {
        onError.Invoke(message);
    }
}