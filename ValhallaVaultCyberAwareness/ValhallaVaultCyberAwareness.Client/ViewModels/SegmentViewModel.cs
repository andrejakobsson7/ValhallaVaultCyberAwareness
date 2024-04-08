using System.ComponentModel.DataAnnotations;
using ValhallaVaultCyberAwareness.Client.Validators;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
    public class SegmentViewModel
    {
        [Required(ErrorMessage = "Segment name is required")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [NotZero(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public SegmentViewModel()
        {

        }

        public SegmentViewModel(SegmentModel segment)
        {
            Name = segment.Name;
            Description = segment.Description;
            CategoryId = segment.CategoryId;
        }
    }
}
