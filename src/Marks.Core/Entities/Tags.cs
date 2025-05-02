using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marks.Core.Entities;

[Table("tags")]
public class Tag
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public ICollection<Bookmark> Bookmarks { get; set; } = [];
}
