using AudioLibrary.Entities;
using AudioLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace AudioLibrary.Mappers;

public static class SongMapper
{
    public static Song? ToSong(this SongEntity songEntity, IEnumerable<Author> authors, IEnumerable<Jenre> jenres)
    {
        var author = authors.FirstOrDefault(a => a.Id == songEntity.AuthorId);
        var jenre = jenres.FirstOrDefault(j => j.Id == songEntity.JenreId);

        if (author == null || jenre == null)
        {
            return null;
        }

        return new Song(songEntity.Id,songEntity.Name, author, jenre, songEntity.AlbumName);
    }

    public static SongEntity ToEntity(this Song song)
    {
        return new SongEntity
        {
            Id = song.Id,
            Name = song.Name,
            JenreId = song.Jenre.Id,
            AuthorId = song.Author.Id,
            AlbumName = song.AlbumName
        };
    }
}
