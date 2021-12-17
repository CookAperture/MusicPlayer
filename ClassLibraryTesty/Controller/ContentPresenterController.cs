using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class ContentPresenterController : IContentPresenterController
    {
        IContentPresenter contentPresenter;
        public ContentPresenterController(IContentPresenter contentPresenter)
        {
            this.contentPresenter = contentPresenter;
        }
    }
}
