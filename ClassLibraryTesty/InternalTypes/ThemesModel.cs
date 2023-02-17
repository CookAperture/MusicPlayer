﻿using MusicPlayerBackend.Contracts;

namespace MusicPlayerBackend.InternalTypes;
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
        HashCode hashCode = new();

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
        var str = "Text: " + Text;

        return str;
    }
}