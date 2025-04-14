using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Entities;

[Table("bookmark")]
public class Bookmark
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Required]
    [Column("title")]
    [MaxLength(255)]
    public string Title { get; set; } = null!;

    [Required]
    [Column("url")]
    public string Url { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Column("folder_id")]
    public long? FolderId { get; set; }

    [ForeignKey("FolderId")]
    public Folder? Folder { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = [];
}
