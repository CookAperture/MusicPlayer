using MusicPlayerBackend.Contracts;
using System.Text.Json;

namespace MusicPlayerBackend.Implementations;
/// <summary>
/// Implements <see cref="IJSONSerializer"/> to serialize any object to json string for given type.
/// </summary>
/// <seealso cref="MusicPlayerBackend.Contracts.IJSONSerializer" />
public class JSONSerializer : IJSONSerializer
{

    /// <summary>
    /// Initializes neccesary resources to serialize a object.
    /// No resources are acquired within this implementation of the constructor.
    /// </summary>
    public JSONSerializer()
    {
    }

    /// <summary>
    /// Serializes any given object <typeparamref name="T"/> to a json string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="serializable"></param>
    /// <returns>Serialized object of type <typeparamref name="T"/>.</returns>
    public string Serialize<T>(T serializable) where T : struct
    {
        var result = JsonSerializer.Serialize(serializable);

        return result;
    }
}