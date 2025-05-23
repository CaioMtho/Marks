using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("username")]
    [MaxLength(50)]
    public string Username { get; set; } = null!;

    [Column("email")]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("last_updated_at")]
    public DateTime? LastUpdatedAt { get; set; }

    public ICollection<Bookmark> Bookmarks { get; set; } = [];
    public ICollection<Folder> Folders { get; set; } = [];
}
