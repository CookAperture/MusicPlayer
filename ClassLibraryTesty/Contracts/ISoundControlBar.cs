using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts the neccessary functions to communicate with the sound controll bar and affect audio directly.
/// </summary>
public interface ISoundControlBar
{
    /// <summary>
    /// To be invoked when user triggers play.
    /// </summary>
    public event Action<AudioMetaData> onPlay;

    /// <summary>
    /// To be invoked when user triggers pause.
    /// </summary>
    public event Action onPause;

    /// <summary>
    /// To be invoked when user triggers resume.
    /// </summary>
    public event Action onResume;

    /// <summary>
    /// To be invoked when finished or manually pressed.
    /// </summary>
    public event Action onNext;

    /// <summary>
    /// Contracts that the meta data from an audio file fills the content fields of this controll.
    /// </summary>
    /// <param name="audioMetaData"></param>
    public void SetAudioMetaData(AudioMetaData audioMetaData);

    /// <summary>
    /// Fetch progress.
    /// </summary>
    public void UpdateProgress(TimeSpan curr);

    /// <summary>
    /// Handles finished.
    /// </summary>
    public void IsFinished();
}