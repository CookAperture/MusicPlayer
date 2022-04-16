using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to communicate with the custom decoration.
    /// </summary>
    public interface ICustomDecoration
    {
        /// <summary>
        /// Interfaces minimize event data.
        /// </summary>
        /// <param name="args"></param>
        public delegate void OnMinimize(EventArgs args);

        /// <summary>
        /// Interfaces maximize event data.
        /// </summary>
        /// <param name="args"></param>
        public delegate void OnMaximize(EventArgs args);

        /// <summary>
        /// Interfaces close event data.
        /// </summary>
        /// <param name="args"></param>
        public delegate void OnClose(object args);

        /// <summary>
        /// Interfaces dragging event data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void OnDrag(object sender, EventArgs args);

        /// <summary>
        /// To be invoked when minimize is triggered.
        /// </summary>
        public event OnMinimize onMinimize;

        /// <summary>
        /// To be invoked when maximize is triggered.
        /// </summary>
        public event OnMaximize onMaximize;

        /// <summary>
        /// To be invoked when close is triggered.
        /// </summary>
        public event OnClose onClose;

        /// <summary>
        /// To be invoked when drag is triggered.
        /// </summary>
        public event OnDrag onDrag;
    }
}
