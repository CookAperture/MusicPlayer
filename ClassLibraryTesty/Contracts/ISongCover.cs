using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to communicate with SongCover.
    /// </summary>
    public interface ISongCover
    {

        /// <summary>
        /// Contracts the OnLoad event interface.
        /// </summary>
        /// <param name="audioMetaData"></param>
        public delegate void OnLoad(AudioMetaData audioMetaData);

        /// <summary>
        /// Contracts availability of onLoad event for ISongCover.
        /// </summary>
        public event OnLoad onLoad;

        /// <summary>
        /// Should pass an image of the audio file cover.
        /// </summary>
        public void LoadCover(AudioMetaData audioMetaData);

        /// <summary>
        /// Contracts to load the cover image to the ui.
        /// </summary>
        /// <param name="imageContainer"></param>
        public Task LoadCover(ImageContainer imageContainer);
    }
}
