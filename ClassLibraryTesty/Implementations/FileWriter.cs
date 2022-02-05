using MusicPlayerBackend.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements <see cref="IFileWriter"/>.
    /// </summary>
    public class FileWriter : IFileWriter
    {

        /// <summary>
        /// Accquires neccessary resources to write data to an file;
        /// </summary>
        public FileWriter()
        {
        }

        /// <summary>
        /// Writes <paramref name="text"/> to an file at <paramref name="path"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        public void Write(string text, string path)
        {
            Debug.Assert(text != null);
            Debug.Assert(path != null);

            File.WriteAllText(path, text);
        }
    }
}