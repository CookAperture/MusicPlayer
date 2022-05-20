using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to communicate with MediaList
    /// </summary>
    public interface IMediaList
    {
        /// <summary>
        /// To be invoked upon selection and selection changes.
        /// </summary>
        public event Action<AudioMetaData> onSelection;

        /// <summary>
        /// To be invoked by content presenter.
        /// </summary>
        public event Func<Task> onLoadMediaList;

        /// <summary>
        /// To be invoked on changed settings.
        /// </summary>
        public event Func<string, Task> onLoadMediaListFromNewPath;

        /// <summary>
        /// Sets the media list content.
        /// </summary>
        /// <param name="song"></param>
        public void AddSongToList(AudioMetaData song);

        /// <summary>
        /// Marks the actually playing file.
        /// </summary>
        /// <param name="selection"></param>
        public void SetPlaying(AudioMetaData selection);

        /// <summary>
        /// Contracts to load the media list data.
        /// </summary>
        public void LoadMediaList();

        /// <summary>
        /// Contracts to fetch a new media path.
        /// </summary>
        /// <param name="path"></param>
        public void LoadMediaListFromNewMediaPath(string path);
    }
}
