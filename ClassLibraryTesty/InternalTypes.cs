global using System;
global using System.Collections.Generic;
global using System.Linq;
using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend
{
    /// <summary>
    /// Holds the global variables.
    /// </summary>
    /// <remarks>
    /// Usually only primitive types which are used in multiple places in code,
    /// but are not changed by the user or by the programm.
    /// </remarks>
    public static class Globals
    {
        /// <summary>
        /// Holds the path to the programms config file.
        /// </summary>
        public static string SettingsPath { get; } = "config.json";
    }
    /// <summary>
    /// Represents the available Styles in an Typesafe manner.
    /// </summary>
    public enum APPLICATION_STYLE
    {
        /// <summary>
        /// Represents the dark theme value/option.
        /// </summary>
         DARK = 0,
        /// <summary>
        /// Represents the light theme value/option.
        /// </summary>
        LIGHT = 1
    }

    /// <summary>
    /// Holds data for the <see cref="ISettings"/> UI of the Audio Devices.
    /// Implements <see cref="IEquatable{T}"/> for equality checking. 
    /// </summary>
    public record struct AudioDeviceModel : IEquatable<AudioDeviceModel>
    {
        /// <summary>
        /// Name of the Audio Device
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Implements <see cref="IEquatable{T}"/>. Equals by hold values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see langword="true"/> if equal. <see langword="false"/> if unequal.</returns>
        public bool Equals(AudioDeviceModel other)
        {
            return Text == other.Text;
        }
        
        /// <summary>
        /// Summs hash codes of every field.
        /// </summary>
        /// <returns>Summed hash code as <see langword="int"/>.</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Text.GetHashCode());

            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Adds every property formatted by name and value seperated by a pipe to a string.
        /// Uses subsequent <see cref="ToString"/> calls.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public override string ToString()
        {
            string str = "Text: " + Text;

            return str;
        }
    }

    /// <summary>
    /// Holds data for the <see cref="ISettings"/> UI of the available Themes.
    /// Implements <see cref="IEquatable{T}"/> for equality checking. 
    /// </summary>
    public record struct ThemesModel : IEquatable<ThemesModel>
    {

        /// <summary>
        /// Represents the name of the Theme as <see cref="string"/>.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Implements <see cref="IEquatable{T}"/>. Equals by hold values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see langword="true"/> if equal. <see langword="false"/> if unequal.</returns>
        public bool Equals(ThemesModel other)
        {
            return Text == other.Text;
        }

        /// <summary>
        /// Summs hash codes of every field.
        /// </summary>
        /// <returns>Summed hash code as <see langword="int"/>.</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Text.GetHashCode());

            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Adds every property formatted by name and value seperated by a pipe to a string.
        /// Uses subsequent <see cref="ToString"/> calls.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public override string ToString()
        {
            string str = "Text: " + Text;

            return str;
        }
    }

    /// <summary>
    /// Holds data for the <see cref="ISoundControlBar"/> UI of the available Themes.
    /// Implements <see cref="IEquatable{T}"/> for equality checking. 
    /// </summary>
    public record struct AudioDataModel : IEquatable<AudioDataModel>
    {

        /// <summary>
        /// Represents the title of the audio file.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the duration of the audio file. 
        /// Has no predefined format.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioDataModel"/>, the call is delegated to <seealso cref="Equals(AudioDataModel)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if equal.
        /// <see langword="false"/> if not equal.
        /// </returns>
        public bool Equals(AudioDataModel other)
        {
            return Title == other.Title &&
                Duration == other.Duration;
        }

        /// <summary>
        /// Summs hash codes of every field.
        /// </summary>
        /// <returns>Summed hash code as <see langword="int"/>.</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Title.GetHashCode());
            hashCode.Add(Duration.GetHashCode());

            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Adds every property formatted by name and value seperated by a pipe to a string.
        /// Uses subsequent <see cref="ToString"/> calls.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public override string ToString()
        {
            string str = "Title: " + Title +
                " | Duration: " + Duration.ToString();

            return str;
        }
    }

    /// <summary>
    /// Holds an abstracted unified set of properties to carry the needed meta data of an audio file.
    /// Implements <see cref="IEquatable{T}"/> for equality checking. 
    /// </summary>
    public record struct AudioMetaData : IEquatable<AudioMetaData>
    {
        //icon

        /// <summary>
        /// Represents the title of the audio file, if it was available in the files meta data.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the duration of the audio files content.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Represents the path the file was read from.
        /// </summary>
        public string AudioFilePath { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioDataModel"/>, the call is delegated to <seealso cref="Equals(AudioMetaData)"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// <see langword="true"/> if equal.
        /// <see langword="false"/> if not equal.
        /// </returns>
        public bool Equals(AudioMetaData other)
        {
            return Title == other.Title &&
                Duration == other.Duration &&
                AudioFilePath == other.AudioFilePath;
        }

        /// <summary>
        /// Summs hash codes of every field. Calls subsequent <see cref="GetHashCode"/> of the fields.
        /// </summary>
        /// <returns>Summed hash code as <see langword="int"/>.</returns>
        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Title.GetHashCode());
            hashCode.Add(Duration.GetHashCode());
            hashCode.Add(AudioFilePath.GetHashCode());

            return hashCode.ToHashCode();
        }

        /// <summary>
        /// Adds every property formatted by name and value seperated by a pipe to a string.
        /// Uses subsequent <see cref="ToString"/> calls.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public override string ToString()
        {
            string str = "Title: " + Title + 
                " | Duration: " + Duration.ToString() + 
                " | Path: " + AudioFilePath;

            return str;
        }
    }

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
            HashCode hashCode = new ();

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
            string str = "Style: " + AppStyle +
                " | Device: " + AudioDevice +
                " | Path: " + MediaPath + " | Devices: ";
            foreach (var dev in AudioDevices)
                str += dev + ", ";

            return str;
        }
    }
}