using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{
    public class JSONDeserializer : IJSONDeserializer
    {
        public JSONDeserializer()
        {

        }

        public T Serialize<T>(string deserializable)
        {
            throw new NotImplementedException();
        }
    }
}