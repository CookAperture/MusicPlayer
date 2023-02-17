using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;

namespace MusicPlayerBackend.Interactors;
/// <summary>
/// Implements <see cref="IAudioFileInteractor"/>
/// </summary>
public class AudioFileInteractor : IAudioFileInteractor, INotifyError
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
        SoundEngine.onUpdatePlayProgress += (TimeSpan current) => OnUpdatePlayProgress(current);
    }

    /// <summary>
    /// Fired every second when the audio file is playing.
    /// </summary>
    public event Action<TimeSpan> onUpdatePlayProgress;

    /// <summary>
    /// Fired when the audio file is finished playing.
    /// </summary>
    public event Action onAudioFileFinished;

    /// <summary>
    /// Fired when an error occurs.
    /// </summary>
    public event Action<NotificationModel> onError;

    /// <summary>
    /// Starts playing actual song selected.
    /// </summary>
    public void StartPlaying(AudioMetaData data)
    {
        try
        {
            SoundEngine.StartPlaying(data);
        }
        catch (StartPlayingFailedException ex)
        {
            onError.Invoke(new NotificationModel { Title = "Error", Message = ex.Message, Level = NotificationModel.NotificationLevel.Error });
        }
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

    private void OnUpdatePlayProgress(TimeSpan current)
    {
        onUpdatePlayProgress.Invoke(current);
    }
}