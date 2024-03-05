using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models
{
    public class SubCategoryModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("segment_id")]
        public int SegmentId { get; set; }

        //Navigation property
        public SegmentModel Segment { get; set; } = null!;

        public List<QuestionModel> Questions { get; set; } = new();
    }
}
