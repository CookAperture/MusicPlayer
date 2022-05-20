using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IAudioFileInteractor"/>
    /// </summary>
    public class AudioFileInteractor : IAudioFileInteractor
    {
        ISoundEngine SoundEngine { get; set; }
        IMetaDataReader MetaDataReader { get; set; }
        IDataConverter DataConverter { get; set; }

        /// <summary>
        /// Connects <paramref name="dataConverter"/> with <paramref name="metaDataReader"/> and with <paramref name="soundEngine"/>.
        /// </summary>
        /// <param name="soundEngine"></param>
        /// <param name="dataConverter"></param>
        /// <param name="metaDataReader"></param>
        public AudioFileInteractor(ISoundEngine soundEngine, IDataConverter dataConverter, IMetaDataReader metaDataReader)
        {
            SoundEngine = soundEngine;
            DataConverter = dataConverter;
            MetaDataReader = metaDataReader;

            SoundEngine.onAudioFileFinished += () => { onAudioFileFinished.Invoke(); };
            SoundEngine.onUpdatePlayProgress += (TimeSpan current) => { onUpdatePlayProgress.Invoke(current); };
        }

        public event Action<TimeSpan> onUpdatePlayProgress;
        public event Action onAudioFileFinished;

        /// <summary>
        /// Starts playing actual song selected.
        /// </summary>
        public void StartPlaying(AudioMetaData data)
        {
            SoundEngine.StartPlaying(data);
        }

        /// <summary>
        /// Starts playing the actual audio at given <paramref name="time"/>.
        /// </summary>
        /// <param name="time"></param>
        public void StartPlayingAt(TimeSpan time)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Skips to <paramref name="seconds"/> in actual replay.
        /// </summary>
        /// <param name="seconds"></param>
        public void SkipTo(int seconds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops playing the actual audio.
        /// </summary>
        public void StopPlaying()
        {
            SoundEngine.StopPlaying();
        }

        /// <summary>
        /// Resumes playing the actual audio.
        /// </summary>
        public void ResumePlaying()
        {
            SoundEngine.ResumePlaying();
        }
    }
}