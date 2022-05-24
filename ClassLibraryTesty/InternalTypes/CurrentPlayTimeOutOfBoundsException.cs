using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes
{
    /// <summary>
    /// Encapuslates Exception information.
    /// </summary>
    public class CurrentPlayTimeOutOfBoundsException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message"></param>
        public CurrentPlayTimeOutOfBoundsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CurrentPlayTimeOutOfBoundsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
