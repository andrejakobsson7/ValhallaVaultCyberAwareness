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

		[Column("username")]
		public string? Username { get; set; }

		[Column("created")]
		public DateTime Created { get; set; }

		//Navigation property
		public List<SupportResponseModel> SupportResponses { get; set; } = new();

	}
}
