using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Entities;

[Table("folder")]
public class Folder
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; } = "New folder";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [ForeignKey("ParentId")]
    public Folder? Parent { get; set; }

    [InverseProperty("Parent")]
    public ICollection<Folder> Children { get; set; } = [];

    public ICollection<Bookmark> Bookmarks { get; set; } = [];
}
