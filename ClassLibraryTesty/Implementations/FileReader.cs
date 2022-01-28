using MusicPlayerBackend.Contracts;
using System;
using System.Collections.Generic;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Implements the interface <see cref="IFileReader"/>.
    /// </summary>
    public class FileReader : IFileReader
    {

        /// <summary>
        /// Acquires the neccessary resources to read data from files.
        /// </summary>
        public FileReader()
        {
            Logger.Log(LogSeverity.Debug, this, "Initialized!");
        }

        /// <summary>
        /// Reads all the data from a file at <paramref name="path"/> as text.
        /// </summary>
        /// <param name="path">The file to read from.</param>
        /// <returns>List of <see cref="string"/> representing the files contents.</returns>
        public List<string> ReadAllLines(string path)
        {
            Logger.Log(LogSeverity.Debug, this, "Called with path " + path);

            return File.ReadAllLines(path).ToList();
        }

        /// <summary>
        /// Reads all the data from a file at <paramref name="path"/> as text.
        /// </summary>
        /// <param name="path">The file to read from.</param>
        /// <returns>Single <see cref="string"/> representing the files contents.</returns>
        public string ReadWhole(string path)
        {
            Logger.Log(LogSeverity.Debug, this, "Called with path " + path);

            return File.ReadAllText(path);
        }
    }
}