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

        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {

        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {

        }
    }

    public class ThemesModel_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {

        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {

        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {

        }
    }

    public class AudioDataModel_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {

        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {

        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {

        }
    }

    public class AudioMetaData_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {

        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {

        }

        [Fact]
        public void ToString_Filled_CorrectlyFormattedString()
        {

        }
    }

    public class AppSettings_UnitTests
    {
        [Fact]
        public void Equals_EqualStruct_True()
        {

        }

        [Fact]
        public void Equals_NotEqualStruct_False()
        {

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
        }
    }
}
