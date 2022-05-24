using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System.Diagnostics;
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
        {
        }

        /// <summary>
        /// Fired when a file is found.
        /// </summary>
        public event Action<string> onMediaFound;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Finds all audio files from the given root <paramref name="rootPath"/>.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        /// <returns>All valid audio files in a List of paths.</returns>
        public List<string> FindAudioFilesFromRootPath(string rootPath, List<string> validAudioFiles)
        {
            Debug.Assert(!string.IsNullOrEmpty(rootPath));
            Debug.Assert(validAudioFiles != null);
            Debug.Assert(validAudioFiles.Count > 0);

            List<string> audioFiles = new List<string>();

            try
            {
                foreach (string audioFile in validAudioFiles)
                    audioFiles.AddRange(Directory.EnumerateFiles(rootPath, "*." + audioFile, new EnumerationOptions() { RecurseSubdirectories = true, IgnoreInaccessible = true}));
            }
            catch (Exception)
            {
                throw new EnumerateFilesAbortedException(string.Format("Enumeration of files aborted in {0} after {1}", rootPath, audioFiles.Last()));
            }

            return audioFiles;
        }

        void FindAudioFilesPathAsync(string rootPath, List<string> validAudioFiles)
        {
            Debug.Assert(!string.IsNullOrEmpty(rootPath));
            Debug.Assert(validAudioFiles != null);
            Debug.Assert(validAudioFiles.Count > 0);
            Debug.Assert(_cancellationTokenSource != null);
            Debug.Assert(!_cancellationTokenSource.IsCancellationRequested);

            foreach (string audioFile in validAudioFiles)
            {
                if (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    using (var e = Directory.EnumerateFiles(rootPath, "*." + audioFile, new EnumerationOptions() { RecurseSubdirectories = true, IgnoreInaccessible = true }).GetEnumerator())
                    {
                        while (e.MoveNext())
                        {
                            onMediaFound.Invoke(e.Current);
                        }
                    }
                }
                else
                    return;
            }
        }

        /// <summary>
        /// Finds all audio files from the given root <paramref name="rootPath"/>.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        public void FindAudioFilesFromRootPathAsync(string rootPath, List<string> validAudioFiles)
        {
            Debug.Assert(!string.IsNullOrEmpty(rootPath));
            Debug.Assert(validAudioFiles != null);
            Debug.Assert(validAudioFiles.Count > 0);
            Debug.Assert(_cancellationTokenSource != null);
            Debug.Assert(!_cancellationTokenSource.IsCancellationRequested);

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            
            FindAudioFilesPathAsync(rootPath, validAudioFiles);
        }
    }
}