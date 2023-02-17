using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts;
/// <summary>
/// Contracts the neccesary functions to communicate with it's subcomponents and vice versa.
/// </summary>
public interface IApplication
{
    /// <summary>
    /// Communicates to the App to set the <paramref name="appStyle"/> predefined in <see cref="APPLICATION_STYLE"/>.
    /// </summary>
    /// <param name="appStyle"></param>
    public void SetStyle(APPLICATION_STYLE appStyle);

    /// <summary>
    /// Contracts to fetch the current set style.
    /// </summary>
    /// <returns></returns>
    public APPLICATION_STYLE GetCurrentApplicationStyle();
}