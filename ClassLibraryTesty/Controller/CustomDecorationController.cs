using ClassLibraryTesty.Contracts;

namespace ClassLibraryTesty
{
    public class CustomDecorationController : ICustomDecorationController
    {
        ICustomDecoration customDecoration;
        public CustomDecorationController(ICustomDecoration customDecoration)
        {
            this.customDecoration = customDecoration;
        }
    }
}
