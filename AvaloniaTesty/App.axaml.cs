using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Styling;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System;

namespace MusicPlayer;
public class App : Application, IApplication
{

    APPLICATION_STYLE _currStyle = APPLICATION_STYLE.DEFAULTDARK;

    private readonly static StyleInclude DataGridFluent = new (new Uri("avares://MusicPlayer/Styles"))
    {
        Source = new Uri("avares://Avalonia.Controls.DataGrid/Themes/Fluent.xaml"),
    };

    private readonly static StyleInclude FluentBase = new(new Uri("avares://MusicPlayer/Styles"))
    {
        Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/Base.xaml"),
    };

    private readonly static StyleInclude BaseDark = new(new Uri("avares://MusicPlayer/Styles"))
    {
        Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/BaseDark.xaml"),
    };

    private readonly static StyleInclude BaseLight = new(new Uri("avares://MusicPlayer/Styles"))
    {
        Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/BaseLight.xaml"),
    };

    private readonly static StyleInclude FluentControlResourcesDark = new(new Uri("avares://MusicPlayer/Styles"))
    {
        Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/FluentControlResourcesDark.xaml"),
    };

    private readonly static StyleInclude FluentControlResourcesLight = new(new Uri("avares://MusicPlayer/Styles"))
    {
        Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/FluentControlResourcesLight.xaml"),
    };

    public readonly static Styles FluentDark = new()
    {
        FluentBase,
        BaseDark,
        FluentControlResourcesDark,
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Fluent/FluentDark.xaml"),
        },
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/BaseDark.xaml"),
        },
        DataGridFluent,
    };

    public static Styles DefaultDark = new()
    {
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Default/DefaultTheme.xaml"),
        },
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Default/Accents/BaseDark.xaml"),
        },
    };

    public readonly static Styles FluentLight = new()
    {
        FluentBase,
        BaseLight,
        FluentControlResourcesLight,
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Fluent/FluentLight.xaml"),
        },
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Fluent/Accents/BaseLight.xaml"),
        },
        DataGridFluent,
    };

    public static Styles DefaultLight = new()
    {
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Default/DefaultTheme.xaml"),
        },
        new StyleInclude(new Uri("avares://MusicPlayer/Styles"))
        {
            Source = new Uri("avares://Avalonia.Themes.Default/Accents/BaseLight.xaml"),
        },
    };

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        DataContext = this;
    }

    public void SetStyle(APPLICATION_STYLE appStyle)
    {
        //_currStyle = appStyle;
        //switch (appStyle)
        //{
        //    case APPLICATION_STYLE.DARK:
        //    {
        //        if(Styles.Count > 0)
        //            Styles.RemoveAt(0);
        //        Styles.Insert(0, FluentDark);
        //        break;
        //    }
        //    case APPLICATION_STYLE.LIGHT:
        //    {
        //        if (Styles.Count > 0)
        //            Styles.RemoveAt(0);
        //        Styles.Insert(0, FluentLight);
        //        break;
        //    }
        //    case APPLICATION_STYLE.DEFAULT:
        //    {
        //        if (Styles.Count > 0)
        //            Styles.RemoveAt(0);
        //        Styles.Insert(0, DefaultLight);
        //        break;
        //    }
        //    case APPLICATION_STYLE.DEFAULTDARK:
        //    {
        //        if (Styles.Count > 0)
        //            Styles.RemoveAt(0);
        //        Styles.Insert(0, DefaultDark);
        //        break;
        //    }
        //}
    }

    public APPLICATION_STYLE GetCurrentApplicationStyle()
    {
        var t = Styles[0].GetType();

        switch (t.Name)
        {
            case "FluentDark":
                return APPLICATION_STYLE.DARK;
            case "FluentLight":
                return APPLICATION_STYLE.LIGHT;
            default:
                return _currStyle;
        }
    }
}