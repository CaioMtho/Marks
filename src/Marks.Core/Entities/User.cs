using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Entities;

[Table("user")]
public class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("username")]
    [MaxLength(50)]
    public string Username { get; set; } = null!;

    [Required]
    [Column("email")]
    [MaxLength(100)]
    public string Email { get; set; } = null!;

    [Required]
    [Column("password")]
    public string Password { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("last_updated_at")]
    public DateTime? LastUpdatedAt { get; set; }

    public ICollection<Bookmark> Bookmarks { get; set; } = [];
    public ICollection<Folder> Folders { get; set; } = [];
}
