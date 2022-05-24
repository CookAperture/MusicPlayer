using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend
{
    /// <summary>
    /// Holds an abstracted unified set of properties to carry the needed meta data of an audio file.
    /// Implements <see cref="IEquatable{T}"/> for equality checking. 
    /// </summary>
    public record struct AppSettings : IEquatable<AppSettings>
    {

        /// <summary>
        /// Represents the path of all media files. 
        /// </summary>
        public string MediaPath { get; set; }

        /// <summary>
        /// Represents the audio devices name. 
        /// </summary>
        public string AudioDevice { get; set; }

        /// <summary>
        /// Represents all found audio devices by their name.
        /// </summary>
        public List<string> AudioDevices { get; set; }

        /// <summary>
        /// Represents the theme as enum. The choices are predefined by the enum.
        /// </summary>
        public APPLICATION_STYLE AppStyle { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioDataModel"/>, the call is delegated to <seealso cref="Equals(AppSettings)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if equal.
        /// <see langword="false"/> if not equal.
        /// </returns>
        public bool Equals(AppSettings other)
        {
            return MediaPath == other.MediaPath &&
                AudioDevice == other.AudioDevice &&
                AudioDevices.SequenceEqual(other.AudioDevices) &&
                AppStyle == other.AppStyle;
        }

        /// <summary>
        /// Summs hash codes of every field. Calls subsequent <see cref="GetHashCode"/> of the fields.
        /// </summary>
        /// <returns>Summed hash code as <see langword="int"/>.</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new();

            hashCode.Add(MediaPath.GetHashCode());
            hashCode.Add(AudioDevice.GetHashCode());
            hashCode.Add(AppStyle.GetHashCode());
            foreach (var dev in AudioDevices)
                hashCode.Add(dev.GetHashCode());

            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Adds every property formatted by name and value seperated by a pipe to a string.
        /// Uses subsequent <see cref="ToString"/> calls.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public override string ToString()
        {
            string str = "AppStyle: " + AppStyle +
                " | AudioDevice: " + AudioDevice +
                " | MediaPath: " + MediaPath + " | AudioDevices: ";
            if (AudioDevices != null)
                foreach (var dev in AudioDevices)
                    str += dev + ", ";

            return str;
        }
    }
}
