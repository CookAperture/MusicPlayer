using System;
using System.Collections.Generic;

namespace MusicPlayerBackend
{
    namespace Contracts
    {

        #region Globals
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

            /// <summary>
            /// Contracts to fetch the current set style.
            /// </summary>
            /// <returns></returns>
            public APPLICATION_STYLE GetCurrentApplicationStyle();
        }

        public interface INotifyError
        {
            public delegate void Error(NotificationModel notificationModel);

            public event Error onError;
        }
        #endregion

        #region LogicContracts

        #region Controller
        /// <summary>
        /// Contracts the neccessary functions to connect and handle all sub-controller with the ui.
        /// </summary>
        public interface IMainController
        { }

        /// <summary>
        /// Contracts the neccessary functions to commmunicate to another controller and ui and connect with interactor.
        /// </summary>
        public interface ICustomDecorationController
        {
            //SafeActualSongOnExit -> OnExit event
        }

        /// <summary>
        /// Contracts neccessary functions to communicate and connect <see cref="ISoundControlBar"/> with <see cref="IAudioFileInteractor"/>.
        /// </summary>
        public interface ISoundControlBarController
        {

            /// <summary>
            /// Contracts to set audio meta data to the ui.
            /// </summary>
            public void UpdateInformation(AudioMetaData audioMetaData);
        }

        /// <summary>
        /// Contracts neccessary functions to communicate and connect ui with interactor.
        /// </summary>
        public interface IContentPresenterController
        { }

        /// <summary>
        /// Contracts neccessary functions to communicate and connect ui with interactor.
        /// </summary>
        public interface ISettingsController
        {
            /// <summary>
            /// Contracts to load the settings. To the settings ui.
            /// </summary>
            public void LoadSettings();
        }

        /// <summary>
        /// Contract to connect the <see cref="ISongCover"/> with <see cref="ISongCoverInteractor"/>.
        /// </summary>
        public interface ISongCoverController
        {

            /// <summary>
            /// Contracts to load the cover, is delegated to ui.
            /// </summary>
            public void SetCover(AudioMetaData imageContainer);
        }

        /// <summary>
        /// Contracts to connect <see cref="IMediaList"/> with <see cref="IMediaListInteractor"/>.
        /// </summary>
        public interface IMediaListController
        {
            /// <summary>
            /// Contracts to load media files into the ui.
            /// </summary>
            public void SetMediaList();

            /// <summary>
            /// Contracts to laod media files into ui from new path.
            /// </summary>
            /// <param name="path"></param>
            public void SetMediaListCustomMediaPath(string path);
        }
        #endregion

        #region Interactor
        /// <summary>
        /// Contracts to connect <see cref="ISoundEngine"/> with <see cref="IMetaDataReader"/> and with <see cref="IDataConverter"/>.
        /// </summary>
        public interface IAudioFileInteractor
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
            /// Declares the must that an event exists in any implementation of <see cref="IAudioFileInteractor"/>.
            /// The use of it is not guranteed, but advised.
            /// </summary>
            public event OnUpdatePlayProgress onUpdatePlayProgress;

            /// <summary>
            /// Declares the must that an event exists in any implementation of <see cref="IAudioFileInteractor"/>.
            /// The use of it is not guranteed, but advised.
            /// </summary>
            public event OnAudioFileFinished onAudioFileFinished;

            /// <summary>
            /// Contracts to play actual audio file.
            /// </summary>
            public void StartPlaying(AudioMetaData data);

            /// <summary>
            /// Contracts to start actual audio file at given time.
            /// </summary>
            /// <param name="time"></param>
            public void StartPlayingAt(TimeSpan time);

            /// <summary>
            /// Contracts to Skip to specific time.
            /// </summary>
            /// <param name="seconds"></param>
            public void SkipTo(int seconds);

            /// <summary>
            /// Contracts to stop playing the actual song.
            /// </summary>
            public void StopPlaying();

            /// <summary>
            /// Contracts to resume playing the actual song.
            /// </summary>
            public void ResumePlaying();
        }

        /// <summary>
        /// Contracts to connect <see cref="IFileReader"/>, <see cref="IFileWriter"/>, 
        /// <see cref="IJSONSerializer"/>, <see cref="IJSONDeserializer"/> and <see cref="IDataConverter"/> with each other.
        /// </summary>
        public interface ISettingsInteractor
        {

            /// <summary>
            /// Contracts to write <paramref name="appSettings"/> to the settings file.
            /// </summary>
            /// <param name="appSettings"></param>
            public void WriteSettings(AppSettings appSettings);

            /// <summary>
            /// Contracts to read app settings from the settings file.
            /// </summary>
            /// <returns><see cref="AppSettings"/> saved in settings file.</returns>
            public AppSettings ReadSettings();

            /// <summary>
            /// Contracts to fetch audio devices.
            /// </summary>
            /// <returns></returns>
            public List<string> GetAudioDevices();

            /// <summary>
            /// Contracts to set the audio output device to the sound engine.
            /// </summary>
            /// <param name="audiodevice"></param>
            public void SetAudioDevice(string audiodevice);
        }

        /// <summary>
        /// Contracts to connect <see cref="IMetaDataReader"/> with <see cref="IFileSystemHandler"/>.
        /// </summary>
        public interface IMediaListInteractor
        {

            /// <summary>
            /// To be called with each found media. 
            /// </summary>
            /// <param name="audioMetaData"></param>
            public delegate void OnMediaFound(AudioMetaData audioMetaData);

            /// <summary>
            /// <see cref="OnMediaFound"/>
            /// </summary>
            public event OnMediaFound onMediaFound;

            /// <summary>
            /// Contracts to fetch all audio files recursivly from a root dir.
            /// </summary>
            /// <param name="rootPath"></param>
            /// <returns>List of <see cref="AudioMetaData"/> from all found media files.</returns>
            public void GetMediaListAsync(string rootPath);
        }

        /// <summary>
        /// Contracts to connect <see cref="IMetaDataReader"/>.
        /// </summary>
        public interface ISongCoverInteractor
        {

            /// <summary>
            /// Contracts to read potential img file from meta data.
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public ImageContainer GetCoverFromAudio(string path);
        }

        public interface IExceptionInteractor
        {
            public delegate void OnDialog(DialogModel dialogModel);
            public delegate void OnFatal();

            public event OnDialog onDialog;
            public event OnFatal onFatal;

            public void HandleException(Exception exception);
        }

        #endregion

        #region Logic

        /// <summary>
        /// Contracts the neccessary functions to handle a file system.
        /// </summary>
        public interface IFileSystemHandler
        {

            /// <summary>
            /// To be called with each found media. 
            /// </summary>
            /// <param name="mediafile"></param>
            public delegate void OnMediaFound(string mediafile);

            /// <summary>
            /// <see cref="OnMediaFound"/>
            /// </summary>
            public event OnMediaFound onMediaFound;

            /// <summary>
            /// Describes the neccessary input and output to fetch audio file paths from a root.
            /// </summary>
            /// <param name="rootPath">The root path.</param>
            /// <param name="validAudioFiles">The valid file endings.</param>
            /// <returns>All valid audio files in a List of paths.</returns>
            public List<string> FindAudioFilesFromRootPath(string rootPath, List<string> validAudioFiles);

            /// <summary>
            /// Describes the neccessary input and output to fetch audio file paths from a root. Calls <see cref="OnMediaFound"/> for every found media.
            /// </summary>
            /// <param name="rootPath">The root path.</param>
            /// <param name="validAudioFiles">The valid file endings.</param>
            public void FindAudioFilesFromRootPathAsync(string rootPath, List<string> validAudioFiles);
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

            /// <summary>
            /// Contracts to read the cover image from a audi file if available.
            /// </summary>
            /// <param name="path"></param>
            /// <returns></returns>
            public ImageContainer ReadImageFromAudioFile(string path);
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
            public string Serialize<T>(T serializable) where T : struct; 
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
            public T Deserialize<T>(string deserializable) where T : struct;
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

        public interface IExceptionHandler
        {
            public delegate void OnDialog(DialogModel dialogModel);
            public delegate void OnFatal();

            public event OnDialog onDialog;
            public event OnFatal onFatal;

            public void HandleException(Exception exception);
        }
        #endregion

        #endregion

        #region UIContracts
        //UI Contracts

        /// <summary>
        /// Contracts the neccessary functions to communicate with the main window.
        /// </summary>
        public interface IMainUI
        {
            /// <summary>
            /// Interfaces to change theme.
            /// </summary>
            /// <param name="appStyle"></param>
            public delegate void OnThemeChange(APPLICATION_STYLE appStyle);

            /// <summary>
            /// To be invoked by settings.
            /// </summary>
            public event OnThemeChange onThemeChange;

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
            public delegate void OnPlay(AudioMetaData data);

            /// <summary>
            /// No return on pause and without parameters.
            /// </summary>
            public delegate void OnPause();

            /// <summary>
            /// No return and without parameters.
            /// </summary>
            public delegate void OnResume();

            /// <summary>
            /// No return next from media list.
            /// </summary>
            public delegate void OnNext();

            /// <summary>
            /// To be invoked when user triggers play.
            /// </summary>
            public event OnPlay onPlay;

            /// <summary>
            /// To be invoked when user triggers pause.
            /// </summary>
            public event OnPause onPause;

            /// <summary>
            /// To be invoked when user triggers resume.
            /// </summary>
            public event OnResume onResume;

            /// <summary>
            /// To be invoked when finished or manually pressed.
            /// </summary>
            public event OnNext onNext;

            /// <summary>
            /// Contracts that the meta data from an audio file fills the content fields of this controll.
            /// </summary>
            /// <param name="audioMetaData"></param>
            public void SetAudioMetaData(AudioMetaData audioMetaData);

            /// <summary>
            /// Fetch progress.
            /// </summary>
            public void UpdateProgress(TimeSpan curr);

            /// <summary>
            /// Handles finished.
            /// </summary>
            public void IsFinished();
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
        }

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
            /// Interfaces to load settings.
            /// </summary>
            public delegate void OnLoadSettings();

            /// <summary>
            /// To be invoked when settings are changed.
            /// </summary>
            public event OnSettingsChanged onSettingsChanged;

            /// <summary>
            /// To be invoked by content presenter.
            /// </summary>
            public event OnLoadSettings onLoadSettings;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="appSettings"></param>
            public void LoadSettings(AppSettings appSettings);

            /// <summary>
            /// Contracts to load settings data.
            /// </summary>
            public void LoadSettings();
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
            /// Interfaces to load the medialist.
            /// </summary>
            public delegate Task OnLoadMediaList();

            /// <summary>
            /// Interfaces to fetch from a new path.
            /// </summary>
            /// <param name="path"></param>
            public delegate Task OnLoadMediaListFromNewPath(string path);

            /// <summary>
            /// To be invoked upon selection and selection changes.
            /// </summary>
            public event OnSelection onSelection;

            /// <summary>
            /// To be invoked by content presenter.
            /// </summary>
            public event OnLoadMediaList onLoadMediaList;

            /// <summary>
            /// To be invoked on changed settings.
            /// </summary>
            public event OnLoadMediaListFromNewPath onLoadMediaListFromNewPath;

            /// <summary>
            /// Sets the media list content.
            /// </summary>
            /// <param name="song"></param>
            public void AddSongToList(AudioMetaData song);

            /// <summary>
            /// Marks the actually playing file.
            /// </summary>
            /// <param name="selection"></param>
            public void SetPlaying(AudioMetaData selection);

            /// <summary>
            /// Contracts to load the media list data.
            /// </summary>
            public void LoadMediaList();

            /// <summary>
            /// Contracts to fetch a new media path.
            /// </summary>
            /// <param name="path"></param>
            public void LoadMediaListFromNewMediaPath(string path);
        }
        #endregion
    }
}