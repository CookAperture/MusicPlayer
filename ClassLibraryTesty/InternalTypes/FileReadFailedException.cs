using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    /// <summary>
    /// Encapsulates Exception Data.
    /// </summary>
    public class FileReadFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileReadFailedException"/> class.
        /// </summary>
        /// <param name="message"></param>
        public FileReadFailedException(string message) : base(message)
        {
        }
    }
}
