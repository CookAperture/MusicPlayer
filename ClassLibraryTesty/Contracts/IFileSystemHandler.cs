using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to handle a file system.
    /// </summary>
    public interface IFileSystemHandler
    {

        /// <summary>
        /// To be called with each found media. 
        /// </summary>
        /// <param name="mediafile"></param>
        public delegate void OnMediaFound(string mediafile);

        /// <summary>
        /// <see cref="OnMediaFound"/>
        /// </summary>
        public event OnMediaFound onMediaFound;

        /// <summary>
        /// Describes the neccessary input and output to fetch audio file paths from a root.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        /// <returns>All valid audio files in a List of paths.</returns>
        public List<string> FindAudioFilesFromRootPath(string rootPath, List<string> validAudioFiles);

        /// <summary>
        /// Describes the neccessary input and output to fetch audio file paths from a root. Calls <see cref="OnMediaFound"/> for every found media.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        public void FindAudioFilesFromRootPathAsync(string rootPath, List<string> validAudioFiles);
    }
}
