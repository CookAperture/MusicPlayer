using MusicPlayerBackend.Contracts;
using System;
using System.Threading;
using ManagedBass;
using System.Collections.Generic;

namespace MusicPlayerBackend
{
    public class SoundEngine : ISoundEngine
    {
        public int ActualStream { get; set; }
        public int ActualDevice { get; set; } = 4;
        public SoundEngine()
        {
            Bass.Init(ActualDevice);
        }

        ~SoundEngine()
        {
            Bass.Free();
        }

        public void SetAudioDevice(string device)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAudioDevices()
        {
            throw new NotImplementedException();
        }

        public string GetAudioDevice()
        {
            throw new NotImplementedException();
        }

        public void StartPlaying(AudioMetaData audioMetaData)
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

        //public void PlayTest()
        //{
        //    ActualStream = Bass.CreateStream("G:\\NewMusic\\AWOLNATION - Here Come the Runts.mp3", 0, 0, BassFlags.Prescan);
        //    bool res = Bass.ChannelPlay(ActualStream);
        //    Bass.StreamFree(ActualStream);
        //}
    }
}