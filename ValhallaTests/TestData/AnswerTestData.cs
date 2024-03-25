using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests.TestData
{
    public static class AnswerTestData
    {
        public static List<AnswerModel> Answers { get; set; } = new()
        {
                new AnswerModel()
                {
                    Id = 43,
                    Answer = "Klicka på länken och logga in för att uppdatera din information.",
                    IsCorrect = false,
                    QuestionId = 15,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 43 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 44,
                    Answer = "Ignorera e-postmeddelandet och radera det omedelbart.",
                    IsCorrect = true,
                    QuestionId = 15,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 44 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 45,
                    Answer = "Skicka ditt kontonummer och lösenord som begärt.",
                    IsCorrect = false,
                    QuestionId = 15,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 45 && ua.UserId == "Kalle").ToList(),

                },
                new AnswerModel()
                {
                    Id = 46,
                    Answer = "Kontrollera att PIN-koden är synlig för andra.",
                    IsCorrect = false,
                    QuestionId = 16,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 46 && ua.UserId == "Kalle").ToList(),

                },
                new AnswerModel()
                {
                    Id = 47,
                    Answer = "Inspektera terminalen för ovanliga tillbehör eller lösa delar.",
                    IsCorrect = true,
                    QuestionId = 16,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 47 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 48,
                    Answer = "Använd kortet utan att oroa dig.",
                    IsCorrect = false,
                    QuestionId = 16,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 48 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 49,
                    Answer = "Ignorera det och anta att det är en felaktighet.",
                    IsCorrect = false,
                    QuestionId = 17,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 49 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 50,
                    Answer = "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.",
                    IsCorrect = true,
                    QuestionId = 17,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 50 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 51,
                    Answer = "Vänta och se om det löser sig av sig självt.",
                    IsCorrect = false,
                    QuestionId = 17,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 51 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 52,
                    Answer = "Öppna fakturan och betala den om den verkar legitim.",
                    IsCorrect = false,
                    QuestionId = 18,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 52 && ua.UserId == "Kalle").ToList(),

                },
                new AnswerModel()
                {
                    Id = 53,
                    Answer = "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.",
                    IsCorrect = true,
                    QuestionId = 18,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 53 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 54,
                    Answer = "Vänta och se om det löser sig av sig självt.",
                    IsCorrect = false,
                    QuestionId = 18,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 54 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 55,
                    Answer = "Ta kortet och använd det för egna inköp.",
                    IsCorrect = false,
                    QuestionId = 19,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 55 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 56,
                    Answer = "Ge kortet till personalen på caféet.",
                    IsCorrect = true,
                    QuestionId = 19,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 56 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 57,
                    Answer = "Klipp sönder kortet.",
                    IsCorrect = false,
                    QuestionId = 19,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 57 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 58,
                    Answer = "Glöm bort det och låt betalningarna fortsätta.",
                    IsCorrect = false,
                    QuestionId = 20,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 58 && ua.UserId == "Kalle").ToList(),
                },
                new AnswerModel()
                {
                    Id = 59,
                    Answer = "Uppdatera betalningsuppgifterna hos varje tjänsteleverantör.",
                    IsCorrect = true,
                    QuestionId = 20,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 59 && ua.UserId == "Kalle").ToList(),

                },
                new AnswerModel()
                {
                    Id = 60,
                    Answer = "Avbryt alla automatiska betalningar.",
                    IsCorrect = false,
                    QuestionId = 20,
                    UserAnswers = UserAnswerTestData.UserAnswers.Where(ua => ua.AnswerId == 60 && ua.UserId == "Kalle").ToList(),
                }
        };
    }
}
