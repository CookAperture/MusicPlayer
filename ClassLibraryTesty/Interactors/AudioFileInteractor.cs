using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{
    public class AudioFileInteractor : IAudioFileInteractor
    {

        public ISoundEngine SoundEngine { get; set; }
        public IMetaDataReader MetaDataReader { get; set; }
        public IDataConverter DataConverter { get; set; }

        public AudioFileInteractor(ISoundEngine soundEngine, IDataConverter dataConverter, IMetaDataReader metaDataReader)
        {
            SoundEngine = soundEngine;
            DataConverter = dataConverter;
            MetaDataReader = metaDataReader;
        }

        public void StartPlaying()
        {
            throw new NotImplementedException();
        }

        public void StartPlayingAt(TimeSpan time)
        {
            throw new NotImplementedException();
        }

        public void SkipTo(int seconds)
        {
            throw new NotImplementedException();
        }

        public void StopPlaying()
        {
            throw new NotImplementedException();
        }

        public void ResumePlaying()
        {
            throw new NotImplementedException();
        }

        public void SetActualAudioFile(string path)
        {
            throw new NotImplementedException();
        }

        public AudioMetaData ReadMetaDataFromActualAudio()
        {
            throw new NotImplementedException();
        }
    }
}