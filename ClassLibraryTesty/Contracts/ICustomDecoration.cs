using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts the neccessary functions to communicate with the custom decoration.
/// </summary>
public interface ICustomDecoration
{
    /// <summary>
    /// To be invoked when minimize is triggered.
    /// </summary>
    public event Action<EventArgs> onMinimize;

    /// <summary>
    /// To be invoked when maximize is triggered.
    /// </summary>
    public event Action<EventArgs> onMaximize;

    /// <summary>
    /// To be invoked when close is triggered.
    /// </summary>
    public event Action<object> onClose;

    /// <summary>
    /// To be invoked when drag is triggered.
    /// </summary>
    public event Action<object, EventArgs> onDrag;
}