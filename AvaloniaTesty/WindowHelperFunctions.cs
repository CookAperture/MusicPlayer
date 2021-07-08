using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.VisualTree;
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

        public static void AddMinimizeMaximizeCloseDragToCustomDecoration(this Window @this, string titleBarName, string minName, string maxName, string closeName, string customDecorationName, IEnumerable<Avalonia.LogicalTree.ILogical> logicalTree)
        {
            CustomDecoration customDecoration = FindUserControl<CustomDecoration>(logicalTree, "CustomDecoration");

            customDecoration.FindControl<Control>(titleBarName).PointerPressed += (i, e) =>
            {
                @this.PlatformImpl?.BeginMoveDrag(e);
            };
            customDecoration.FindControl<Button>(minName).Click += delegate
            {
                @this.WindowState = WindowState.Minimized;
            };
            customDecoration.FindControl<Button>(maxName).Click += delegate
            {
                @this.WindowState = @this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            };
            customDecoration.FindControl<Button>(closeName).Click += delegate
            {
                @this.Close();
            };
        }
    }

}
