using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayer
{
    public class App : Application, IApplication
    {

        private static readonly StyleInclude DataGridFluent = new (new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Controls.DataGrid/Themes/Fluent.xaml")
        };

        public static readonly Styles FluentDark = new()
        {
            new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentDark.xaml")
            },
            DataGridFluent
        };

        public static readonly Styles FluentLight = new()
        {
            new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
            {
                Source = new Uri("avares://Avalonia.Themes.Fluent/FluentLight.xaml")
            },
            DataGridFluent
        };

        public override void Initialize()
        {
            SetStyle(APPLICATION_STYLE.DARK);
            DataContext = this;
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
                        //Styles[0] = FluentDark;
                        if(Styles.Count > 0)
                            Styles.RemoveAt(0);
                        //Styles.Remove(FluentDark);
                        Styles.Insert(0, FluentDark);
                        break;
                    }
                case APPLICATION_STYLE.LIGHT:
                    {
                        //Styles[0] = FluentLight;
                        if (Styles.Count > 0)
                            Styles.RemoveAt(0);
                        //Styles.Remove(FluentLight);
                        Styles.Insert(0, FluentLight);
                        break;
                    }
            }
        }
    }
}