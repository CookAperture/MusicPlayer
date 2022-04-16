using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend
{
    public record struct NotificationModel : IEquatable<NotificationModel>
    {
        public enum NotificationLevel
        {
            Information = 0,
            Warning = 1,
            Error = 2,
        }

        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationLevel Level { get; set; }
    }
}
