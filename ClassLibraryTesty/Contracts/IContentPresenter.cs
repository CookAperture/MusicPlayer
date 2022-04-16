using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to communicate with ContentPresenter.
    /// </summary>
    public interface IContentPresenter
    {

        /// <summary>
        /// Holding the SongCover UI element.
        /// </summary>
        public ISongCover SongCover { get; set; }

        /// <summary>
        /// Holding the Settings UI element.
        /// </summary>
        public ISettings Settings { get; set; }

        /// <summary>
        /// Holding the MediaList UI element.
        /// </summary>
        public IMediaList MediaList { get; set; }

        /// <summary>
        /// Shows the SongCover.
        /// </summary>
        public void ShowCoverPage();

        /// <summary>
        /// Shows the Settings.
        /// </summary>
        public void ShowSettingsPage();

        /// <summary>
        /// Shows the MediaList.
        /// </summary>
        public void ShowMediaListPage();
    }
}
