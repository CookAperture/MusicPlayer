using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
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
}
