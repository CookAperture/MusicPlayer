using MusicPlayerBackend.Implementations;
using MusicPlayerBackend.InternalTypes;
using System.Collections.Generic;
using Xunit;

namespace MusicPlayerTests.UnitTests;
public class JSONSerializer_UnitTests
{
    [Fact]
    public void Serialize_SerializedAppSettings_CorrectAppSetingsStruct()
    {
        var jSONSerializer = new JSONSerializer();
        var toserialize = new AppSettings
        {
            MediaPath = "C://",
            AudioDevice = "SomeAudioDevice",
            AudioDevices = new List<string> { "SomeOtherDevice", "AnotherDevice" },
            AppStyle = APPLICATION_STYLE.DARK,
        };
        var expected = @"{""MediaPath"":""C://"",""AudioDevice"":""SomeAudioDevice"",""AudioDevices"":[""SomeOtherDevice"",""AnotherDevice""],""AppStyle"":0}";

        var actual = jSONSerializer.Serialize(toserialize);

        Assert.Equal(expected, actual);
    }
}