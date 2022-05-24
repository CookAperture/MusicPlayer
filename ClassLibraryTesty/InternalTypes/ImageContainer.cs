using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend
{
    /// <summary>
    /// Holds neccessary data to hold and load an Image.
    /// </summary>
    public record struct ImageContainer : IEquatable<ImageContainer>
    {
        /// <summary>
        /// Contains the Path to either lazy load or debug.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Contains an Image Byte Stream.
        /// </summary>
        public Stream ImageStream { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioMetaData"/>, the call is delegated to <seealso cref="Equals(ImageContainer)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if equal.
        /// <see langword="false"/> if not equal.
        /// </returns>
        public bool Equals(ImageContainer other)
        {
            return FilePath == other.FilePath &&
                ImageStream == other.ImageStream;
        }

        /// <summary>
        /// Summs hash codes of every field. Calls subsequent <see cref="GetHashCode"/> of the fields.
        /// </summary>
        /// <returns>Summed hash code as <see langword="int"/>.</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new();

            hashCode.Add(FilePath.GetHashCode());
            hashCode.Add(ImageStream.GetHashCode());

            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Adds every property formatted by name and value seperated by a pipe to a string.
        /// Uses subsequent <see cref="ToString"/> calls.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("FilePath: {0} | ImageStream: {1}", FilePath, ImageStream != null ? ImageStream.ToString() : "empty");
        }
    }
}
