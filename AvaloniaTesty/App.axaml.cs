using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using ClassLibraryTesty;
using ClassLibraryTesty.Contracts;
using System;

namespace AvaloniaTesty
{
    public class App : Application, IApplication
    {

        private static readonly StyleInclude DataGridFluent = new(new Uri("avares://Avalonia.MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Controls.DataGrid/Themes/Fluent.xaml")
        };

        public static Styles FluentDark = new Styles
        {
            new StyleInclude(new Uri("avares://Avalonia.MusicPlayer/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentDark.xaml")
            },
            DataGridFluent
        };

        public static Styles FluentLight = new Styles
        {
            new StyleInclude(new Uri("avares://Avalonia.MusicPlayer/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentLight.xaml")
            },
            DataGridFluent
        };

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            //if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            //{
            //    MainUI = new MainUI();
            //    desktop.MainUI = MainUI;
            //}
            //DoSomethingAppSpecific -> e.g. setup lifetime for various platforms eventually

            base.OnFrameworkInitializationCompleted();
        }

        public void SetStyle(APPLICATION_STYLE appStyle)
        {
            switch (appStyle)
            {
                case APPLICATION_STYLE.DARK:
                    {
                        Styles.Insert(0, FluentDark);
                        break;
                    }
                case APPLICATION_STYLE.LIGHT:
                    {
                        Styles.Insert(0, FluentLight);
                        break;
                    }
                default:
                    {
                        Styles.Insert(0, FluentDark);
                        break;
                    }
            }
        }
    }
}