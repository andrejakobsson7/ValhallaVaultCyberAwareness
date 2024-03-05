using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models
{
    public class CategoryModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        //Navigation property
        public List<SegmentModel> Segments = new();

    }
}
