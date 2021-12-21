using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    public class SoundControlBarController : ISoundControlBarController
    {
        public event ISoundControlBarController.OnPlay onPlay;
        public event ISoundControlBarController.OnSkipForward onSkipForward;
        public event ISoundControlBarController.OnSkipBackward onSkipBackward;
        public event ISoundControlBarController.ScrubTo onScrubTo;

        ISoundControlBar SoundControlBar { get; set; }
        IAudioFileInteractor AudioFileInteractor { get; set; }
        public SoundControlBarController(ISoundControlBar soundControlBar, IAudioFileInteractor audioFileInteractor)
        {
            SoundControlBar = soundControlBar;
            AudioFileInteractor = audioFileInteractor;

            SoundControlBar.onPlay += () => AudioFileInteractor.StartPlaying();
            SoundControlBar.onPause += () => AudioFileInteractor.StopPlaying();
        }

        public void UpdateInformation()
        {
            var data = AudioFileInteractor.ReadMetaDataFromActualAudio();
            SoundControlBar.SetAudioMetaData(data);
        }
    }
}
