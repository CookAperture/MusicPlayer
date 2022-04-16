using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to allow deserializing of objects.
    /// </summary>
    public interface IJSONDeserializer
    {

        /// <summary>
        /// Describes the neccessary input and output for deserialization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deserializable"></param>
        /// <returns>Should be an representation of the string as <typeparamref name="T"/>.</returns>
        public T Deserialize<T>(string deserializable) where T : struct;
    }
}
