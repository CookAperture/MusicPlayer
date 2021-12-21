using MusicPlayerBackend.Contracts;
using System;

namespace MusicPlayerBackend
{
    public class JSONSerializer : IJSONSerializer
    {
        public JSONSerializer()
        {

        }

        public string Serialize<T>(T serializable)
        {
            throw new NotImplementedException();
        }
    }
}