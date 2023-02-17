using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend.Controller;
/// <summary>
/// Implements <see cref="ICustomDecorationController"/>
/// </summary>
public class CustomDecorationController : ICustomDecorationController
{
    ICustomDecoration CustomDecoration { get; set; }

    /// <summary>
    /// Connects <paramref name="customDecoration"/>.
    /// </summary>
    /// <param name="customDecoration"></param>
    public CustomDecorationController(ICustomDecoration customDecoration)
    {
        CustomDecoration = customDecoration;
    }

}