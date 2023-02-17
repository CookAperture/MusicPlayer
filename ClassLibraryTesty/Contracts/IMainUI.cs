using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts the neccessary functions to communicate with the main window.
/// </summary>
public interface IMainUI
{
    /// <summary>
    /// To be invoked by settings.
    /// </summary>
    public event Action<APPLICATION_STYLE> onThemeChange;

    /// <summary>
    /// Represents a custom subwindow, it replaces the os decoration. 
    /// </summary>
    public ICustomDecoration CustomDecoration { get; set; }

    /// <summary>
    /// Represents a custom subwindow, enables controll over the playing, pausing and more adjustments. 
    /// </summary>
    public ISoundControlBar SoundControlBar { get; set; }

    /// <summary>
    /// Represents a custom subwindow, handles the content of settings, medialist and the song cover.
    /// </summary>
    public IContentPresenter ContentPresenter { get; set; }

    /// <summary>
    /// Contracts to show the window.
    /// </summary>
    public void Show();
}