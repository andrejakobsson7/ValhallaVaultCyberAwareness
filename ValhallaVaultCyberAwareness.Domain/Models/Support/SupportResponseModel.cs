using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models.Support
{
    public class SupportResponseModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("response")]
        public string Response { get; set; } = null!;

        [Column("supportquestion_id")]
        public int SupportQuestionId { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("admin_name")]
        public string AdminName { get; set; } = null!;

        //Navigation property
        public SupportQuestionModel? SupportQuestion { get; set; }
    }
}
