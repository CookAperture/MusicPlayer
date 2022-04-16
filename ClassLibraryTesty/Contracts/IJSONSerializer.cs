using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to allow serialization of objects.
    /// </summary>
    public interface IJSONSerializer
    {

        /// <summary>
        /// Describes the neccessary input and output for serialization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializable"></param>
        /// <returns>Should be an representation of the object as <see cref="string"/>.</returns>
        public string Serialize<T>(T serializable) where T : struct;
    }
}
