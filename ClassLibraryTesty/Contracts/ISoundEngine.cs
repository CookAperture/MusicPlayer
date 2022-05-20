using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions and events
    /// to ensure communication with the specific implementation of an sound handler
    /// to other components that might want to work with audio file.
    /// </summary>
    public interface ISoundEngine
    {
        /// <summary>
        /// Declares the must that an event exists in any implementation of <see cref="ISoundEngine"/>.
        /// The use of it is not guranteed, but advised.
        /// </summary>
        public event Action<TimeSpan> onUpdatePlayProgress;

        /// <summary>
        /// Declares the must that an event exists in any implementation of <see cref="ISoundEngine"/>.
        /// The use of it is not guranteed, but advised.
        /// </summary>
        public event Action onAudioFileFinished;

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
}
