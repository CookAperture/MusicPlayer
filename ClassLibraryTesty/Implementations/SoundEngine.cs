using MusicPlayerBackend.Contracts;
using System;
using System.Threading;
using ManagedBass;
using System.Collections.Generic;
using System.Diagnostics;

namespace MusicPlayerBackend
{
    /// <summary>
    /// Implements <see cref="ISoundEngine"/> for handling of audiofiles and communication to audiodevices.
    /// The underlying API can be subject to change, but the output and consistensy will remain.
    /// Playing happens <see langword="async"/>.
    /// </summary>
    /// <inheritdoc cref="ISoundEngine"/>
    public class SoundEngine : ISoundEngine
    {
        /// <summary>
        /// Called every second while playing an audio file. 
        /// Containing the latest progress, synced with the actual replay as <see cref="TimeSpan"/>.
        /// </summary>
        public event ISoundEngine.OnUpdatePlayProgress onUpdatePlayProgress = (TimeSpan time) => { };

        /// <summary>
        /// Called when a replay is finished regulary, not paused or manually stopped.
        /// </summary>
        public event ISoundEngine.OnAudioFileFinished onAudioFileFinished = () => { };

        /// <summary>
        /// Represents the actual stream handle. Only usefull for the engine itself. 
        /// </summary>
        public int ActualStream { get; set; }

        /// <summary>
        /// Represents the actual device handle. Only usefull for the engine itself.
        /// </summary>
        public int ActualDevice { get; set; }

        /// <summary>
        /// Represents the current progress of replay in Milliseconds. 
        /// </summary>
        public double CurrentProgress { get; set; } = 0;

        /// <summary>
        /// Represents the actual maximal replay duration for the current stream in Milliseconds.
        /// </summary>
        public double CurrentMaxPlayDuration { get; set; }

        /// <summary>
        /// Represents the safed MetaData of the current or last played audio file.
        /// </summary>
        public AudioMetaData CurrentAudioMetaData { get; set; }

        /// <summary>
        /// Contains available devices by description usually the name. 
        /// Can be used with the <see cref="ActualDevice"/> handle to determine the actual device name.
        /// </summary>
        public Dictionary<string, int> Devices { get; set; } = new Dictionary<string, int>();

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken _token = new CancellationToken();
        private TaskFactory _taskFactory = new TaskFactory();
        private Timer _timer;
        private bool _playing = false;

        /// <summary>
        /// Does all the Init to properly use the <see cref="SoundEngine"/>. No external configuration is needed.
        /// </summary>
        public SoundEngine()
        {
            for (int i = 1; i < Bass.DeviceCount; ++i)
            {
                var deviceInfo = Bass.GetDeviceInfo(i);
                if (deviceInfo.IsEnabled)
                {
                    Devices.Add(deviceInfo.Name, i);
                    if(deviceInfo.IsDefault)
                        ActualDevice = i;
                }
            }
            onAudioFileFinished += () => { StopPlaying(); };
        }

        /// <summary>
        /// Frees all acquired resources, as well as stopping all <see cref="SoundEngine"/> related running threads.
        /// </summary>
        ~SoundEngine()
        {
            Bass.Free();
        }

        /// <summary>
        /// Uses <see cref="Devices"/> to init the given <paramref name="device"/>.
        /// It will also free any previously initialized resources. 
        /// </summary>
        /// <param name="device"></param>
        public void SetAudioDevice(string device)
        {
            Debug.Assert(device != null);
            Debug.Assert(Devices.ContainsKey(device));

            if(_playing)
            {
                StopPlaying();
                Init(Devices[device]);
                StartPlaying(CurrentAudioMetaData);
                SkipTo(TimeSpan.FromMilliseconds(CurrentProgress));
            }
            else
            {
                Init(Devices[device]);
            }
        }

        /// <summary>
        /// Gets the audio devices. 
        /// </summary>
        /// <returns>List of device names that the <see cref="SoundEngine"/> can find.</returns>
        public List<string> GetAudioDevices()
        {
            Debug.Assert(Devices != null);
            Debug.Assert(Devices.Count != 0);

            return Devices.Keys.ToList();
        }

        /// <summary>
        /// Gets the name of the current device.
        /// Determined by using <see cref="ActualDevice"/> and <see cref="Devices"/>
        /// </summary>
        /// <returns>
        /// The name of the current device initialized. 
        /// </returns>
        public string GetCurrentAudioDevice()
        {
            Debug.Assert(Devices != null);
            Debug.Assert(Devices.Count != 0);

            var currDevices = Devices.ToList().Find((keyval) =>
            {
                if (keyval.Value == ActualDevice)
                    return true;
                else
                    return false;
            }).Key;

            Debug.Assert(currDevices != null);
            Debug.Assert(currDevices != "");

            return currDevices;
        }

        /// <summary>
        /// Starts playing the requested audio file.
        /// Background a new task is started with proper cancellation token.
        /// </summary>
        /// <param name="audioMetaData"></param>
        public void StartPlaying(AudioMetaData audioMetaData)
        {
            Debug.Assert(audioMetaData != new AudioMetaData() { });
            Debug.Assert(_taskFactory != null);

            CurrentAudioMetaData = audioMetaData;
            ActualStream = Bass.CreateStream(CurrentAudioMetaData.AudioFilePath);
            if(ActualStream != 0)
            {
                CurrentMaxPlayDuration = audioMetaData.Duration.TotalMilliseconds;
                _cancellationTokenSource = new CancellationTokenSource();
                _token = _cancellationTokenSource.Token;
                _timer = new Timer(new TimerCallback(OnUpdate), this, 0, 1000);
                _ = _taskFactory.StartNew(() => Play(CurrentAudioMetaData), _token);
            }
            else
            {
                //throw create stream failed - last error data?
                var lasterr = Bass.LastError;
            }
        }

        /// <summary>
        /// Stops the task related to playing the song. The progress is not affected. 
        /// </summary>
        public void StopPlaying()
        {
            Debug.Assert(_cancellationTokenSource != null);
            Debug.Assert(!_cancellationTokenSource.IsCancellationRequested);
            Debug.Assert(_timer != null);

            _cancellationTokenSource.Cancel();
            _timer.Dispose();
            _cancellationTokenSource.Dispose();
            if (ActualStream != 0)
            {
                Bass.ChannelStop(ActualStream);
            }
        }

        /// <summary>
        /// Starts resuming the requested audio file.
        /// Background a new task is started with proper cancellation token.
        /// </summary>
        public void ResumePlaying()
        {
            Debug.Assert(CurrentAudioMetaData != new AudioMetaData());
            Debug.Assert(CurrentMaxPlayDuration > 0);
            Debug.Assert(CurrentProgress >= 0);
            Debug.Assert(_cancellationTokenSource != null);
            Debug.Assert(_timer != null);

            _cancellationTokenSource.Cancel();
            _timer.Dispose();

            _timer = new Timer(new TimerCallback(OnUpdate), this, 0, 1000);
            _cancellationTokenSource = new CancellationTokenSource();
            _token = _cancellationTokenSource.Token;
            _taskFactory.StartNew(() => Play(CurrentAudioMetaData), _token);
        }

        private void Play(AudioMetaData audioMetaData)
        {
            Bass.ChannelPlay(ActualStream);
        }

        private void SkipTo(TimeSpan time)
        {
            Bass.ChannelSetPosition(ActualStream, Bass.ChannelSeconds2Bytes(ActualStream, time.TotalSeconds));
        }

        private void OnUpdate(object state)
        {
            Debug.Assert(ActualStream != 0);
            Debug.Assert(onUpdatePlayProgress != null);
            Debug.Assert(onAudioFileFinished != null);
            Debug.Assert(CurrentMaxPlayDuration > 0);

            var pos = Bass.ChannelGetPosition(ActualStream);
            var currTimeInSecond = Bass.ChannelBytes2Seconds(ActualStream, pos);
            if (currTimeInSecond >= 0)
            {
                CurrentProgress = TimeSpan.FromSeconds(currTimeInSecond).TotalMilliseconds;
                onUpdatePlayProgress.Invoke(TimeSpan.FromMilliseconds(CurrentProgress));
                if (CurrentProgress >= CurrentMaxPlayDuration)
                {
                    StopPlaying();
                    onAudioFileFinished.Invoke();
                }
            }
            else
            {
                //throw
            }
        }

        private void Init(int dev)
        {
            Bass.Free();
            if (!Bass.Init(dev))
            {
                //throw
            }
        }
    }
}