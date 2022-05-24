using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts for Displaying a Notification.
    /// </summary>
    public interface INotifyUI
    {
        /// <summary>
        /// Displays a notification on the UI.
        /// </summary>
        public void Notify(NotificationModel message);
    }
}
