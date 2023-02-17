using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts the neccessary functions to handle a file system.
/// </summary>
public interface IFileSystemHandler
{
    /// <summary>
    /// </summary>
    public event Action<string> onMediaFound;

    /// <summary>
    /// Describes the neccessary input and output to fetch audio file paths from a root.
    /// </summary>
    /// <param name="rootPath">The root path.</param>
    /// <param name="validAudioFiles">The valid file endings.</param>
    /// <returns>All valid audio files in a List of paths.</returns>
    public List<string> FindAudioFilesFromRootPath(string rootPath, List<string> validAudioFiles);

    /// <summary>
    /// Describes the neccessary input and output to fetch audio file paths from a root.
    /// </summary>
    /// <param name="rootPath">The root path.</param>
    /// <param name="validAudioFiles">The valid file endings.</param>
    public void FindAudioFilesFromRootPathAsync(string rootPath, List<string> validAudioFiles);
}