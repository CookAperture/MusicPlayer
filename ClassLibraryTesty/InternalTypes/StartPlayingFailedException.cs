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
    public class StartPlayingFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartPlayingFailedException"/> class.
        /// </summary>
        /// <param name="msg"></param>
        public StartPlayingFailedException(string msg)
            : base(msg)
        { }
    }
}
