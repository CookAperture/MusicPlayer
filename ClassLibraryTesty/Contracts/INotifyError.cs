using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts for firing ErrorNotifications.
/// </summary>
public interface INotifyError
{
    /// <summary>
    /// Fires an ErrorNotification.
    /// </summary>
    public event Action<NotificationModel> onError;
}