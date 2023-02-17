using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes;
/// <summary>
/// Encapulates Exception Data.
/// </summary>
public class ReadAudioMetaDataFailedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReadAudioMetaDataFailedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public ReadAudioMetaDataFailedException(string message) : base(message)
    {
    }
}