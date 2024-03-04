using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models
{
    public class SegmentModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("category_id")]
        public int CategoryId { get; set; }

        //Navigation property
        public CategoryModel Category { get; set; } = null!;

        public List<SubCategoryModel> SubCategories { get; set; } = new();
    }
}
