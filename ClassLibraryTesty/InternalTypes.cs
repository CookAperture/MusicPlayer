using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryTesty
{
    public enum APPLICATION_STYLE
    {
         DARK = 0,
         LIGHT = 1
    }

    public struct AudioDeviceModel : IEquatable<AudioDeviceModel>
    {
        public string Text { get; set; }

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
            HashCode hashCode = new HashCode();

            hashCode.Add(Text.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            string str = "Text: " + Text;

            return str;
        }
    }

    public struct ThemesModel : IEquatable<ThemesModel>
    {
        public string Text { get; set; }

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
            HashCode hashCode = new HashCode();

            hashCode.Add(Text.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            string str = "Text: " + Text;

            return str;
        }
    }

    public struct AudioDataModel : IEquatable<AudioDataModel>
    {
        public string Title { get; set; }
        public string Duration { get; set; }

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
            HashCode hashCode = new HashCode();

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
    }

    public struct AudioMetaData : IEquatable<AudioMetaData>
    {
        //icon
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioFilePath { get; set; }

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
            HashCode hashCode = new HashCode();

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
    }

    public struct AppSettings : IEquatable<AppSettings>
    {
        public string MediaPath { get; set; }
        public string AudioDevice { get; set; }
        public List<string> AudioDevices { get; set; }
        public APPLICATION_STYLE AppStyle { get; set; }

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
            HashCode hashCode = new HashCode();

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
    }
}