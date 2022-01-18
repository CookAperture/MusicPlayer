global using System;
global using Xunit;
global using MusicPlayerBackend;
using System.Collections.Generic;

namespace MusicPlayerTests
{
    public class JSONSerializer_UnitTests
    {
        [Fact]
        public void Serialize_SerializedAppSettings_CorrectAppSetingsStruct()
        {
            JSONSerializer jSONSerializer = new JSONSerializer();
            AppSettings toserialize = new AppSettings()
            {
                MediaPath = "C://",
                AudioDevice = "SomeAudioDevice",
                AudioDevices = new List<string>() { "SomeOtherDevice", "AnotherDevice" },
                AppStyle = APPLICATION_STYLE.DARK,
            };
            string expected = @"{""MediaPath"":""C://"",""AudioDevice"":""SomeAudioDevice"",""AudioDevices"":[""SomeOtherDevice"",""AnotherDevice""],""AppStyle"":0}";

            string actual = jSONSerializer.Serialize(toserialize);

            Assert.Equal(expected, actual);
        }
    }
}
