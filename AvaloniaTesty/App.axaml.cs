using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaTesty
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            //if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            //{
            //    MainUI = new MainWindow();
            //    desktop.MainWindow = MainUI;
            //}

            //DoSomethingAppSpecific -> e.g. setup lifetime for various platforms eventually

            base.OnFrameworkInitializationCompleted();
        }
    }
}
