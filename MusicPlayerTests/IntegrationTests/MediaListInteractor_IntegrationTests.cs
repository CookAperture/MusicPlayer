using System;
using Xunit;
using MusicPlayerBackend;
using MusicPlayerBackend.Contracts;
using System.Collections.Generic;
using NSubstitute;

namespace MusicPlayerTests
{
    public class MediaListInteractor_IntegrationTests
    {
        [Fact]
        public void GetMediaList_CallsToSubsequentResourcesAndLogic_ExpectCallsToFileSystemHandlerAndMetaDataReader()
        {
            var fsh = Substitute.For<IFileSystemHandler>();
            var mdr = Substitute.For<IMetaDataReader>();
            var mediaListInteractor = Substitute.For<MediaListInteractor>(fsh, mdr);

            fsh.FindAudioFilesFromRootPath(@"C://", Globals.ValidAudioFileEndings).Returns(new List<string>() { "F1", "F2" });

            mediaListInteractor.GetMediaListAsync(@"C://");

            fsh.Received().FindAudioFilesFromRootPathAsync(@"C://", Globals.ValidAudioFileEndings);
        }
    }
}
