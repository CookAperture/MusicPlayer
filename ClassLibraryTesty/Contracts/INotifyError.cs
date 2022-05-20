using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    public interface INotifyError
    {
        public event Action<NotificationModel> onError;
    }
}
