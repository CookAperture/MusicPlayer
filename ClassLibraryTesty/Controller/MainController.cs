using System;
using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class MainController : IMainController
    {
        public MainController(IMainController.OnInit onInit)
        {
            onInit.Invoke();
            //put together UI + Interactors;
        }
    }
}
