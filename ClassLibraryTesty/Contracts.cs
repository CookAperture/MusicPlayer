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

        /// <summary>
        /// Contracts the neccessary functions to handle a file system.
        /// </summary>
        public interface IFileSystemHandler
        {

            /// <summary>
            /// Describes the neccessary input and output to fetch audio file paths from a root.
            /// </summary>
            /// <param name="rootPath">The root path.</param>
            /// <param name="validAudioFiles">The valid file endings.</param>
            /// <returns>All valid audio files in a List of paths.</returns>
            public List<string> FindAudioFilesFromRootPath(string rootPath, List<string> validAudioFiles);
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

        /// <summary>
        /// Contracts the neccessary functions to allow writing content to an file.
        /// </summary>
        public interface IFileWriter
        {
            /// <summary>
            /// Describes that <paramref name="text"/> is written to file at <paramref name="path"/>.
            /// </summary>
            /// <param name="text"></param>
            /// <param name="path"></param>
            public void Write(string text, string path);
        }

        /// <summary>
        /// Contracts the neccessary functions to allow reading content from an file.
        /// </summary>
        public interface IFileReader
        {

            /// <summary>
            /// Describes the neccessary input and output to read a file as whole.
            /// </summary>
            /// <param name="path"></param>
            /// <returns>Single <see cref="string"/> containing a file formatted as text.</returns>
            public string ReadWhole(string path);

            /// <summary>
            /// Describes the neccessary input and output to read a file line by line.
            /// </summary>
            /// <param name="path"></param>
            /// <returns>List of <see cref="string"/> each representing one single line of the file.</returns>
            public List<string> ReadAllLines(string path);
        }
        #endregion

        #region UIContracts
        //UI Contracts

        /// <summary>
        /// Contracts the neccessary functions to communicate with the main window.
        /// </summary>
        public interface IMainUI
        {

            /// <summary>
            /// Represents a custom subwindow, it replaces the os decoration. 
            /// </summary>
            public ICustomDecoration CustomDecoration { get; set; }

            /// <summary>
            /// Represents a custom subwindow, enables controll over the playing, pausing and more adjustments. 
            /// </summary>
            public ISoundControlBar SoundControlBar { get; set; }

            /// <summary>
            /// Represents a custom subwindow, handles the content of settings, medialist and the song cover.
            /// </summary>
            public IContentPresenter ContentPresenter { get; set; }

            /// <summary>
            /// Contracts to show the window.
            /// </summary>
            public void Show();
        }

        /// <summary>
        /// Contracts the neccessary functions to communicate with the sound controll bar and affect audio directly.
        /// </summary>
        public interface ISoundControlBar
        {

            /// <summary>
            /// No return on play and without parameters.
            /// </summary>
            public delegate void OnPlay();

            /// <summary>
            /// No return on pause and without parameters.
            /// </summary>
            public delegate void OnPause();

            /// <summary>
            /// To be invoked when user triggers play.
            /// </summary>
            public event OnPlay onPlay;

            /// <summary>
            /// To be invoked when user triggers pause.
            /// </summary>
            public event OnPause onPause;

            /// <summary>
            /// Contracts that the meta data from an audio file fills the content fields of this controll.
            /// </summary>
            /// <param name="audioMetaData"></param>
            public void SetAudioMetaData(AudioMetaData audioMetaData);
        }

        /// <summary>
        /// Contracts the neccessary functions to communicate with the custom decoration.
        /// </summary>
        public interface ICustomDecoration
        {
            /// <summary>
            /// Interfaces minimize event data.
            /// </summary>
            /// <param name="args"></param>
            public delegate void OnMinimize(EventArgs args);

            /// <summary>
            /// Interfaces maximize event data.
            /// </summary>
            /// <param name="args"></param>
            public delegate void OnMaximize(EventArgs args);

            /// <summary>
            /// Interfaces close event data.
            /// </summary>
            /// <param name="args"></param>
            public delegate void OnClose(object args);

            /// <summary>
            /// Interfaces dragging event data.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            public delegate void OnDrag(object sender, EventArgs args);

            /// <summary>
            /// Interfaces no event data.
            /// </summary>
            public delegate void OnCoverButtonClick();

            /// <summary>
            /// Interfaces no event data.
            /// </summary>
            public delegate void OnSettingsButtonClick();

            /// <summary>
            /// Interfaces no event data.
            /// </summary>
            public delegate void OnMediaListButtonClick();

            /// <summary>
            /// To be invoked when minimize is triggered.
            /// </summary>
            public event OnMinimize onMinimize;

            /// <summary>
            /// To be invoked when maximize is triggered.
            /// </summary>
            public event OnMaximize onMaximize;

            /// <summary>
            /// To be invoked when close is triggered.
            /// </summary>
            public event OnClose onClose;

            /// <summary>
            /// To be invoked when drag is triggered.
            /// </summary>
            public event OnDrag onDrag;

            /// <summary>
            /// To be invoked when cover button is triggered.
            /// </summary>
            public event OnCoverButtonClick onCoverButtonClick;

            /// <summary>
            /// To be invoked when settings button is triggered.
            /// </summary>
            public event OnSettingsButtonClick onSettingsButtonClick;

            /// <summary>
            /// To be invoked when medialist button is triggered.
            /// </summary>
            public event OnMediaListButtonClick onMediaListButtonClick;
        }

        /// <summary>
        /// Contracts the neccessary functions to communicate with SongCover.
        /// </summary>
        public interface ISongCover
        {

            /// <summary>
            /// Should pass an image of the audio file cover.
            /// </summary>
            public void LoadCover(/*Image*/);
        }

        /// <summary>
        /// Contracts the neccessary functions to communicate with Settings.
        /// </summary>
        public interface ISettings
        {

            /// <summary>
            /// Interfaces settings changed event data.
            /// </summary>
            /// <param name="appSettings"></param>
            public delegate void OnSettingsChanged(AppSettings appSettings);

            /// <summary>
            /// Interfaces theme changed event data.
            /// </summary>
            /// <param name="theme"></param>
            public delegate void OnChangeTheme(APPLICATION_STYLE theme);

            /// <summary>
            /// To be invoked when settings are changed.
            /// </summary>
            public event OnSettingsChanged onSettingsChanged;

            /// <summary>
            /// To be invoked when theme is changed.
            /// </summary>
            public event OnChangeTheme onChangeTheme;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="appSettings"></param>
            public void LoadSettings(AppSettings appSettings);
        }

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

        /// <summary>
        /// Contracts the neccessary functions to communicate with MediaList
        /// </summary>
        public interface IMediaList
        {
            /// <summary>
            /// Interfaces selection event data.
            /// </summary>
            /// <param name="selection"></param>
            public delegate void OnSelection(AudioMetaData selection);

            /// <summary>
            /// To be invoked upon selection and selection changes.
            /// </summary>
            public event OnSelection onSelection;

            /// <summary>
            /// Sets the media list content.
            /// </summary>
            /// <param name="mediaList"></param>
            public void SetList(List<AudioMetaData> mediaList);

            /// <summary>
            /// Marks the actually playing file.
            /// </summary>
            /// <param name="selection"></param>
            public void SetPlaying(AudioMetaData selection);
        }
        #endregion
    }
}