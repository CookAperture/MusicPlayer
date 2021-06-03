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
            public delegate void OnInit();
        }

        public interface IMusicPlayerInteractor //may use sound api here
        {
            //Play
            //LoadFile

            //event file loaded -> metadata 
        }
        #endregion

        #region UIContracts
        //UI Contracts
        public interface IMainUI
        {
            public delegate void OnPlay();
            public delegate void OnAddSong(string path);

            public event OnPlay onPlay;
            public event OnAddSong onAddSong;
        }
        #endregion
    }
}
