using System.ComponentModel.DataAnnotations;
using ValhallaVaultCyberAwareness.Client.Validators;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class SubCategoryViewModel
    {
        [Required(ErrorMessage = "Segment name is required")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [NotZero(ErrorMessage = "Segment is required")]
        public int SegmentId { get; set; }

        public SubCategoryViewModel()
        {

        }

        public SubCategoryViewModel(SubCategoryModel subcategory)
        {
            Name = subcategory.Name;
            Description = subcategory.Description;
            SegmentId = subcategory.SegmentId;
        }
    }
}
