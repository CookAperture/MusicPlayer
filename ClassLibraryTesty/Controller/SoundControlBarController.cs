using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

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

            onError += (NotificationModel notificationModel) => ((INotifyUI)SoundControlBar).Notify(notificationModel);
        }

        public event Action<NotificationModel> onError;

        private void OnPlay(AudioMetaData data)
        {
            try
            {
                AudioFileInteractor.StartPlaying(data);
            }
            catch (StartPlayingFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Title = "Unknown Error",
                    Message = ex.Source + "\n" + ex.Message,
                    Level = NotificationModel.NotificationLevel.Error});
            }
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
