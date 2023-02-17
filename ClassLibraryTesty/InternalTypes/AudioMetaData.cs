namespace MusicPlayerBackend.InternalTypes;
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
    /// If is <see cref="AudioMetaData"/>, the call is delegated to <seealso cref="Equals(AudioMetaData)"/>
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
        HashCode hashCode = new();

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
        var str = "Title: " + Title +
                  " | Duration: " + Duration.ToString() +
                  " | AudioFilePath: " + AudioFilePath;

        return str;
    }
}