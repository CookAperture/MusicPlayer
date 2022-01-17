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

        string _actualAudioFile = "";

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
        }

        /// <summary>
        /// Starts playing actual song selected.
        /// </summary>
        public void StartPlaying()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Resumes playing the actual audio.
        /// </summary>
        public void ResumePlaying()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the actual audio file.
        /// </summary>
        /// <param name="path"></param>
        public void SetActualAudioFile(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches <see cref="AudioMetaData"/> from actual auio file.
        /// </summary>
        /// <returns><see cref="AudioMetaData"/></returns>
        public AudioMetaData ReadMetaDataFromActualAudio()
        {
            throw new NotImplementedException();
        }
    }
}