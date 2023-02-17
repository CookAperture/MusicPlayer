using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.InternalTypes;
/// <summary>
/// Encapsulates Exception Data.
/// </summary>
public class EnumerateFilesAbortedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerateFilesAbortedException"/> class.
    /// </summary>
    public EnumerateFilesAbortedException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerateFilesAbortedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public EnumerateFilesAbortedException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerateFilesAbortedException"/> class.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    public EnumerateFilesAbortedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}