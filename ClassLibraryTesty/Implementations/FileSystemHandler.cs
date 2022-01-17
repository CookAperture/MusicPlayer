using MusicPlayerBackend.Contracts;
using System.IO;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements the interface <see cref="IFileSystemHandler"/>.
    /// </summary>
    public class FileSystemHandler : IFileSystemHandler
    {
        /// <summary>
        /// Acquires all neccessary resources to go through a file system.
        /// </summary>
        public FileSystemHandler()
        { }

        /// <summary>
        /// Gets called when <see cref="FindAudioFilesFromRootPathAsync(string, List{string})"/> is used for every found media file.
        /// </summary>
        public event IFileSystemHandler.OnMediaFound onMediaFound;

        /// <summary>
        /// Finds all audio files from the given root <paramref name="rootPath"/>.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        /// <returns>All valid audio files in a List of paths.</returns>
        public List<string> FindAudioFilesFromRootPath(string rootPath, List<string> validAudioFiles)
        {
            List<string> audioFiles = new List<string>();

            foreach (string audioFile in validAudioFiles)
                audioFiles.AddRange(Directory.EnumerateFiles(rootPath, "*." + audioFile, SearchOption.AllDirectories));

            return audioFiles;
        }

        /// <summary>
        /// Finds all audio files from the given root <paramref name="rootPath"/>.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        public void FindAudioFilesFromRootPathAsync(string rootPath, List<string> validAudioFiles)
        {
            foreach (string audioFile in validAudioFiles)
                foreach (var mediafile in Directory.EnumerateFiles(rootPath, "*." + audioFile, SearchOption.AllDirectories))
                    onMediaFound.Invoke(mediafile);
        }
    }
}