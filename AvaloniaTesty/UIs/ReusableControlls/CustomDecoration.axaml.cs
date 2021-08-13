using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ClassLibraryTesty.Contracts;

namespace AvaloniaTesty
{
    public class CustomDecoration : UserControl, ICustomDecoration
    {
        public event ICustomDecoration.OnMinimize onMinimize = delegate { };
        public event ICustomDecoration.OnMaximize onMaximize = delegate { };
        public event ICustomDecoration.OnClose onClose = delegate { };
        public event ICustomDecoration.OnDrag onDrag = delegate { };

        public CustomDecoration()
        {
            AvaloniaXamlLoader.Load(this);

            this.FindControl<Control>("TitleBar").PointerPressed += (i, e) => onDrag?.Invoke(i, e);
            this.FindControl<Button>("MinimizeButton").Click += (i, e) => onMinimize?.Invoke(e);
            this.FindControl<Button>("MaximizeButton").Click += (i, e) => onMaximize?.Invoke(e);
            this.FindControl<Button>("CloseButton").Click += (i, e) => onClose?.Invoke(e);
        }
    }
}