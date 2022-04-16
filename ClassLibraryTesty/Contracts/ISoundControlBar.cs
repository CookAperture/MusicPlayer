using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
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
}
