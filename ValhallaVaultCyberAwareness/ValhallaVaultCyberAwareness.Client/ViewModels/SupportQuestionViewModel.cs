using System.ComponentModel.DataAnnotations;
using ValhallaVaultCyberAwareness.Client.Validators;
using ValhallaVaultCyberAwareness.Domain.Models.Support;


namespace ValhallaVaultCyberAwareness.Client.ViewModels
{
	public class SupportQuestionViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Ingen fråga har angivits")]
		public string? Question { get; set; }

		[Required(ErrorMessage = "Inget användarnamn har angivits")]
		public string? Username { get; set; }
		public double DaysSincePost { get; set; }
		public bool DisplayAnswers { get; set; }
		[IsBool(ErrorMessage = "Du måste acceptera att frågan publiceras")]
		public bool HasAcceptedTerms { get; set; }

		public bool QuestionHasResponses { get; set; }

		public bool IsAnsweringEnabled { get; set; }

		//Navigation property
		public List<SupportResponseModel> SupportResponses { get; set; } = new();

		public SupportQuestionViewModel(SupportQuestionModel supportQuestion)
		{
			Id = supportQuestion.Id;
			Question = supportQuestion.Question;
			Username = supportQuestion.Username;
			DaysSincePost = Math.Round((DateTime.Now - supportQuestion.Created).TotalDays);
			SupportResponses = supportQuestion.SupportResponses;
			QuestionHasResponses = SupportResponses.Count > 0;
		}

		public SupportQuestionViewModel()
		{

		}
	}
}
