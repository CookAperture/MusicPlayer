using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.Interactors;
using MusicPlayerBackend.InternalTypes;
using NSubstitute;
using System.IO;
using Xunit;

namespace MusicPlayerTests.IntegrationTests;
public class SongCoverInteractor_IntegrationTests
{
    [Fact]
    public void GetCoverFromAudio_CallsToSubsequentResourcesAndLogic_ExpectCallsToMetaDataReader()
    {
        var mdr = Substitute.For<IMetaDataReader>();
        var songCoverInteractor = Substitute.For<SongCoverInteractor>(mdr);
        var data = new ImageContainer
        {
            FilePath = @"C:://Song.mp3",
            ImageStream = new MemoryStream(),
        };

        songCoverInteractor.GetCoverFromAudio(@"C:://Song.mp3");

        mdr.Received().ReadImageFromAudioFile(@"C:://Song.mp3");
    }
}