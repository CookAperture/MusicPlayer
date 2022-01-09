using System;
using System.Collections.Generic;

namespace MusicPlayerBackend
{
    namespace Contracts
    {

        /// <summary>
        /// Contracts the neccesary functions to communicate with it's subcomponents and vice versa.
        /// </summary>
        public interface IApplication
        {
            /// <summary>
            /// Communicates to the App to set the <paramref name="appStyle"/> predefined in <see cref="APPLICATION_STYLE"/>.
            /// </summary>
            /// <param name="appStyle"></param>
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

        /// <summary>
        /// Contracts the neccessary functions to read a audio meta data struct from files.
        /// </summary>
        public interface IMetaDataReader
        {

            /// <summary>
            /// Communicates that <paramref name="path"/> is used to obtain an <see cref="AudioMetaData"/>.
            /// </summary>
            /// <param name="path"></param>
            /// <returns>Should return an correctly filled <see cref="AudioMetaData"/> struct.</returns>
            public AudioMetaData ReadMetaDataFromFile(string path);
        }

        /// <summary>
        /// Contracts the neccessary functions and events
        /// to ensure communication with the specific implementation of an sound handler
        /// to other components that might want to work with audio file.
        /// </summary>
        public interface ISoundEngine
        {
            /// <summary>
            /// Defines the delegation for an update of any replay progress.
            /// </summary>
            /// <param name="current">
            /// Contains the value of the passed time of the replay.
            /// </param>
            public delegate void OnUpdatePlayProgress(TimeSpan current);

            /// <summary>
            /// Defines the delegation for an notification that a replay has finished on it self.
            /// </summary>
            public delegate void OnAudioFileFinished();

            /// <summary>
            /// Declares the must that an event exists in any implementation of <see cref="ISoundEngine"/>.
            /// The use of it is not guranteed, but advised.
            /// </summary>
            public event OnUpdatePlayProgress onUpdatePlayProgress;

            /// <summary>
            /// Declares the must that an event exists in any implementation of <see cref="ISoundEngine"/>.
            /// The use of it is not guranteed, but advised.
            /// </summary>
            public event OnAudioFileFinished onAudioFileFinished;

            /// <summary>
            /// Communicates the <paramref name="device"/> to be used. 
            /// </summary>
            /// <param name="device"></param>
            public void SetAudioDevice(string device);

            /// <summary>
            /// Communicates the audio devices an <see cref="ISoundEngine"/> implementation can find.
            /// </summary>
            /// <returns> List of device names.</returns>
            public List<string> GetAudioDevices();

            /// <summary>
            /// Communicates the current set audio device.
            /// </summary>
            /// <returns>Name of current device.</returns>
            public string GetCurrentAudioDevice();

            /// <summary>
            /// Communicates to start playing the given audio file via <paramref name="audioMetaData"/>.
            /// </summary>
            /// <param name="audioMetaData"><inheritdoc cref="AudioMetaData"/></param>
            public void StartPlaying(AudioMetaData audioMetaData);

            /// <summary>
            /// Communicates to stop playing current audio file.
            /// </summary>
            public void StopPlaying();

            /// <summary>
            /// Communicates to resume playing the current audio file.
            /// </summary>
            public void ResumePlaying();
        }

        /// <summary>
        /// Contracts the neccessary functions
        /// to conversio from Models to Structs and vice vers as well as convert any other complex type into another needed.
        /// </summary>
        public interface IDataConverter
        { }

        /// <summary>
        /// Contracts the neccessary functions to allow serialization of objects.
        /// </summary>
        public interface IJSONSerializer
        {

            /// <summary>
            /// Describes the neccessary input and output for serialization.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="serializable"></param>
            /// <returns>Should be an representation of the object as <see cref="string"/>.</returns>
            public string Serialize<T>(T serializable); 
        }

        /// <summary>
        /// Contracts the neccessary functions to allow deserializing of objects.
        /// </summary>
        public interface IJSONDeserializer
        {

            /// <summary>
            /// Describes the neccessary input and output for deserialization.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="deserializable"></param>
            /// <returns>Should be an representation of the string as <typeparamref name="T"/>.</returns>
            public T Deserialize<T>(string deserializable);
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