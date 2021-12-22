using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    public class CustomDecorationController : ICustomDecorationController
    {
        public event ICustomDecorationController.OnSwitchedToSettings onSwitchedToSettings = () => { };
        public event ICustomDecorationController.OnSwitchedToCover onSwitchedToCover = () => { };
        public event ICustomDecorationController.OnSwitchedToMediaList onSwitchedToMediaList = () => { };

        ICustomDecoration CustomDecoration { get; set; }
        public CustomDecorationController(ICustomDecoration customDecoration)
        {
            CustomDecoration = customDecoration;
            CustomDecoration.onSettingsButtonClick += () => onSwitchedToSettings.Invoke();
            CustomDecoration.onCoverButtonClick += () => onSwitchedToCover.Invoke();
            CustomDecoration.onMediaListButtonClick += () => onSwitchedToMediaList.Invoke();
        }

    }
}
