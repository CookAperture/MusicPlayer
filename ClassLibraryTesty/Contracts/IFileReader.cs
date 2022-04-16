using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Contracts
{
    /// <summary>
    /// Contracts the neccessary functions to allow reading content from an file.
    /// </summary>
    public interface IFileReader
    {

        /// <summary>
        /// Describes the neccessary input and output to read a file as whole.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Single <see cref="string"/> containing a file formatted as text.</returns>
        public string ReadWhole(string path);

        /// <summary>
        /// Describes the neccessary input and output to read a file line by line.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List of <see cref="string"/> each representing one single line of the file.</returns>
        public List<string> ReadAllLines(string path);
    }
}
