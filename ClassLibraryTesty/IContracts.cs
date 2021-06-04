using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTesty
{
    namespace Contracts
    {
        //Logic Contracts
        #region LogicContracts
        public interface IMainController
        {

        }

        public interface IMusicPlayerInteractor //may use sound api here
        {
            public void PlaySong();
            public void AddSong(string path);

            public delegate void OnSongAdded(SongMetaData meta);

            public event OnSongAdded onSongAdded;
        }
        #endregion

        #region UIContracts
        //UI Contracts
        public interface IMainUI
        {
            public void OnSongAdded(SongMetaData meta);

            public delegate void OnPlay();
            public delegate void OnAddSong(string path);

            public event OnPlay onPlay;
            public event OnAddSong onAddSong;
        }
        #endregion
    }
}
