using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models.Support
{
    public class SupportQuestionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("question")]
        public string Question { get; set; } = null!;

        [Column("user_id")]
        public string UserId { get; set; } = null!;

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("is_public")]
        public bool IsPublic { get; set; }

        [Column("is_open")]
        public bool IsOpen { get; set; }

        //Navigation property
        public List<SupportResponseModel> SupportResponses { get; set; } = new();

    }
}
