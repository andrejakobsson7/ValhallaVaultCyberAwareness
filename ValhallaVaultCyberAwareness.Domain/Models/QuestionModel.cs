using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models
{
    public class QuestionModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("question")]
        public string Question { get; set; } = null!;

        //Navigation properties
        public List<AnswerModel> Answers { get; set; } = new();
    }
}
