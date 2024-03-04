using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ValhallaVaultCyberAwareness.Data;

namespace ValhallaVaultCyberAwareness.Domain.Models
{
    //This is a join table for holding together a user's answers to questions.
    [PrimaryKey("UserId", new string[] { "AnswerId" })]
    public class UserAnswers
    {
        [ForeignKey("User")]
        [Column("user_id")]
        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
        [ForeignKey("Answer")]
        [Column("answer_id")]
        public int AnswerId { get; set; }

        //Navigation property
        public AnswerModel Answer { get; set; } = null!;
    }
}
