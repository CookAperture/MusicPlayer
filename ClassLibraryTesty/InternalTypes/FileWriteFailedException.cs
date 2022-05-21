using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    [System.Serializable]
    public class FileWriteFailedException : Exception
    {
        public FileWriteFailedException() { }
        public FileWriteFailedException(string message) : base(message) { }
        public FileWriteFailedException(string message, Exception inner) : base(message, inner) { }
        protected FileWriteFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
