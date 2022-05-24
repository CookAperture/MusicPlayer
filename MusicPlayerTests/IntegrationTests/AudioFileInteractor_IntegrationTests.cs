using System;
using Xunit;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using NSubstitute;

namespace MusicPlayerTests
{
    public class AudioFileInteractor_IntegrationTests
    {
        [Fact]
        public void StartPlaying_CallsToSubsequentResourcesAndLogic_ExpectCallsToSoundEngineAndMetaDataReader()
        {
            var se = Substitute.For<ISoundEngine>();
            var mdr = Substitute.For<IMetaDataReader>();
            var dc = Substitute.For<IDataConverter>();
            var audioFileInteractor = Substitute.For<AudioFileInteractor>(se, dc, mdr);
            var data = new AudioMetaData()
            {
                AudioFilePath = @"C:://Song.mp3",
                Duration = TimeSpan.FromSeconds(230),
                Title = "Song"
            };
            mdr.ReadMetaDataFromFile(@"C:://Song.mp3", x => { }, x => { });

            audioFileInteractor.StartPlaying(data);

            se.Received().StartPlaying(data);
        }

        [Fact]
        public void StopPlaying_CallsToSubsequentResourcesAndLogic_ExpectCallsToSoundEngine()
        {
            var se = Substitute.For<ISoundEngine>();
            var mdr = Substitute.For<IMetaDataReader>();
            var dc = Substitute.For<IDataConverter>();
            var audioFileInteractor = Substitute.For<AudioFileInteractor>(se, dc, mdr);

            audioFileInteractor.StopPlaying();

            se.Received().StopPlaying();
        }

        [Fact]
        public void ResumePlaying_CallsToSubsequentResourcesAndLogic_ExpectCallsToSoundEngine()
        {
            var se = Substitute.For<ISoundEngine>();
            var mdr = Substitute.For<IMetaDataReader>();
            var dc = Substitute.For<IDataConverter>();
            var audioFileInteractor = Substitute.For<AudioFileInteractor>(se, dc, mdr);

            audioFileInteractor.ResumePlaying();

            se.Received().ResumePlaying();
        }
    }
}
