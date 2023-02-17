using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes;
/// <summary>
/// Encapsulates Exception Data.
/// </summary>
public class SoundEngineInitFailedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SoundEngineInitFailedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public SoundEngineInitFailedException(string message) : base(message)
    {
    }
}