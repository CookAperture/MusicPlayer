using MusicPlayerBackend.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        }

        /// <summary>
        /// Reads all the data from a file at <paramref name="path"/> as text.
        /// </summary>
        /// <param name="path">The file to read from.</param>
        /// <returns>List of <see cref="string"/> representing the files contents.</returns>
        public List<string> ReadAllLines(string path)
        {
            Debug.Assert(!string.IsNullOrEmpty(path));

            return File.ReadAllLines(path).ToList();
        }

        /// <summary>
        /// Reads all the data from a file at <paramref name="path"/> as text.
        /// </summary>
        /// <param name="path">The file to read from.</param>
        /// <returns>Single <see cref="string"/> representing the files contents.</returns>
        public string ReadWhole(string path)
        {
            Debug.Assert(string.IsNullOrEmpty(path));

            return File.ReadAllText(path);
        }
    }
}