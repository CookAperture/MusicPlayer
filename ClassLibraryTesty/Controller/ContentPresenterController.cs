using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    public class ContentPresenterController : IContentPresenterController
    {
        IContentPresenter ContentPresenter { get; set; }
        public ContentPresenterController(IContentPresenter contentPresenter)
        {
            ContentPresenter = contentPresenter;
        }

    }
}
