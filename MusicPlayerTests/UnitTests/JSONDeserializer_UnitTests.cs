using System;
using Xunit;
using MusicPlayerBackend;
using System.Collections.Generic;

namespace MusicPlayerTests
{
    public class JSONDeserializer_UnitTests
    {
        [Fact]
        public void Deserialize_SerializedAppSettings_CorrectAppSetingsStruct()
        {
            JSONDeserializer jSONDeserializer = new JSONDeserializer();
            string jsonString =
@"{
  ""MediaPath"": ""C://"",
  ""AudioDevice"": ""SomeAudioDevice"",
  ""AudioDevices"": [""SomeOtherDevice"",
""AnotherDevice""],
  ""AppStyle"": 0
}";
            AppSettings expected = new AppSettings()
            {
                MediaPath = "C://",
                AudioDevice = "SomeAudioDevice",
                AudioDevices = new List<string>() { "SomeOtherDevice", "AnotherDevice" },
                AppStyle = APPLICATION_STYLE.DARK,
            };

            AppSettings actual = jSONDeserializer.Deserialize<AppSettings>(jsonString);

            Assert.Equal(expected, actual);
        }
    }
}
