using ValhallaVaultCyberAwareness.Domain.Models.Support;

namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
	public class SupportQuestionViewModel
	{
		public int Id { get; set; }
		public string? Question { get; set; }
		public string? Username { get; set; }
		public double DaysSincePost { get; set; }
		public bool DisplayAnswers { get; set; }

		//Navigation property
		public List<SupportResponseModel> SupportResponses { get; set; } = new();

		public SupportQuestionViewModel(SupportQuestionModel supportQuestion)
		{
			Id = supportQuestion.Id;
			Question = supportQuestion.Question;
			Username = supportQuestion.Username;
			DaysSincePost = Math.Round((DateTime.Now - supportQuestion.Created).TotalDays);
			SupportResponses = supportQuestion.SupportResponses;
		}
	}
}
