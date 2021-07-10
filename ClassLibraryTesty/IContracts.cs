using System;

namespace ClassLibraryTesty
{
    namespace Contracts
    {
        //Logic Contracts
        #region LogicContracts
        public interface IMainController
        { }

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
            public void Show();

            public delegate void OnPlay();
            public delegate void OnAddSong(string path);

            public event OnPlay onPlay;
            public event OnAddSong onAddSong;
        }

        public interface ISoundControlBar
        {
            //public void Show();

            public delegate void OnPlay();

            public event OnPlay onPlay;
        }

        public interface ICustomDecoration
        {
            //public void Show();

            public delegate void OnMinimize(EventArgs args);
            public delegate void OnMaximize(EventArgs args);
            public delegate void OnClose(object args);
            public delegate void OnDrag(object sender, EventArgs args);

            public event OnMinimize onMinimize;
            public event OnMaximize onMaximize;
            public event OnClose onClose;
            public event OnDrag onDrag;
        }
        #endregion
    }
}