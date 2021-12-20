using System;
using System.Collections.Generic;

namespace ClassLibraryTesty
{
    public enum APPLICATION_STYLE
    {
         DARK = 0,
         LIGHT = 1
    }

    public struct AudioDeviceModel
    {
        public string Text { get; set; }
    }

    public struct ThemesModel
    {
        public string Text { get; set; }
    }

    public struct AudioDataModel
    {
        public string Title { get; set; }
        public string Duration { get; set; }
    }

    public struct AudioMetaData
    {
        //icon
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioFilePath { get; set; }
    }

    public struct AppSettings
    {
        public string MediaPath { get; set; }
        public string AudioDevice { get; set; }
        public List<string> AudioDevices { get; set; }
        public APPLICATION_STYLE AppStyle { get; set; }
    }
}