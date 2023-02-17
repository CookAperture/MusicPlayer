using MusicPlayerBackend.InternalTypes;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MusicPlayerTests.UnitTests;
public class AudioDeviceModel_UnitTests
{
    [Fact]
    public void Equals_EqualStruct_True()
    {
        var expected = new AudioDeviceModel { Text = "SomeDevice" };
        var actual = new AudioDeviceModel { Text = "SomeDevice" };

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void Equals_NotEqualStruct_False()
    {
        var expected = new AudioDeviceModel { Text = "Device" };
        var actual = new AudioDeviceModel { Text = "SomeDevice" };

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void ToString_Filled_CorrectlyFormattedString()
    {
        var testy = new AudioDeviceModel { Text = "SomeDevice" };
        var expected = "Text: SomeDevice";

        var actual = testy.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetHashCode_FromFilled_SameAsAnEqual()
    {
        var i = new AudioDeviceModel { Text = "SomeDevice" };
        var ii = new AudioDeviceModel { Text = "SomeDevice" };

        var expected = i.GetHashCode();
        var actual = ii.GetHashCode();

        Assert.Equal(expected, actual);
    }
}

public class ThemesModel_UnitTests
{
    [Fact]
    public void Equals_EqualStruct_True()
    {
        var expected = new ThemesModel { Text = "SomeTheme" };
        var actual = new ThemesModel { Text = "SomeTheme" };

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void Equals_NotEqualStruct_False()
    {
        var expected = new ThemesModel { Text = "SomeTheme" };
        var actual = new ThemesModel { Text = "Sometheme" };

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void ToString_Filled_CorrectlyFormattedString()
    {
        var testy = new ThemesModel { Text = "SomeTheme" };
        var expected = "Text: SomeTheme";

        var actual = testy.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetHashCode_FromFilled_SameAsAnEqual()
    {
        var i = new ThemesModel { Text = "Sometheme" };
        var ii = new ThemesModel { Text = "Sometheme" };

        var expected = i.GetHashCode();
        var actual = ii.GetHashCode();

        Assert.Equal(expected, actual);
    }
}

public class AudioDataModel_UnitTests
{
    [Fact]
    public void Equals_EqualStruct_True()
    {
        var expected = new AudioDataModel { Title = "RapGod", Duration = "00:00:00" };
        var actual = new AudioDataModel { Title = "RapGod", Duration = "00:00:00" };

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void Equals_NotEqualStruct_False()
    {
        var expected = new AudioDataModel { Title = "RapGod", Duration = "00:00:00" };
        var actual = new AudioDataModel { Title = "RapGod", Duration = "00:00:01" };

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void ToString_Filled_CorrectlyFormattedString()
    {
        var testy = new AudioDataModel { Title = "RapGod", Duration = "00:00:00" };
        var ecpected = "Title: RapGod | Duration: 00:00:00";

        var actual = testy.ToString();

        Assert.Equal(ecpected, actual);
    }

    [Fact]
    public void GetHashCode_FromFilled_SameAsAnEqual()
    {
        var i = new AudioDataModel { Title = "RapGod", Duration = "00:00:00" };
        var ii = new AudioDataModel { Title = "RapGod", Duration = "00:00:00" };

        var expected = i.GetHashCode();
        var actual = ii.GetHashCode();

        Assert.Equal(expected, actual);
    }
}

public class AudioMetaData_UnitTests
{
    [Fact]
    public void Equals_EqualStruct_True()
    {
        var expected = new AudioMetaData
        {
            Title = "RapGod",
            Duration = new TimeSpan(0,0,0),
            AudioFilePath = "C://",
        };
        var actual = new AudioMetaData
        {
            Title = "RapGod", 
            Duration = new TimeSpan(0,0,0), 
            AudioFilePath = "C://",
        };

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void Equals_NotEqualStruct_False()
    {
        var expected = new AudioMetaData
        { 
            Title = "RapGod", 
            Duration = new TimeSpan(0, 0, 0), 
            AudioFilePath = "C://",
        };
        var actual = new AudioMetaData
        { 
            Title = "RapGod",
            Duration = new TimeSpan(0, 1, 0),
            AudioFilePath = "C://",
        };

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void ToString_Filled_CorrectlyFormattedString()
    {
        var testy = new AudioMetaData
        { 
            Title = "RapGod",
            Duration = new TimeSpan(0, 0, 0),
            AudioFilePath = "C://",
        };
        var expected = "Title: RapGod | Duration: 00:00:00 | AudioFilePath: C://";

        var actual = testy.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetHashCode_FromFilled_SameAsAnEqual()
    {
        var i = new AudioMetaData
        {
            Title = "RapGod",
            Duration = new TimeSpan(0, 0, 0),
            AudioFilePath = "C://",
        };
        var ii = new AudioMetaData
        {
            Title = "RapGod",
            Duration = new TimeSpan(0, 0, 0),
            AudioFilePath = "C://",
        };

        var expected = i.GetHashCode();
        var actual = ii.GetHashCode();

        Assert.Equal(expected, actual);
    }
}

public class AppSettings_UnitTests
{
    [Fact]
    public void Equals_EqualStruct_True()
    {
        var expected = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Klingel",
            AudioDevices = new List<string> { "Klingel", "Woover" },
            MediaPath = "C://",
        };
        var actual = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Klingel",
            AudioDevices = new List<string> { "Klingel", "Woover" },
            MediaPath = "C://",
        };

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void Equals_NotEqualStruct_False()
    {
        var expected = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Klingel",
            AudioDevices = new List<string> { "Klingel", "Woover" },
            MediaPath = "C://",
        };
        var actual = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Pieper",
            AudioDevices = new List<string> { "Pieper", "Woover" },
            MediaPath = "C://",
        };

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void ToString_Filled_CorrectlyFormattedString()
    {
        var appSettings = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Klingel",
            AudioDevices = new List<string> { "Klingel", "Woover" },
            MediaPath = "C://",
        };
        var expected = "AppStyle: DARK | AudioDevice: Klingel | MediaPath: C:// | AudioDevices: Klingel, Woover, ";

        var actual = appSettings.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetHashCode_FromFilled_SameAsAnEqual()
    {
        var i = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Klingel",
            AudioDevices = new List<string> { "Klingel", "Woover" },
            MediaPath = "C://",
        };
        var ii = new AppSettings
        {
            AppStyle = APPLICATION_STYLE.DARK,
            AudioDevice = "Klingel",
            AudioDevices = new List<string> { "Klingel", "Woover" },
            MediaPath = "C://",
        };

        var expected = i.GetHashCode();
        var actual = ii.GetHashCode();

        Assert.Equal(expected, actual);
    }
}

public class ImageContainer_UnitTests
{
    [Fact]
    public void Equals_EqualStruct_True()
    {
        var memy = new MemoryStream(new byte[] { 1, 2, 3, 4 });
        var expected = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = memy,
        };
        var actual = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = memy,
        };

        Assert.True(expected.Equals(actual));
    }

    [Fact]
    public void Equals_NotEqualStruct_False()
    {
        var expected = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = new MemoryStream(new byte[] { 4, 2, 3, 4 }),
        };
        var actual = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = new MemoryStream(new byte[] { 1, 2, 3, 4 }),
        };

        Assert.False(expected.Equals(actual));
    }

    [Fact]
    public void ToString_Filled_CorrectlyFormattedString()
    {
        var testy = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = new MemoryStream(new byte[4] { 33, 22, 33, 44 }),
        };
        var expected = "FilePath: C:// | ImageStream: System.IO.MemoryStream";

        var actual = testy.ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetHashCode_FromFilled_SameAsAnEqual()
    {
        var memy = new MemoryStream(new byte[] { 1, 2, 3, 4 });
        var i = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = memy,
        };
        var ii = new ImageContainer
        {
            FilePath = "C://",
            ImageStream = memy,
        };

        var expected = i.GetHashCode();
        var actual = ii.GetHashCode();

        Assert.Equal(expected, actual);
    }
}