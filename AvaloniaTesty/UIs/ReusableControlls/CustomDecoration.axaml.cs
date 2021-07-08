using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaTesty
{
    public class CustomDecoration : UserControl
    {
        public CustomDecoration()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}