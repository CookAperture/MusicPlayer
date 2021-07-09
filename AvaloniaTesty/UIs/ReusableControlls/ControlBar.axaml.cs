using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    public class SoundControlBar : UserControl, ISoundControlBar
    {
        public event ISoundControlBar.OnPlay onPlay;
        public SoundControlBar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OnPlay(object sender, RoutedEventArgs args)
        {
            onPlay?.Invoke();
        }
    }
}