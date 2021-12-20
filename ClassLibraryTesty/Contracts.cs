using System;

namespace ClassLibraryTesty
{
    namespace Contracts
    {

        public interface IApplication
        {
            public void SetStyle(APPLICATION_STYLE appStyle);
        }

        //Logic Contracts
        #region LogicContracts
        public interface IMainController
        { }
        public interface ICustomDecorationController
        { }
        public interface ISoundControlBarController
        {
            public void UpdateInformation(/*List<MetaDaten>*/);
            public delegate void OnPlay(string name);
            public delegate void OnSkip();
            public delegate void ScrubTo(TimeSpan time);
        }
        public interface IContentPresenterController
        { }
        public interface ISettingsController
        { }
        public interface ISongCoverController
        { }

        public interface IMediaListController
        { }

        public interface IAudioFileInteractor
        {
            public void StartPlaying(string path);
            public void StartPlayingAt(TimeSpan time);
            public void SkipTo(int seconds);
            public void StopPlaying();
            public void ResumePlaying();
            public void /*MetaDataStruct*/ ReadMetaDataFromFile(string path);
        }

        public interface ISettingsInteractor
        {
            public void WriteSettings(/*SettingsStruct*/);
            public void /*SettingsStruct*/ ReadSettings();
        }

        public interface IMediaListInteractor
        { }

        public interface IMetaDataReader
        {
            //experiment first
            public void /*MetaDataStruct*/ ReadMetaData(string path);
        }

        public interface ISoundEngine
        {
            //experiment first
            public void StartPlaying(string path);
            public void StopPlaying();
            public void ResumePlaying();

            //event asking for metadata (maybe just the duration?)
        }

        public interface IDataConverter
        { }

        public interface IJSONSerializer
        { }

        public interface IJSONDeserializer
        { }

        public interface IFileWriter
        { }

        public interface IFileReader
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
        }

        public interface ISoundControlBar
        {
            public delegate void OnPlay();

            public event OnPlay onPlay;
        }

        public interface ICustomDecoration
        {
            public delegate void OnMinimize(EventArgs args);
            public delegate void OnMaximize(EventArgs args);
            public delegate void OnClose(object args);
            public delegate void OnDrag(object sender, EventArgs args);
            public delegate void OnCoverButtonClick();
            public delegate void OnSettingsButtonClick();
            public delegate void OnMediaListButtonClick();

            public event OnMinimize onMinimize;
            public event OnMaximize onMaximize;
            public event OnClose onClose;
            public event OnDrag onDrag;
            public event OnCoverButtonClick onCoverButtonClick;
            public event OnSettingsButtonClick onSettingsButtonClick;
            public event OnMediaListButtonClick onMediaListButtonClick;
        }

        public interface ISongCover
        {
            public void LoadCover(/*Image*/);
        }

        public interface ISettings
        {

            public delegate void OnSettingsChanged(/*SettingsStruct*/);
            public delegate void OnChangeTheme(APPLICATION_STYLE theme);

            //public event OnSettingsChanged onSettingsChanged;
            //public event OnChangeTheme onChangeTheme;

            public void LoadSettings(/*SettingsStruct*/);
        }

        public interface IContentPresenter
        {
            public ISongCover SongCover { get; set; }
            public ISettings Settings { get; set; }
            public IMediaList MediaList { get; set; }

            public void ShowCoverPage();
            public void ShowSettingsPage();
            public void ShowMediaListPage();
        }

        public interface IMediaList
        {
            public delegate void OnSelection(/*MediaListStruct*/);

            public event OnSelection onSelection;

            public void SetList(/*MediaListStruct*/);
            public void SetPlaying(/*SongIdentifier*/);
        }
        #endregion
    }
}