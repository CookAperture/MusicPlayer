using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using ClassLibraryTesty.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTesty
{
    public static class WindowExtensions
    {

        public static T FindUserControl<T>(IEnumerable<Avalonia.LogicalTree.ILogical> list, string name) where T : UserControl
        {
            T Recursion(IEnumerable<Avalonia.LogicalTree.ILogical> list)
            {
                foreach (Avalonia.LogicalTree.ILogical i in list)
                {
                    if (i is Avalonia.INamed named && named is T ret && ret.Name == name)
                    {
                        return ret;
                    }
                    else
                    {
                        T r = Recursion(i.LogicalChildren);
                        if (r != null)
                        {
                            return r;
                        }
                    }
                }
                return null;
            }
            return Recursion(list);
        }

        public static ICustomDecoration ConnectCustomDecoration(this MainWindow @this, string customDecorationName, IEnumerable<Avalonia.LogicalTree.ILogical> logicalTree)
        {
            CustomDecoration customDecoration = FindUserControl<CustomDecoration>(logicalTree, customDecorationName);

            customDecoration.onDrag += (i, e) =>
            {
                @this.PlatformImpl?.BeginMoveDrag((PointerPressedEventArgs)e);
            };
            customDecoration.onMinimize += delegate
            {
                @this.WindowState = WindowState.Minimized;
            };
            customDecoration.onMaximize += delegate
            {
                @this.WindowState = @this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };
            customDecoration.onClose += delegate
            {
                @this.Close();
            };

            return customDecoration;
        }

        public static ISoundControlBar ConnectSoundControlBar(ISoundControlBar.OnPlay onPlayDelegate, string soundControlBarName, IEnumerable<Avalonia.LogicalTree.ILogical> logicalTree)
        {
            SoundControlBar customDecoration = FindUserControl<SoundControlBar>(logicalTree, soundControlBarName);

            customDecoration.onPlay += onPlayDelegate;

            return customDecoration;
        }
    }

}
