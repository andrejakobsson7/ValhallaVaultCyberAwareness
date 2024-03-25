using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests.TestData
{
    public static class QuestionTestData
    {
        public static List<QuestionModel> Questions { get; set; } = new()
        {
            new QuestionModel()
            {
                Id = 15,
                Question = "Du får ett e-postmeddelande som ser ut att komma från din bank. Det ber dig klicka på en länk och logga in på ditt konto för att uppdatera din information. Vad bör du göra?",
                Explanation = "Klicka aldrig på länkar som uppges komma från banker via e-post.",
                SubCategoryId = 1,
                SubCategory = SubCategoryTestData.SubCategories.First(s => s.Id == 1),
                Answers = AnswerTestData.Answers.Where(a => a.QuestionId == 15).ToList()
            },
            new QuestionModel()
            {
                Id = 16,
                Question = "Du använder din kreditkort på en betalterminal i en butik. Någon har placerat en skimming-enhet på terminalen för att stjäla kortinformation. Vad bör du vara vaksam på?",
                Explanation = "Skimming är en metod där bedragare placerar en enhet på en betalterminal för att stjäla kortinformation. Genom att inspektera terminalen kan du upptäcka ovanliga tillbehör eller lösa delar som kan indikera att skimming-enheten är närvarande.",
                SubCategoryId = 1,
                SubCategory = SubCategoryTestData.SubCategories.First(s => s.Id == 1),
                Answers= AnswerTestData.Answers.Where(a => a.QuestionId == 16).ToList()
            },
            new QuestionModel()
            {
                Id = 17,
                Question = "Du får ett meddelande om en större transaktion på ditt kreditkort som du inte har gjort. Vad bör du göra?",
                Explanation = "Om du ser en större transaktion på ditt kreditkort som du inte har gjort, bör du agera snabbt. Att kontakta din kreditkortsutgivare direkt hjälper till att förhindra ytterligare skada och identifiera eventuellt bedrägeri.",
                SubCategoryId = 1,
                SubCategory = SubCategoryTestData.SubCategories.First(s => s.Id == 1),
                Answers = AnswerTestData.Answers.Where(a => a.QuestionId == 17).ToList()

            },
            new QuestionModel()
            {
                Id = 18,
                Question = "Du får en e-post med en bifogad faktura från ett företag du inte känner till. Vad bör du göra?",
                Explanation = "Att öppna bifogade fakturor från okända avsändare kan vara farligt. Radera e-postmeddelandet för att undvika att utsätta dig för skadlig kod eller bedrägeriförsök.",
                SubCategoryId = 1,
                SubCategory = SubCategoryTestData.SubCategories.First(s => s.Id == 1),
                Answers = AnswerTestData.Answers.Where(a => a.QuestionId == 18).ToList()
            },
            new QuestionModel()
            {
                Id = 19,
                Question = "Du ser någon slarvigt lämna sitt kreditkort på ett cafébord. Vad bör du göra?",
                Explanation = "Att ta någon annans kreditkort och använda det är olagligt och oetiskt. Lämna kortet där du hittade det eller ge det till personalen för att returnera det till ägaren.",
                SubCategoryId = 1,
                SubCategory = SubCategoryTestData.SubCategories.First(s => s.Id == 1),
                Answers = AnswerTestData.Answers.Where(a => a.QuestionId == 19).ToList()

            },
            new QuestionModel
            {
                Id = 20,
                Question = "Du har flera automatiska betalningar kopplade till ditt kreditkort. Vad bör du göra om du byter kreditkort?",
                Explanation = "Om du byter kreditkort är det viktigt att uppdatera betalningsuppgifterna för alla automatiska betalningar. Annars kan du missa betalningar och få påminnelser eller avgifter.",
                SubCategoryId = 1,
                SubCategory = SubCategoryTestData.SubCategories.First(s => s.Id == 1),
                Answers = AnswerTestData.Answers.Where(a => a.QuestionId == 20).ToList()
            }
        };
    }
}
