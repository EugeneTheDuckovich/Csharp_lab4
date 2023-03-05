namespace AudioLibrary.Entities;

public class SongEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public int JenreId { get; set; }
    public string AlbumName { get; set; }
}
