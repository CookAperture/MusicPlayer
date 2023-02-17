using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System.Diagnostics;

namespace MusicPlayerBackend.Implementations;
/// <summary>
/// Implements <see cref="IFileWriter"/>.
/// </summary>
public class FileWriter : IFileWriter
{

    /// <summary>
    /// Accquires neccessary resources to write data to an file;
    /// </summary>
    public FileWriter()
    {
    }

    /// <summary>
    /// Writes <paramref name="text"/> to an file at <paramref name="path"/>.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="path"></param>
    public void Write(string text, string path)
    {
        Debug.Assert(text != null);
        Debug.Assert(path != null);

        try
        {
            File.WriteAllText(path, text);
        }
        catch (Exception)
        {
            throw new FileWriteFailedException(string.Format("Could not write to file at path: {0}", path));
        } 
    }
}