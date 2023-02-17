using MusicPlayerBackend.Implementations;
using MusicPlayerBackend.InternalTypes;
using System.Collections.Generic;
using Xunit;

namespace MusicPlayerTests.UnitTests;
public class JSONDeserializer_UnitTests
{
    [Fact]
    public void Deserialize_SerializedAppSettings_CorrectAppSetingsStruct()
    {
        var jSONDeserializer = new JSONDeserializer();
        var jsonString =
            @"{
  ""MediaPath"": ""C://"",
  ""AudioDevice"": ""SomeAudioDevice"",
  ""AudioDevices"": [""SomeOtherDevice"",
""AnotherDevice""],
  ""AppStyle"": 0
}";
        var expected = new AppSettings
        {
            MediaPath = "C://",
            AudioDevice = "SomeAudioDevice",
            AudioDevices = new List<string> { "SomeOtherDevice", "AnotherDevice" },
            AppStyle = APPLICATION_STYLE.DARK,
        };

        var actual = jSONDeserializer.Deserialize<AppSettings>(jsonString);

        Assert.Equal(expected, actual);
    }
}