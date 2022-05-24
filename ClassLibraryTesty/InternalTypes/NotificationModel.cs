using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend
{
    /// <summary>
    /// Represents a notification.
    /// </summary>
    public record struct NotificationModel : IEquatable<NotificationModel>
    {
        /// <summary>
        /// The level/type of notification.
        /// </summary>
        public enum NotificationLevel
        {
            /// <summary>
            /// Informative
            /// </summary>

            Information = 0,
            /// <summary>
            /// Warns
            /// </summary>
            Warning = 1,

            /// <summary>
            /// For Errors or Fatalities
            /// </summary>
            Error = 2,
        }

        /// <summary>
        /// Title of Notification.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Message of Notification
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Represents the Type.
        /// </summary>
        public NotificationLevel Level { get; set; }
    }
}
