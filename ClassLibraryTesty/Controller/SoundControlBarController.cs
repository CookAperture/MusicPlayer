using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

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

            SoundControlBar.onPlay += (AudioMetaData data) => OnPlay(data);
            SoundControlBar.onPause += () => OnPause();
            SoundControlBar.onResume += () => OnResume();

            AudioFileInteractor.onUpdatePlayProgress += (TimeSpan curr) => OnUpdatePlayProgress(curr);
            AudioFileInteractor.onAudioFileFinished += () => OnAudioFileFinished();
            ((INotifyError)AudioFileInteractor).onError += (NotificationModel notification) => ((INotifyUI)SoundControlBar).Notify(notification);
        }

        private void OnPlay(AudioMetaData data)
        {
            AudioFileInteractor.StartPlaying(data);
        }

        private void OnPause()
        {
            AudioFileInteractor.StopPlaying();
        }

        private void OnResume()
        {
            AudioFileInteractor.ResumePlaying();
        }

        private void OnUpdatePlayProgress(TimeSpan curr)
        {
        }

        private void OnAudioFileFinished()
        {
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
