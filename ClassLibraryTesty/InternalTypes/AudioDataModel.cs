using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend.InternalTypes;
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
        HashCode hashCode = new();

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
        var str = "Title: " + Title +
                  " | Duration: " + Duration.ToString();

        return str;
    }
}