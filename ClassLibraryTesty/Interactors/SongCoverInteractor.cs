using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.InternalTypes;
using System;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IAudioFileInteractor"/>
    /// </summary>
    public class SongCoverInteractor : ISongCoverInteractor, INotifyError
    {
        IMetaDataReader MetaDataReader { get; set; }

        /// <summary>
        /// Connects to <see cref="IMetaDataReader"/>.
        /// </summary>
        /// <param name="metaDataReader"></param>
        public SongCoverInteractor(IMetaDataReader metaDataReader)
        {
            MetaDataReader = metaDataReader;
        }

        public event Action<NotificationModel> onError;

        /// <summary>
        /// Reads image from meta data.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ImageContainer GetCoverFromAudio(string path)
        {
            try
            {
                return MetaDataReader.ReadImageFromAudioFile(path);
            }
            catch (ReadAudioMetaDataFailedException ex)
            {
                onError.Invoke(new NotificationModel() { Message = ex.Message, Level = NotificationModel.NotificationLevel.Error, Title = "Error" });
                return new ImageContainer();
            }
        }
    }
}