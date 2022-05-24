using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MusicPlayerBackend.Contracts;

namespace MusicPlayer
{
    public class CustomDecoration : UserControl, ICustomDecoration
    {
        public CustomDecoration()
        {
            AvaloniaXamlLoader.Load(this);

            this.FindControl<Control>("TitleBar").PointerPressed += (i, e) => onDrag?.Invoke(i, e);
            this.FindControl<Button>("MinimizeButton").Click += (i, e) => onMinimize?.Invoke(e);
            this.FindControl<Button>("MaximizeButton").Click += (i, e) => onMaximize?.Invoke(e);
            this.FindControl<Button>("CloseButton").Click += (i, e) => onClose?.Invoke(e);
        }

        public event Action<EventArgs> onMinimize = delegate { };
        public event Action<EventArgs> onMaximize = delegate { };
        public event Action<object> onClose = delegate { };
        public event Action<object, EventArgs> onDrag = delegate { };
    }
}