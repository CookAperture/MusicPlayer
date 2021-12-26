using System;
using Xunit;
using MusicPlayerBackend;
using System.Collections.Generic;

namespace MusicPlayerTests
{
    public class AudioDeviceModel_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {
            AudioDeviceModel expected = new AudioDeviceModel() { Text = "SomeDevice" };
            AudioDeviceModel actual = new AudioDeviceModel() { Text = "SomeDevice" };

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {
            AudioDeviceModel expected = new AudioDeviceModel() { Text = "Device" };
            AudioDeviceModel actual = new AudioDeviceModel() { Text = "SomeDevice" };

            Assert.False(expected.Equals(actual));
        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {
            AudioDeviceModel testy = new AudioDeviceModel() { Text = "SomeDevice" };
            string expected = "Text: SomeDevice";

            string actual = testy.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashCode_FromFilled_SameAsAnEqual()
        {
            AudioDeviceModel i = new AudioDeviceModel() { Text = "SomeDevice" };
            AudioDeviceModel ii = new AudioDeviceModel() { Text = "SomeDevice" };

            int expected = i.GetHashCode();
            int actual = ii.GetHashCode();

            Assert.Equal(expected, actual);
        }
    }

    public class ThemesModel_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {
            ThemesModel expected = new ThemesModel() { Text = "SomeTheme" };
            ThemesModel actual = new ThemesModel() { Text = "SomeTheme" };

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {
            ThemesModel expected = new ThemesModel() { Text = "SomeTheme" };
            ThemesModel actual = new ThemesModel() { Text = "Sometheme" };

            Assert.False(expected.Equals(actual));
        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {
            ThemesModel testy = new ThemesModel() { Text = "SomeTheme" };
            string expected = "Text: SomeTheme";

            string actual = testy.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashCode_FromFilled_SameAsAnEqual()
        {
            ThemesModel i = new ThemesModel() { Text = "Sometheme" };
            ThemesModel ii = new ThemesModel() { Text = "Sometheme" };

            int expected = i.GetHashCode();
            int actual = ii.GetHashCode();

            Assert.Equal(expected, actual);
        }
    }

    public class AudioDataModel_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {
            AudioDataModel expected = new AudioDataModel() { Title = "RapGod", Duration = "00:00:00" };
            AudioDataModel actual = new AudioDataModel() { Title = "RapGod", Duration = "00:00:00" };

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {
            AudioDataModel expected = new AudioDataModel() { Title = "RapGod", Duration = "00:00:00" };
            AudioDataModel actual = new AudioDataModel() { Title = "RapGod", Duration = "00:00:01" };

            Assert.False(expected.Equals(actual));
        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {
            AudioDataModel testy = new AudioDataModel() { Title = "RapGod", Duration = "00:00:00" };
            string ecpected = "Title: RapGod | Duration: 00:00:00";

            string actual = testy.ToString();

            Assert.Equal(ecpected, actual);
        }

        [Fact]
        public void GetHashCode_FromFilled_SameAsAnEqual()
        {
            AudioDataModel i = new AudioDataModel() { Title = "RapGod", Duration = "00:00:00" };
            AudioDataModel ii = new AudioDataModel() { Title = "RapGod", Duration = "00:00:00" };

            int expected = i.GetHashCode();
            int actual = ii.GetHashCode();

            Assert.Equal(expected, actual);
        }
    }

    public class AudioMetaData_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {
            AudioMetaData expected = new AudioMetaData()
            {
                Title = "RapGod",
                Duration = new TimeSpan(0,0,0),
                AudioFilePath = "C://"
            };
            AudioMetaData actual = new AudioMetaData()
            {
                Title = "RapGod", 
                Duration = new TimeSpan(0,0,0), 
                AudioFilePath = "C://"
            };

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {
            AudioMetaData expected = new AudioMetaData()
            { 
                Title = "RapGod", 
                Duration = new TimeSpan(0, 0, 0), 
                AudioFilePath = "C://"
            };
            AudioMetaData actual = new AudioMetaData()
            { 
                Title = "RapGod",
                Duration = new TimeSpan(0, 1, 0),
                AudioFilePath = "C://"
            };

            Assert.False(expected.Equals(actual));
        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {
            AudioMetaData testy = new AudioMetaData()
            { 
                Title = "RapGod",
                Duration = new TimeSpan(0, 0, 0),
                AudioFilePath = "C://"
            };
            string expected = "Title: RapGod | Duration: 00:00:00 | AudioFilePath: C://";

            string actual = testy.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashCode_FromFilled_SameAsAnEqual()
        {
            AudioMetaData i = new AudioMetaData()
            {
                Title = "RapGod",
                Duration = new TimeSpan(0, 0, 0),
                AudioFilePath = "C://"
            };
            AudioMetaData ii = new AudioMetaData()
            {
                Title = "RapGod",
                Duration = new TimeSpan(0, 0, 0),
                AudioFilePath = "C://"
            };

            int expected = i.GetHashCode();
            int actual = ii.GetHashCode();

            Assert.Equal(expected, actual);
        }
    }

    public class AppSettings_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {
            AppSettings expected = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Klingel",
                AudioDevices = new List<string>() { "Klingel", "Woover" },
                MediaPath = "C://"
            };
            AppSettings actual = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Klingel",
                AudioDevices = new List<string>() { "Klingel", "Woover" },
                MediaPath = "C://"
            };

            Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {
            AppSettings expected = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Klingel",
                AudioDevices = new List<string>() { "Klingel", "Woover" },
                MediaPath = "C://"
            };
            AppSettings actual = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Pieper",
                AudioDevices = new List<string>() { "Pieper", "Woover" },
                MediaPath = "C://"
            };

            Assert.False(expected.Equals(actual));
        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {
            AppSettings appSettings = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Klingel",
                AudioDevices = new List<string>() { "Klingel", "Woover" },
                MediaPath = "C://"
            };
            string expected = "AppStyle: DARK | AudioDevice: Klingel | MediaPath: C:// | AudioDevices: Klingel, Woover, ";

            string actual = appSettings.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashCode_FromFilled_SameAsAnEqual()
        {
            AppSettings i = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Klingel",
                AudioDevices = new List<string>() { "Klingel", "Woover" },
                MediaPath = "C://"
            };
            AppSettings ii = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.DARK,
                AudioDevice = "Klingel",
                AudioDevices = new List<string>() { "Klingel", "Woover" },
                MediaPath = "C://"
            };

            int expected = i.GetHashCode();
            int actual = ii.GetHashCode();

            Assert.Equal(expected, actual);
        }
    }
}
