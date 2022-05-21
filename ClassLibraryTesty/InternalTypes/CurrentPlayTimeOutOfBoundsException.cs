using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    public class CurrentPlayTimeOutOfBoundsException : Exception
    {
        public CurrentPlayTimeOutOfBoundsException(string message)
            : base(message)
        {
        }

        public CurrentPlayTimeOutOfBoundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
