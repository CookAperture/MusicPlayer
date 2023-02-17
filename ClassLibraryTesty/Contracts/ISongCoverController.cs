using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contract to connect the <see cref="ISongCover"/> with <see cref="ISongCoverInteractor"/>.
/// </summary>
public interface ISongCoverController
{

    /// <summary>
    /// Contracts to load the cover, is delegated to ui.
    /// </summary>
    public void SetCover(AudioMetaData imageContainer);
}