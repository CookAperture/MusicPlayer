using MusicPlayerBackend.Contracts;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IJSONDeserializer"/> to seserialize any json string for given type.
    /// </summary>
    /// /// <seealso cref="MusicPlayerBackend.Contracts.IJSONDeserializer" />
    public class JSONDeserializer : IJSONDeserializer
    {

        /// <summary>
        /// Initializes neccesary resources to deserialize a json string.
        /// No resources are acquired within this implementation of the constructor.
        /// </summary>
        public JSONDeserializer()
        {
        }

        /// <summary>
        /// Deserializes any given type <typeparamref name="T"/> from the <paramref name="deserializable"/> json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deserializable"></param>
        /// <returns>Deserialized object of type <typeparamref name="T"/>.</returns>
        public T Deserialize<T>(string deserializable) where T: struct
        {
            Debug.Assert(deserializable != null);

            T result = JsonSerializer.Deserialize<T>(deserializable);

            Logger.Log(LogSeverity.Success, this, "String deserialized: " + result.ToString());

            return result;
        }
    }
}