using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts to connect <see cref="IMetaDataReader"/>.
/// </summary>
public interface ISongCoverInteractor
{

    /// <summary>
    /// Contracts to read potential img file from meta data.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public ImageContainer GetCoverFromAudio(string path);
}