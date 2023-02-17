using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts the neccessary functions to allow writing content to an file.
/// </summary>
public interface IFileWriter
{
    /// <summary>
    /// Describes that <paramref name="text"/> is written to file at <paramref name="path"/>.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="path"></param>
    public void Write(string text, string path);
}