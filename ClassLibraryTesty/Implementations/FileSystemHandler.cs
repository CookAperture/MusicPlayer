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

        public event Action<string> onMediaFound;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private TaskFactory _taskFactory = new TaskFactory();

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

        async void FindAudioFilesPathAsync(string rootPath, List<string> validAudioFiles)
        {
            Debug.Assert(!string.IsNullOrEmpty(rootPath));
            Debug.Assert(validAudioFiles != null);
            Debug.Assert(validAudioFiles.Count > 0);
            Debug.Assert(_cancellationTokenSource != null);
            Debug.Assert(!_cancellationTokenSource.IsCancellationRequested);

            try
            {
                foreach (string audioFile in validAudioFiles)
                {
                    if (!_cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        using (var e = await Task.Run(() => Directory.EnumerateFiles(rootPath, "*." + audioFile, new EnumerationOptions() { RecurseSubdirectories = true, IgnoreInaccessible = true }).GetEnumerator(), _cancellationTokenSource.Token))
                        {
                            while (await Task.Run(() => e.MoveNext(), _cancellationTokenSource.Token))
                            {
                                await Task.Run(() => onMediaFound.Invoke(e.Current), _cancellationTokenSource.Token);
                            }
                        }
                    }
                    else
                        return;
                }
            }
            catch (Exception)
            {
                throw new EnumerateFilesAbortedException(string.Format("Enumeration of files aborted in {0}", rootPath));
            }
        }

        /// <summary>
        /// Finds all audio files from the given root <paramref name="rootPath"/>.
        /// </summary>
        /// <param name="rootPath">The root path.</param>
        /// <param name="validAudioFiles">The valid file endings.</param>
        public async void FindAudioFilesFromRootPathAsync(string rootPath, List<string> validAudioFiles)
        {
            Debug.Assert(!string.IsNullOrEmpty(rootPath));
            Debug.Assert(validAudioFiles != null);
            Debug.Assert(validAudioFiles.Count > 0);
            Debug.Assert(_cancellationTokenSource != null);
            Debug.Assert(!_cancellationTokenSource.IsCancellationRequested);

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            await _taskFactory.StartNew(() => FindAudioFilesPathAsync(rootPath, validAudioFiles), _cancellationTokenSource.Token);
        }
    }
}