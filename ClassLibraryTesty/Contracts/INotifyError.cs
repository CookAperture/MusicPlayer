using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    public interface INotifyError
    {
        public delegate void Error(NotificationModel notificationModel);

        public event Error onError;
    }
}
