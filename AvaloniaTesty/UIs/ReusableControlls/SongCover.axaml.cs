using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend.Contracts;

namespace MusicPlayer
{
    public class SongCover : UserControl, ISongCover
    {
        public SongCover()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void LoadCover()
        {
            throw new System.NotImplementedException();
        }
    }
}