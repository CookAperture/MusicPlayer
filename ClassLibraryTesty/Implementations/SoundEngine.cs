using MusicPlayerBackend.Contracts;
using System;
using System.Threading;
using ManagedBass;
using System.Collections.Generic;

namespace MusicPlayerBackend
{
    /// <summary>
    /// Implements <see cref="ISoundEngine"/> for handling of audiofiles and communication to audiodevices.
    /// The underlying API can be subject to change, but the output and consistensy will remain.
    /// Playing happens async.
    /// </summary>
    /// <inheritdoc cref="ISoundEngine"/>
    public class SoundEngine : ISoundEngine
    {
        public int ActualStream { get; set; }
        public int ActualDevice { get; set; }
        private List<string> Devices { get; set; } = new List<string>();

        public SoundEngine()
        {
            for (int i = 1; i < Bass.DeviceCount; ++i)
            {
                var deviceInfo = Bass.GetDeviceInfo(i);
                if (deviceInfo.IsEnabled)
                {
                    Devices.Add(deviceInfo.Name);
                    if(deviceInfo.IsDefault)
                        ActualDevice = i;
                }
            }
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