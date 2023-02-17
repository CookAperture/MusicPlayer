using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes;
/// <summary>
/// Encapsulates Exception Data.
/// </summary>
[System.Serializable]
public class FileWriteFailedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FileWriteFailedException"/> class.
    /// </summary>
    public FileWriteFailedException() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileWriteFailedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public FileWriteFailedException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileWriteFailedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    public FileWriteFailedException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileWriteFailedException"/> class.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected FileWriteFailedException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}