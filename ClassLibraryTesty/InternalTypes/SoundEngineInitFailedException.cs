using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    public class SoundEngineInitFailedException : Exception
    {
        public SoundEngineInitFailedException(string message) : base(message)
        {
        }
    }
}
