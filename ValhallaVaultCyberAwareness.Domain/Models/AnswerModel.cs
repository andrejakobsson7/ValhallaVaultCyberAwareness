using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ValhallaVaultCyberAwareness.Domain.Models
{
    public class AnswerModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("is_correct")]
        public bool IsCorrect { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        //Navigation property
        public QuestionModel Question { get; set; } = null!;
        public List<UserAnswers> UserAnswers { get; set; } = new();
    }
}
