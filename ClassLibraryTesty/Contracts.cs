using System;
using System.Collections.Generic;

namespace MusicPlayerBackend
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
        {
            public void ChangeTheme(APPLICATION_STYLE appStyle);
        }
        public interface ICustomDecorationController
        {
            public delegate void OnSwitchedToSettings();
            public delegate void OnSwitchedToCover();
            public delegate void OnSwitchedToMediaList();

            public event OnSwitchedToSettings onSwitchedToSettings;
            public event OnSwitchedToCover onSwitchedToCover;
            public event OnSwitchedToMediaList onSwitchedToMediaList;

            //SafeActualSongOnExit -> OnExit event
        }
        public interface ISoundControlBarController
        {
            public void UpdateInformation();

            public delegate void OnPlay(string name);
            public delegate void OnSkipForward();
            public delegate void OnSkipBackward();
            public delegate void ScrubTo(TimeSpan time);

            public event OnPlay onPlay;
            public event OnSkipForward onSkipForward;
            public event OnSkipBackward onSkipBackward;
            public event ScrubTo onScrubTo;
        }
        public interface IContentPresenterController
        { }
        public interface ISettingsController
        {
            public delegate void OnChangeTheme(APPLICATION_STYLE appStyle);

            public event OnChangeTheme onChangeTheme;

            public void LoadSettings();
        }
        public interface ISongCoverController
        {
            public void SetCover(/*Image*/);
        }

        public interface IMediaListController
        {
            public delegate void OnAudioSelected(AudioMetaData selected);

            public event OnAudioSelected onAudioSelected;
            public void SetMediaList(List<AudioMetaData> audioMetaDatas);
        }

        public interface IAudioFileInteractor
        {
            public void StartPlaying();
            public void StartPlayingAt(TimeSpan time);
            public void SkipTo(int seconds);
            public void StopPlaying();
            public void ResumePlaying();
            public void SetActualAudioFile(string path);
            public AudioMetaData ReadMetaDataFromActualAudio();
        }

        public interface ISettingsInteractor
        {
            public void WriteSettings(AppSettings appSettings);
            public AppSettings ReadSettings();
        }

        public interface IMediaListInteractor
        {
            public delegate void OnMediaFound(AudioMetaData audioMetaData);

            public event OnMediaFound onMediaFound;
            public List<AudioMetaData> GetMediaList(string rootPath);
        }

        public interface IFileSystemHandler
        {
            public List<string> FindAudioFilesFromRootPath(string rootPath);
        }

        public interface IMetaDataReader
        {
            public AudioMetaData ReadMetaDataFromFile(string path);
        }

        public interface ISoundEngine
        {
            public void SetAudioDevice(string device);
            public List<string> GetAudioDevices();
            public string GetAudioDevice();
            public void StartPlaying(AudioMetaData audioMetaData);
            public void StopPlaying();
            public void ResumePlaying();
        }

        public interface IDataConverter
        { }

        public interface IJSONSerializer
        {
            public string Serialize<T>(T serializable); 
        }

        public interface IJSONDeserializer
        {
            public T Serialize<T>(string deserializable);
        }

        public interface IFileWriter
        {
            public void Write(string text, string path);
        }

        public interface IFileReader
        {
            public string ReadWhole(string path);
            public List<string> ReadAllLines(string path);
        }
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
            public delegate void OnPause();

            public event OnPlay onPlay;
            public event OnPause onPause;

            public void SetAudioMetaData(AudioMetaData audioMetaData);
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

            public delegate void OnSettingsChanged(AppSettings appSettings);
            public delegate void OnChangeTheme(APPLICATION_STYLE theme);

            public event OnSettingsChanged onSettingsChanged;
            public event OnChangeTheme onChangeTheme;

            public void LoadSettings(AppSettings appSettings);
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
            public delegate void OnSelection(AudioMetaData selection);

            public event OnSelection onSelection;

            public void SetList(List<AudioMetaData> mediaList);
            public void SetPlaying(AudioMetaData selection);
        }
        #endregion
    }
}