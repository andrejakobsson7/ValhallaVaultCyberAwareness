using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SegmentModel> Segments { get; set; }
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<UserAnswers> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SegmentModel>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Segments)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<SubCategoryModel>()
                .HasOne(s => s.Segment)
                .WithMany(s => s.SubCategories)
                .HasForeignKey(s => s.SegmentId);

            builder.Entity<QuestionModel>()
                .HasOne(q => q.SubCategory)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SubCategoryId);

            builder.Entity<AnswerModel>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);
            //Set combined key for join table UserAnswers
            //builder.Entity<UserAnswers>().HasKey(ua => new { ua.UserId, ua.AnswerId });

            ////Set many to many relationship between user and answers.

            //builder.Entity<UserAnswers>()
            //    .HasOne(ua => ua.User)
            //    .WithMany(u => u.UserAnswers)
            //    .HasForeignKey(a => a.AnswerId);

            //builder.Entity<UserAnswers>()
            //.HasOne(ua => ua.Answer)
            //.WithMany(a => a.UserAnswers)
            //.HasForeignKey(u => u.UserId);

            //Seed data
            builder.Entity<CategoryModel>()
                .HasData(
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Att skydda sig mot bedrägerier",
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = "Cybersäkerhet för företag"
                },
                new CategoryModel()
                {
                    Id = 3,
                    Name = "Cyberspionage"
                });
            builder.Entity<SegmentModel>()
                .HasData(
                new SegmentModel()
                {
                    Id = 1,
                    Name = "Del 1 - Att skydda sig mot bedrägerier",
                    CategoryId = 1,
                },
                new SegmentModel()
                {
                    Id = 2,
                    Name = "Del 2 - Att skydda sig mot bedrägerier",
                    CategoryId = 1,
                },
                new SegmentModel()
                {
                    Id = 3,
                    Name = "Del 3 - Att skydda sig mot bedrägerier",
                    CategoryId = 1,
                },

                new SegmentModel()
                {
                    Id = 4,
                    Name = "Del 1 - Cybersäkerhet för företag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 5,
                    Name = "Del 2 - Cybersäkerhet för företag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 6,
                    Name = "Del 3 - Cybersäkerhet för företag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 7,
                    Name = "Del 4 - Cybersäkerhet för företag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 8,
                    Name = "Del 1 - Cyberspionage",
                    CategoryId = 3,
                },
                new SegmentModel()
                {
                    Id = 9,
                    Name = "Del 2 - Cyberspionage",
                    CategoryId = 3
                },
                new SegmentModel()
                {
                    Id = 10,
                    Name = "Del 3 - Cyberspionage",
                    CategoryId = 3
                });


            builder.Entity<SubCategoryModel>()
                .HasData(

                new SubCategoryModel()
                {
                    Id = 1,
                    Name = "Kreditkortsbedrägeri",
                    SegmentId = 1
                },
                new SubCategoryModel()
                {
                    Id = 2,
                    Name = "Romansbedrägeri",
                    SegmentId = 1
                },
                new SubCategoryModel()
                {
                    Id = 3,
                    Name = "Investeringsbedrägeri",
                    SegmentId = 1
                },
                new SubCategoryModel()
                {
                    Id = 4,
                    Name = "Telefonbedrägeri",
                    SegmentId = 1
                },


                new SubCategoryModel()
                {
                    Id = 5,
                    Name = "Bedrägerier i hemmet",
                    SegmentId = 2
                },
                new SubCategoryModel()
                {
                    Id = 6,
                    Name = "Identitetsstöld",
                    SegmentId = 2
                },
                new SubCategoryModel()
                {
                    Id = 7,
                    Name = "Nätfiske och bluffmejl",
                    SegmentId = 2
                },
                new SubCategoryModel()
                {
                    Id = 8,
                    Name = "Investeringsbedrägeri på nätet",
                    SegmentId = 2
                },


                new SubCategoryModel()
                {
                    Id = 9,
                    Name = "Abonnemangsfällor och falska fakturor",
                    SegmentId = 3
                },
                new SubCategoryModel()
                {
                    Id = 10,
                    Name = "Ransomware",
                    SegmentId = 3
                },
                new SubCategoryModel()
                {
                    Id = 11,
                    Name = "Statistik och förhållningssätt",
                    SegmentId = 3
                },


                new SubCategoryModel()
                {
                    Id = 12,
                    Name = "Digital säkerhet på företag",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 13,
                    Name = "Risker och beredskap",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 14,
                    Name = "Aktörer inom cyberbrott",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 15,
                    Name = "Ökad digital närvaro och distansarbete",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 16,
                    Name = "Cyberangrepp mot känsliga sektorer",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 17,
                    Name = "Cyberrånet mot Mersk",
                    SegmentId = 4
                },


                new SubCategoryModel()
                {
                    Id = 18,
                    Name = "Social engineering",
                    SegmentId = 5,

                },
                new SubCategoryModel()
                {
                    Id = 19,
                    Name = "Nätfiske och skräppost",
                    SegmentId = 5,
                },
                new SubCategoryModel()
                {
                    Id = 20,
                    Name = "Vishing",
                    SegmentId = 5
                },
                new SubCategoryModel()
                {
                    Id = 21,
                    Name = "Varning för vishing",
                    SegmentId = 5
                },
                new SubCategoryModel()
                {
                    Id = 22,
                    Name = "Identifiera VD-mejl",
                    SegmentId = 5
                },
                new SubCategoryModel()
                {
                    Id = 23,
                    Name = "Öneangrepp och presentkortsbluffar",
                    SegmentId = 5
                },


                new SubCategoryModel()
                {
                    Id = 24,
                    Name = "Virus, maskar och trojaner",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 25,
                    Name = "Så kan det gå till",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 26,
                    Name = "Nätverksintrång",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 27,
                    Name = "Dataintrång",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 28,
                    Name = "Hackad!",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 29,
                    Name = "Vägarna in",
                    SegmentId = 6
                },


                new SubCategoryModel()
                {
                    Id = 30,
                    Name = "Utpressningsvirus",
                    SegmentId = 7
                },
                new SubCategoryModel()
                {
                    Id = 31,
                    Name = "Attacker mot servrar",
                    SegmentId = 7
                },
                new SubCategoryModel()
                {
                    Id = 32,
                    Name = "Cyberangrepp i Norden",
                    SegmentId = 7
                },
                new SubCategoryModel()
                {
                    Id = 33,
                    Name = "It-brottslingarnas verktyg",
                    SegmentId = 7
                },
                new SubCategoryModel()
                {
                    Id = 34,
                    Name = "Mirai, Wannacry och fallet Düsseldorf",
                    SegmentId = 7
                },
                new SubCategoryModel()
                {
                    Id = 35,
                    Name = "De sårbara molnen",
                    SegmentId = 7
                },


                new SubCategoryModel
                {
                    Id = 36,
                    Name = "Allmänt om cyberspionage",
                    SegmentId = 8
                },
                new SubCategoryModel
                {
                    Id = 37,
                    Name = "Metoder för cyberspionage",
                    SegmentId = 8
                },
                new SubCategoryModel
                {
                    Id = 38,
                    Name = "Säkerhetsskyddslagen",
                    SegmentId = 8
                },
                new SubCategoryModel
                {
                    Id = 39,
                    Name = "Cyberspionagets aktörer",
                    SegmentId = 8
                },


                new SubCategoryModel
                {
                    Id = 40,
                    Name = "Värvningsförsök",
                    SegmentId = 9
                },
                new SubCategoryModel
                {
                    Id = 41,
                    Name = "Affärsspionage",
                    SegmentId = 9
                },
                new SubCategoryModel
                {
                    Id = 42,
                    Name = "Påverkanskampanjer",
                    SegmentId = 9
                },


                new SubCategoryModel
                {
                    Id = 43,
                    Name = "Svensk underrättelsetjänst och cyberförsvar",
                    SegmentId = 10
                },
                new SubCategoryModel
                {
                    Id = 44,
                    Name = "Signalspaning, informationssäkerhet och 5G",
                    SegmentId = 10
                },
                new SubCategoryModel
                {
                    Id = 45,
                    Name = "Samverkan mot cyberspionage",
                    SegmentId = 10
                });

            builder.Entity<QuestionModel>()
                .HasData(
                new QuestionModel()
                {
                    Id = 1,
                    Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank. Personen ber dig bekräfta ditt kontonummer och lösenord för att \"säkerställa din kontos säkerhet\" efter en påstådd säkerhetsincident. Hur bör du tolka denna situation?",
                    SubCategoryId = 1,
                },
                new QuestionModel()
                {
                    Id = 2,
                    Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida, börjar personen berätta om en plötslig finansiell kris och ber om din hjälp genom att överföra pengar. Vad indikerar detta mest sannolikt?",
                    SubCategoryId = 2,
                },
                new QuestionModel()
                {
                    Id = 3,
                    Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag som påstås ha en revolutionerande ny teknologi, med garantier om exceptionellt hög avkastning på mycket kort tid. Hur bör du förhålla dig till erbjudandet?",
                    SubCategoryId = 3,
                },
                new QuestionModel()
                {
                    Id = 4,
                    Question = "Efter en online-shoppingrunda märker du oidentifierade transaktioner på ditt kreditkortsutdrag från företag du aldrig handlat från. Vad indikerar detta mest sannolikt?",
                    SubCategoryId = 4,
                },
                new QuestionModel()
                {
                    Id = 5,
                    Question = "Inom företaget märker man att konfidentiella dokument regelbundet läcker ut till konkurrenter. Efter en intern granskning upptäcks det att en anställd omedvetet har installerat skadlig programvara genom att klicka på en länk i ett phishing-e-postmeddelande. Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?",
                    SubCategoryId = 5
                },
                new QuestionModel()
                {
                    Id = 6,
                    Question = "Inom företaget upptäckts det en sårbarhet i vår programvara som kunde möjliggöra obehörig åtkomst till användardata. Företaget har inte omedelbart en lösning. Vilken är den mest lämpliga första åtgärden?",
                    SubCategoryId = 6
                },
                new QuestionModel()
                {
                    Id = 7,
                    Question = "Vårt företag blir måltavla för en DDoS-attack som överväldigar våra servrar och gör våra tjänster otillgängliga för kunder. Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?",
                    SubCategoryId = 7
                },
                new QuestionModel()
                {
                    Id = 8,
                    Question = "Med övergången till distansarbete upptäcker vårt företag en ökning av säkerhetsincidenter, inklusive obehörig åtkomst till företagsdata. Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?",
                    SubCategoryId = 8
                },
                new QuestionModel()
                {
                    Id = 9,
                    Question = "Hälsovårdsmyndigheten utsätts för ett cyberangrepp som krypterar patientdata och kräver lösen för att återställa åtkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta för?",
                    SubCategoryId = 9
                },
                new QuestionModel()
                {
                    Id = 10,
                    Question = "Det globala fraktbolaget Maersk blev offer för ett omfattande cyberangrepp som avsevärt störde deras verksamhet världen över. Vilken typ av malware var primärt ansvarig för denna incident?",
                    SubCategoryId = 10
                },
                new QuestionModel()
                {
                    Id = 11,
                    Question = "Regeringen upptäcker att känslig politisk kommunikation har läckt och misstänker elektronisk övervakning. Vilket fenomen beskriver bäst denna situation?",
                    SubCategoryId = 36
                },
                new QuestionModel()
                {
                    Id = 12,
                    Question = "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day sårbarheter för att infiltrera deras nätverk och stjäla oerhört viktig data. Vilken metod för cyberspionage används sannolikt här?",
                    SubCategoryId = 37
                },
                new QuestionModel()
                {
                    Id = 13,
                    Question = "Regeringen i Sverige ökar sitt interna säkerhetsprotokoll för att skydda sig mot utländska underrättelsetjänsters infiltration. Vilken lagstiftning ger ramverket för detta skydd?",
                    SubCategoryId = 38
                },
                new QuestionModel()
                {
                    Id = 14,
                    Question = "Lunds universitet upptäcker att forskningsdata om ny teknologi har stulits. Undersökningar tyder på en välorganiserad grupp med kopplingar till en utländsk stat. Vilken typ av aktör ligger sannolikt bakom detta?",
                    SubCategoryId = 39
                });

            builder.Entity<AnswerModel>()
                .HasData(
                new AnswerModel()
                {
                    Id = 1,
                    Answer = "Ett legitimt försök från banken att skydda ditt konto",
                    IsCorrect = false,
                    QuestionId = 1

                },
                new AnswerModel()
                {
                    Id = 2,
                    Answer = "En informationsinsamling för en marknadsundersökning",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new AnswerModel()
                {
                    Id = 3,
                    Answer = "Ett potentiellt telefonbedrägeri",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new AnswerModel()
                {
                    Id = 4,
                    Answer = "En legitim begäran om hjälp från en person i nöd",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new AnswerModel()
                {
                    Id = 5,
                    Answer = "Ett romansbedrägeri",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new AnswerModel()
                {
                    Id = 6,
                    Answer = "En tillfällig ekonomisk svårighet",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new AnswerModel()
                {
                    Id = 7,
                    Answer = "Genomföra omedelbar investering för att inte missa möjligheten",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new AnswerModel()
                {
                    Id = 8,
                    Answer = "Investeringsbedrägeri",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new AnswerModel()
                {
                    Id = 9,
                    Answer = "Begära mer information för att utföra en noggrann \"due diligence\"",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new AnswerModel()
                {
                    Id = 10,
                    Answer = "Ett misstag av kreditkortsföretaget",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new AnswerModel()
                {
                    Id = 11,
                    Answer = "Kreditkortsbedrägeri",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new AnswerModel()
                {
                    Id = 12,
                    Answer = "Obehöriga köp av en familjemedlem",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new AnswerModel()
                {
                    Id = 13,
                    Answer = "Utbildning i digital säkerhet för alla anställda",
                    IsCorrect = true,
                    QuestionId = 5
                },
                new AnswerModel()
                {
                    Id = 14,
                    Answer = "Installera en starkare brandvägg",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new AnswerModel()
                {
                    Id = 15,
                    Answer = "Byta ut all IT-utrustning",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new AnswerModel()
                {
                    Id = 16,
                    Answer = "Informera alla användare om sårbarheten och rekommendera temporära skyddsåtgärder",
                    IsCorrect = true,
                    QuestionId = 6
                },
                new AnswerModel()
                {
                    Id = 17,
                    Answer = "Ignorera problemet tills en patch kan utvecklas",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new AnswerModel()
                {
                    Id = 18,
                    Answer = "Stänga ner tjänsten tillfälligt",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new AnswerModel()
                {
                    Id = 19,
                    Answer = "En enskild hackare med ett personligt vendetta",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new AnswerModel()
                {
                    Id = 20,
                    Answer = "En konkurrerande företagsentitet",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new AnswerModel()
                {
                    Id = 21,
                    Answer = "Organiserade cyberbrottsliga grupper",
                    IsCorrect = true,
                    QuestionId = 7
                },
                new AnswerModel()
                {
                    Id = 22,
                    Answer = "Återgå till kontorsarbete",
                    IsCorrect = false,
                    QuestionId = 8
                },
                new AnswerModel()
                {
                    Id = 23,
                    Answer = "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst",
                    IsCorrect = true,
                    QuestionId = 8
                },
                new AnswerModel()
                {
                    Id = 24,
                    Answer = "Förbjuda användning av personliga enheter för arbete",
                    IsCorrect = false,
                    QuestionId = 8
                },
                new AnswerModel()
                {
                    Id = 25,
                    Answer = "Phishing",
                    IsCorrect = false,
                    QuestionId = 9
                },
                new AnswerModel()
                {
                    Id = 26,
                    Answer = "Ransomware",
                    IsCorrect = true,
                    QuestionId = 9
                },
                new AnswerModel()
                {
                    Id = 27,
                    Answer = "Spyware",
                    IsCorrect = false,
                    QuestionId = 9
                },
                new AnswerModel()
                {
                    Id = 28,
                    Answer = "Spyware",
                    IsCorrect = false,
                    QuestionId = 10
                },
                new AnswerModel()
                {
                    Id = 29,
                    Answer = "Ransomware",
                    IsCorrect = true,
                    QuestionId = 10
                },
                new AnswerModel()
                {
                    Id = 30,
                    Answer = "Adware",
                    IsCorrect = false,
                    QuestionId = 10
                },
                new AnswerModel
                {
                    Id = 31,
                    Answer = "Cyberkriminalitet",
                    IsCorrect = false,
                    QuestionId = 11
                },
                new AnswerModel
                {
                    Id = 32,
                    Answer = "Cyberspionage",
                    IsCorrect = true,
                    QuestionId = 11
                },
                new AnswerModel
                {
                    Id = 33,
                    Answer = "Cyberterrorism",
                    IsCorrect = false,
                    QuestionId = 11
                },
                new AnswerModel
                {
                    Id = 34,
                    Answer = "Social ingenjörskonst",
                    IsCorrect = false,
                    QuestionId = 12
                },
                new AnswerModel
                {
                    Id = 35,
                    Answer = "Massövervakning",
                    IsCorrect = false,
                    QuestionId = 12
                },
                new AnswerModel
                {
                    Id = 36,
                    Answer = "Riktade cyberattacker",
                    IsCorrect = true,
                    QuestionId = 12
                },
                new AnswerModel
                {
                    Id = 37,
                    Answer = "GDPR",
                    IsCorrect = false,
                    QuestionId = 13
                },
                new AnswerModel
                {
                    Id = 38,
                    Answer = "Säkerhetsskyddslagen",
                    IsCorrect = true,
                    QuestionId = 13
                },
                new AnswerModel
                {
                    Id = 39,
                    Answer = "IT-säkerhetslagen",
                    IsCorrect = false,
                    QuestionId = 13
                },
                new AnswerModel
                {
                    Id = 40,
                    Answer = "Oberoende hackare",
                    IsCorrect = false,
                    QuestionId = 14
                },
                new AnswerModel
                {
                    Id = 41,
                    Answer = "Aktivistgrupper",
                    IsCorrect = false,
                    QuestionId = 14
                },
                new AnswerModel
                {
                    Id = 42,
                    Answer = "Statssponsrade hackers",
                    IsCorrect = true,
                    QuestionId = 14
                });

            builder.Entity<UserAnswers>()
                .HasData(
                new UserAnswers()
                {
                    UserId = "1872fec2-27e0-4aa2-b876-5de387b62fbc",
                    AnswerId = 2
                },
                new UserAnswers()
                {
                    UserId = "1872fec2-27e0-4aa2-b876-5de387b62fbc",
                    AnswerId = 4
                },
                new UserAnswers()
                {
                    UserId = "1872fec2-27e0-4aa2-b876-5de387b62fbc",
                    AnswerId = 8
                },
                new UserAnswers()
                {
                    UserId = "1872fec2-27e0-4aa2-b876-5de387b62fbc",
                    AnswerId = 11
                });
        }
    }
}
