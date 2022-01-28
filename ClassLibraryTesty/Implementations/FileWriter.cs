using MusicPlayerBackend.Contracts;
using System;
using System.Collections.Generic;

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
            Logger.Log(LogSeverity.Debug, this, "Initialized!");
        }

        /// <summary>
        /// Writes <paramref name="text"/> to an file at <paramref name="path"/>.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        public void Write(string text, string path)
        {
            File.WriteAllText(path, text);

            Logger.Log(LogSeverity.Success, this, "File written to " + path + " with " + text);
        }
    }
}