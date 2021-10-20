using System;

namespace ClassLibraryTesty
{
    namespace Contracts
    {
        //Logic Contracts
        #region LogicContracts
        public interface IMainController
        { }
        public interface ICustomDecorationController
        { }
        public interface ISoundControlBarController
        { }
        public interface IContentPresenterController
        { }
        public interface ISettingsController
        { }
        public interface ISongCoverController
        { }
        #endregion

        #region UIContracts
        //UI Contracts
        public interface IMainUI
        {
            public ICustomDecoration CustomDecoration { get; set; }
            public ISoundControlBar SoundControlBar { get; set; }
            public IContentPresenter ContentPresenter { get; set; }

            public void Show();

            public delegate void OnPlay();

            public event OnPlay onPlay;
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
            public delegate void OnCoverButtonClick();
            public delegate void OnSettingsButtonClick();

            public event OnMinimize onMinimize;
            public event OnMaximize onMaximize;
            public event OnClose onClose;
            public event OnDrag onDrag;
            public event OnCoverButtonClick onCoverButtonClick;
            public event OnSettingsButtonClick onSettingsButtonClick;
        }

        public interface ISongCover
        {
            public void LoadCover(/* send img here */);
        }

        public interface ISettings
        {

            //public delegate void OnSettingsChanged(EventArgs args);
            //public event OnSettingsChanged onSettingsChanged;

            public void LoadSettings(/* send settings here */);
        }

        public interface IContentPresenter
        {
            public ISongCover SongCover { get; set; }
            public ISettings Settings { get; set; }

            public void ShowCoverPage();
            public void ShowSettingsPage();
        }
        #endregion
    }
}