using System;
using System.Collections.Generic;
using System.Linq;

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
    /// Holds data for the UI of the Audio Devices.
    /// Implements <see cref="IEquatable{T}"/> for equality checking. 
    /// </summary>
    public struct AudioDeviceModel : IEquatable<AudioDeviceModel>
    {
        /// <summary>
        /// Name of the Audio Device
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioDeviceModel"/>, the call is delegated to <seealso cref="Equals(AudioDeviceModel)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <para><see langword="true"/> if equal.</para>
        /// <para><see langword="false"/> if not equal.</para>
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                return Equals((AudioDeviceModel)obj);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Equals(AudioDeviceModel other)
        {
            return Text == other.Text;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Text.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            string str = "Text: " + Text;

            return str;
        }

        public static bool operator ==(AudioDeviceModel left, AudioDeviceModel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AudioDeviceModel left, AudioDeviceModel right)
        {
            return !(left == right);
        }
    }

    public struct ThemesModel : IEquatable<ThemesModel>
    {
        public string Text { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="ThemesModel"/>, the call is delegated to <seealso cref="Equals(ThemesModel)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <para><see langword="true"/> if equal.</para>
        /// <para><see langword="false"/> if not equal.</para>
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                return Equals((ThemesModel)obj);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Equals(ThemesModel other)
        {
            return Text == other.Text;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Text.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            string str = "Text: " + Text;

            return str;
        }

        public static bool operator ==(ThemesModel left, ThemesModel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ThemesModel left, ThemesModel right)
        {
            return !(left == right);
        }
    }

    public struct AudioDataModel : IEquatable<AudioDataModel>
    {
        public string Title { get; set; }
        public string Duration { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioDataModel"/>, the call is delegated to <seealso cref="Equals(AudioDataModel)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <para><see langword="true"/> if equal.</para>
        /// <para><see langword="false"/> if not equal.</para>
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                return Equals((AudioDataModel)obj);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Equals(AudioDataModel other)
        {
            return Title == other.Title &&
                Duration == other.Duration;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Title.GetHashCode());
            hashCode.Add(Duration.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            string str = "Title: " + Title +
                " | Duration: " + Duration.ToString();

            return str;
        }

        public static bool operator ==(AudioDataModel left, AudioDataModel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AudioDataModel left, AudioDataModel right)
        {
            return !(left == right);
        }
    }

    public struct AudioMetaData : IEquatable<AudioMetaData>
    {
        //icon
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioFilePath { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AudioMetaData"/>, the call is delegated to <seealso cref="Equals(AudioMetaData)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <para><see langword="true"/> if equal.</para>
        /// <para><see langword="false"/> if not equal.</para>
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                return Equals((AudioMetaData)obj);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Equals(AudioMetaData other)
        {
            return Title == other.Title &&
                Duration == other.Duration &&
                AudioFilePath == other.AudioFilePath;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new ();

            hashCode.Add(Title.GetHashCode());
            hashCode.Add(Duration.GetHashCode());
            hashCode.Add(AudioFilePath.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            string str = "Title: " + Title + 
                " | Duration: " + Duration.ToString() + 
                " | Path: " + AudioFilePath;

            return str;
        }

        public static bool operator ==(AudioMetaData left, AudioMetaData right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AudioMetaData left, AudioMetaData right)
        {
            return !(left == right);
        }
    }

    public struct AppSettings : IEquatable<AppSettings>
    {
        public string MediaPath { get; set; }
        public string AudioDevice { get; set; }
        public List<string> AudioDevices { get; set; }
        public APPLICATION_STYLE AppStyle { get; set; }

        /// <summary>
        /// Overrides the Equals Method of <see langword="object"/>.
        /// If is <see cref="AppSettings"/>, the call is delegated to <seealso cref="Equals(AppSettings)"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// <para><see langword="true"/> if equal.</para>
        /// <para><see langword="false"/> if not equal.</para>
        /// </returns>
        public override bool Equals(object obj)
        {
            try
            {
                return Equals((AppSettings)obj);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Equals(AppSettings other)
        {
            return MediaPath == other.MediaPath &&
                AudioDevice == other.AudioDevice &&
                AudioDevices.SequenceEqual(other.AudioDevices) &&
                AppStyle == other.AppStyle;
        }

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

        public override string ToString()
        {
            string str = "Style: " + AppStyle +
                " | Device: " + AudioDevice +
                " | Path: " + MediaPath + " | Devices: ";
            foreach (var dev in AudioDevices)
                str += dev + ", ";

            return str;
        }

        public static bool operator ==(AppSettings left, AppSettings right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AppSettings left, AppSettings right)
        {
            return !(left == right);
        }
    }
}