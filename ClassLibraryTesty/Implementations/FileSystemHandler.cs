using MusicPlayerBackend.Contracts;
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

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private TaskFactory _taskFactory = new TaskFactory();

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
            Debug.Assert(!string.IsNullOrEmpty(rootPath));
            Debug.Assert(validAudioFiles != null);
            Debug.Assert(validAudioFiles.Count > 0);

            List<string> audioFiles = new List<string>();

            foreach (string audioFile in validAudioFiles)
                audioFiles.AddRange(Directory.EnumerateFiles(rootPath, "*." + audioFile, SearchOption.AllDirectories));

            return audioFiles;
        }

        async void FindAudioFilesPathAsync(string rootPath, List<string> validAudioFiles)
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
                    using (var e = await Task.Run(() => Directory.EnumerateFiles(rootPath, "*." + audioFile, SearchOption.AllDirectories).GetEnumerator(), _cancellationTokenSource.Token))
                    {
                        while (await Task.Run(() => e.MoveNext(), _cancellationTokenSource.Token))
                        {
                            await Task.Run(() => onMediaFound.Invoke(e.Current), _cancellationTokenSource.Token);

                            Logger.Log(LogSeverity.Debug, this, "Invoked " + e.Current);
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