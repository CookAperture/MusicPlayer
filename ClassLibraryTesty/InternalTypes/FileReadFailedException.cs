using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    public class FileReadFailedException : Exception
    {
        public FileReadFailedException(string message) : base(message)
        {
        }
    }
}
