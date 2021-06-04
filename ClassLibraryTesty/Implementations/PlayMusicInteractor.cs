using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryTesty.Contracts;
using TagLib;
using TagLib.Id3v2;
using TagLib.Audible;

namespace ClassLibraryTesty
{
    public class MusicPlayerInteractor : IMusicPlayerInteractor
    {
        public event IMusicPlayerInteractor.OnSongAdded onSongAdded;

        public void AddSong(string path)
        {
            throw new NotImplementedException();
        }

        public void PlaySong()
        {
            throw new NotImplementedException();
        }
    }
}
