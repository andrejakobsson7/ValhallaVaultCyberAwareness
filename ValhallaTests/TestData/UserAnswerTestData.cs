using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests.TestData
{
    public static class UserAnswerTestData
    {
        public static List<UserAnswers> UserAnswers { get; set; } = new()
        {
            //Kalle har 2 fel, 4 rätt (66,67%)
            new UserAnswers()
            {
                //Fel svar
                AnswerId = 43,
                UserId = "Kalle"
            },
            new UserAnswers()
            {
                //Rätt svar
                AnswerId = 47,
                UserId = "Kalle"
            },
            new UserAnswers()
            {
                //Rätt svar
                AnswerId = 50,
                UserId = "Kalle"
            },
            new UserAnswers()
            {
                //Rätt svar
                AnswerId = 53,
                UserId = "Kalle"
            },
            new UserAnswers()
            {
                //Fel svar
                AnswerId = 55,
                UserId = "Kalle"
            },
            new UserAnswers()
            {
                //Rätt svar
                AnswerId = 59,
                UserId = "Kalle"
            }
        };
    }
}
