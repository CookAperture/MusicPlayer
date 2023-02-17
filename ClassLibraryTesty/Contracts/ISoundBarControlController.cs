using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts neccessary functions to communicate and connect <see cref="ISoundControlBar"/> with <see cref="IAudioFileInteractor"/>.
/// </summary>
public interface ISoundControlBarController
{

    /// <summary>
    /// Contracts to set audio meta data to the ui.
    /// </summary>
    public void UpdateInformation(AudioMetaData audioMetaData);
}