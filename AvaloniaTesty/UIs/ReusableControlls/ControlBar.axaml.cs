using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaTesty
{
    public class SoundControlBar : UserControl
    {
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
            //TODO
            //this.Background = new SolidColorBrush(new Color(20, 66, 66, 66), 1);
        }
    }
}