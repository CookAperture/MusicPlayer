﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to read a audio meta data struct from files.
    /// </summary>
    public interface IMetaDataReader
    {

        /// <summary>
        /// Communicates that <paramref name="path"/> is used to obtain an <see cref="AudioMetaData"/>.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Should return an correctly filled <see cref="AudioMetaData"/> struct.</returns>
        public AudioMetaData ReadMetaDataFromFile(string path);

        /// <summary>
        /// Contracts to read the cover image from a audi file if available.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ImageContainer ReadImageFromAudioFile(string path);
    }
}
