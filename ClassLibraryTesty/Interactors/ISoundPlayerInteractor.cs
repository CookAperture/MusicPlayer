using ClassLibraryTesty.Contracts;
using System;

namespace ClassLibraryTesty
{
    public class SoundPlayerInteractor : ISoundPlayerInteractor
    {

        public ISoundEngine SoundEngine { get; set; }
        public IDataConverter DataConverter { get; set; }

        public SoundPlayerInteractor(ref ISoundEngine soundEngine, ref IDataConverter dataConverter)
        {
            SoundEngine = soundEngine;
            DataConverter = dataConverter;
        }

        public void StopPlaying()
        {
            throw new NotImplementedException();
        }

        public void StartPlaying(string path)
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

        public void ResumePlaying()
        {
            throw new NotImplementedException();
        }
    }
}