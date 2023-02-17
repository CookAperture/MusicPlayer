using Avalonia.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicPlayer;
public class NotifyUserControl : UserControl, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;
    protected bool RaiseAndSetIfChanged<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(field, value))
        {
            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
        return false;
    }

    private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}