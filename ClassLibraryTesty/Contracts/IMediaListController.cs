using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts to connect <see cref="IMediaList"/> with <see cref="IMediaListInteractor"/>.
/// </summary>
public interface IMediaListController
{
    /// <summary>
    /// Contracts to load media files into the ui.
    /// </summary>
    public void SetMediaList();

    /// <summary>
    /// Contracts to laod media files into ui from new path.
    /// </summary>
    /// <param name="path"></param>
    public void SetMediaListCustomMediaPath(string path);
}