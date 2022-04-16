using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts neccessary functions to communicate and connect ui with interactor.
    /// </summary>
    public interface ISettingsController
    {
        /// <summary>
        /// Contracts to load the settings. To the settings ui.
        /// </summary>
        public void LoadSettings();
    }
}
