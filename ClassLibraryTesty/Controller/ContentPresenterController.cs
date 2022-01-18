using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IContentPresenterController"/>.
    /// </summary>
    public class ContentPresenterController : IContentPresenterController
    {
        IContentPresenter ContentPresenter { get; set; }

        /// <summary>
        /// Connects <paramref name="contentPresenter"/>.
        /// </summary>
        /// <param name="contentPresenter"></param>
        public ContentPresenterController(IContentPresenter contentPresenter)
        {
            ContentPresenter = contentPresenter;
        }

    }
}
