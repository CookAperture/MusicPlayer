using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaTesty
{
    public class App : Application
    {
        public Avalonia.Controls.Window MainUI { get; set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                MainUI = new MainWindow();
                desktop.MainWindow = MainUI;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
