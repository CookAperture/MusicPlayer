using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    public class ReadAudioMetaDataFailedException : Exception
    {
        public ReadAudioMetaDataFailedException(string message) : base(message)
        {
        }
    }
}
