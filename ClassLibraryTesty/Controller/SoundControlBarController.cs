using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ISoundControlBarController"/>.
    /// </summary>
    public class SoundControlBarController : ISoundControlBarController, INotifyError
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

            SoundControlBar.onPlay += (AudioMetaData data) => OnPlay(data);
            SoundControlBar.onPause += () => OnPause();
            SoundControlBar.onResume += () => OnResume();

            AudioFileInteractor.onUpdatePlayProgress += (TimeSpan curr) => OnUpdatePlayProgress(curr);
            AudioFileInteractor.onAudioFileFinished += () => OnAudioFileFinished();

            Logger.Log(LogSeverity.Debug, this, "Initialized!");
        }

        public event INotifyError.Error onError;

        private void OnPlay(AudioMetaData data)
        {
            Logger.Log(LogSeverity.Debug, this, "On Play " + data.ToString());

            AudioFileInteractor.StartPlaying(data);
        }

        private void OnPause()
        {
            Logger.Log(LogSeverity.Debug, this, "On Pause!");

            AudioFileInteractor.StopPlaying();
        }

        private void OnResume()
        {
            Logger.Log(LogSeverity.Debug, this, "On Resume!");

            AudioFileInteractor.ResumePlaying();
        }

        private void OnUpdatePlayProgress(TimeSpan curr)
        {
            Logger.Log(LogSeverity.Debug, this, "On Update Play Progress to " + curr.ToString());
        }

        private void OnAudioFileFinished()
        {
            Logger.Log(LogSeverity.Debug, this, "On Audio File Finished!");
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
