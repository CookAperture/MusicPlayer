using System;
using Xunit;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using NSubstitute;
using System.IO;

namespace MusicPlayerTests
{
    public class SongCoverInteractor_IntegrationTests
    {
        [Fact]
        public void GetCoverFromAudio_CallsToSubsequentResourcesAndLogic_ExpectCallsToMetaDataReader()
        {
            var mdr = Substitute.For<IMetaDataReader>();
            var songCoverInteractor = Substitute.For<SongCoverInteractor>(mdr);
            var data = new ImageContainer()
            {
                FilePath = @"C:://Song.mp3",
                ImageStream = new MemoryStream(),
            };

            songCoverInteractor.GetCoverFromAudio(@"C:://Song.mp3");

            mdr.Received().ReadImageFromAudioFile(@"C:://Song.mp3");
        }
    }
}
