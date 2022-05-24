using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts to connect <see cref="IMetaDataReader"/> with <see cref="IFileSystemHandler"/>.
    /// </summary>
    public interface IMediaListInteractor
    {
        /// <summary>
        /// </summary>
        public event Action<AudioMetaData> onMediaFound;

        /// <summary>
        /// Contracts to fetch all audio files recursivly from a root dir.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns>List of <see cref="AudioMetaData"/> from all found media files.</returns>
        public void GetMediaListAsync(string rootPath);
    }
}
