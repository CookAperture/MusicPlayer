using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
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