using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISoundControlBarController"/>.
    /// </summary>
    public class SoundControlBarController : ISoundControlBarController
    {
        ISoundControlBar SoundControlBar { get; set; }
        IAudioFileInteractor AudioFileInteractor { get; set; }

        /// <summary>
        /// Connects <paramref name="audioFileInteractor"/> with <paramref name="soundControlBar"/>.
        /// </summary>
        /// <param name="soundControlBar"></param>
        /// <param name="audioFileInteractor"></param>
        public SoundControlBarController(ISoundControlBar soundControlBar, IAudioFileInteractor audioFileInteractor)
        {
            SoundControlBar = soundControlBar;
            AudioFileInteractor = audioFileInteractor;

            SoundControlBar.onPlay += (AudioMetaData data) => AudioFileInteractor.StartPlaying(data);
            SoundControlBar.onPause += () => AudioFileInteractor.StopPlaying();
            SoundControlBar.onResume += () => AudioFileInteractor.ResumePlaying();

            AudioFileInteractor.onUpdatePlayProgress += (TimeSpan curr) => { /*TODO*/ };
            AudioFileInteractor.onAudioFileFinished += () => { };
        }

        /// <summary>
        /// Updates the replay info.
        /// </summary>
        public void UpdateInformation(AudioMetaData audioMetaData)
        {
            SoundControlBar.SetAudioMetaData(audioMetaData);
        }
    }
}
