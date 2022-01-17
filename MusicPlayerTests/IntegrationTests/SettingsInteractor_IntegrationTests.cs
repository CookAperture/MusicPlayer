using System;
using Xunit;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using NSubstitute;

namespace MusicPlayerTests
{
    public class SettingsInteractor_IntegrationTests
    {
        [Fact]
        public void WriteSettings_CallsToSubsequentResourcesAndLogic_ExpectCallsToSerializerAndFileWriter()
        {
            var serializer = Substitute.For<IJSONSerializer>();
            var fwriter = Substitute.For<IFileWriter>();
            var freader = Substitute.For<IFileReader>();
            var deserializer = Substitute.For<IJSONDeserializer>();
            var converter = Substitute.For<IDataConverter>();
            var settingsInteractor = Substitute.For<SettingsInteractor>(converter, deserializer, serializer, freader, fwriter);
            AppSettings settings = new AppSettings()
            {
                AppStyle = APPLICATION_STYLE.LIGHT,
                AudioDevice = "Headset",
                AudioDevices = new List<string>() { "Headset", "Audiojack" },
                MediaPath = @"C://",
            };
            serializer.Serialize(settings).Returns("Testy");

            settingsInteractor.WriteSettings(settings);

            serializer.Received().Serialize(settings);
            fwriter.Received().Write("Testy", Globals.SettingsPath);
        }

        [Fact]
        public void ReadSettings_CallsToSubsequentResourcesAndLogic_ExpectCallsToSerializerAndFileWriter()
        {
            var serializer = Substitute.For<IJSONSerializer>();
            var fwriter = Substitute.For<IFileWriter>();
            var freader = Substitute.For<IFileReader>();
            var deserializer = Substitute.For<IJSONDeserializer>();
            var converter = Substitute.For<IDataConverter>();
            var settingsInteractor = Substitute.For<SettingsInteractor>(converter, deserializer, serializer, freader, fwriter);
            freader.ReadWhole(Arg.Any<string>()).Returns("Testy");

            settingsInteractor.ReadSettings();

            freader.Received().ReadWhole(Globals.SettingsPath);
            deserializer.Received().Deserialize<AppSettings>("Testy");
        }
    }
}
