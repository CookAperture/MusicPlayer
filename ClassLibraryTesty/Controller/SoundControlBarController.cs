using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class SoundControlBarController : ISoundControlBarController
    {
        ISoundControlBar soundControlBar;
        public SoundControlBarController(ISoundControlBar soundControlBar)
        {
            this.soundControlBar = soundControlBar;

            this.soundControlBar.onPlay += () => { };
        }

        public void UpdateInformation()
        {
            throw new System.NotImplementedException();
        }
    }
}
