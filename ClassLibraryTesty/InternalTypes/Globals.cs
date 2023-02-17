namespace MusicPlayerBackend.InternalTypes;
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

    /// <summary>
    /// Holds the path to the programms log file.
    /// </summary>
    public static string LogPath { get; } = "log.log";

    /// <summary>
    /// Stores the valid audio file endings the application is able to play and find.
    /// </summary>
    public static List<string> ValidAudioFileEndings { get; } = new()
    {
        "mp3",
    };
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
    LIGHT = 1,

    /// <summary>
    /// Represents the default light theme.
    /// </summary>
    DEFAULT = 2,

    /// <summary>
    /// Represents the default dark theme.
    /// </summary>
    DEFAULTDARK = 3,
}