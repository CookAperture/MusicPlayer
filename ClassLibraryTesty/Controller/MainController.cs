using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class MainController : IMainController
    {
        IMainUI mainUI;
        public MainController(ref IMainUI mainUI)
        {
            this.mainUI = mainUI;
        }
    }
}
