using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="ICustomDecorationController"/>
    /// </summary>
    public class CustomDecorationController : ICustomDecorationController
    {

        /// <summary>
        /// Triggered by ui.
        /// </summary>
        public event ICustomDecorationController.OnSwitchedToSettings onSwitchedToSettings = () => { };

        /// <summary>
        /// Triggered by ui.
        /// </summary>
        public event ICustomDecorationController.OnSwitchedToCover onSwitchedToCover = () => { };

        /// <summary>
        /// Triggered by ui.
        /// </summary>
        public event ICustomDecorationController.OnSwitchedToMediaList onSwitchedToMediaList = () => { };

        ICustomDecoration CustomDecoration { get; set; }

        /// <summary>
        /// Connects <paramref name="customDecoration"/>.
        /// </summary>
        /// <param name="customDecoration"></param>
        public CustomDecorationController(ICustomDecoration customDecoration)
        {
            CustomDecoration = customDecoration;
            CustomDecoration.onSettingsButtonClick += () => onSwitchedToSettings.Invoke();
            CustomDecoration.onCoverButtonClick += () => onSwitchedToCover.Invoke();
            CustomDecoration.onMediaListButtonClick += () => onSwitchedToMediaList.Invoke();
        }

    }
}
