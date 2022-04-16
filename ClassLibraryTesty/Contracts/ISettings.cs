using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to communicate with Settings.
    /// </summary>
    public interface ISettings
    {

        /// <summary>
        /// Interfaces settings changed event data.
        /// </summary>
        /// <param name="appSettings"></param>
        public delegate void OnSettingsChanged(AppSettings appSettings);

        /// <summary>
        /// Interfaces to load settings.
        /// </summary>
        public delegate void OnLoadSettings();

        /// <summary>
        /// To be invoked when settings are changed.
        /// </summary>
        public event OnSettingsChanged onSettingsChanged;

        /// <summary>
        /// To be invoked by content presenter.
        /// </summary>
        public event OnLoadSettings onLoadSettings;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appSettings"></param>
        public void LoadSettings(AppSettings appSettings);

        /// <summary>
        /// Contracts to load settings data.
        /// </summary>
        public void LoadSettings();
    }
}
