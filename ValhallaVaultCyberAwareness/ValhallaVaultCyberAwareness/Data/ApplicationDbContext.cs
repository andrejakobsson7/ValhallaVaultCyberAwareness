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
            SeedCategoryData(builder);
            SeedSegmentData(builder);
            SeedSubCategoryData(builder);
            SeedQuestionData(builder);
            SeedAnswerData(builder);
        }

        private void SeedCategoryData(ModelBuilder builder)
        {
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
        }

        private void SeedSegmentData(ModelBuilder builder)
        {
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
        }

        private void SeedSubCategoryData(ModelBuilder builder)
        {
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
        }
        private void SeedQuestionData(ModelBuilder builder)
        {
            builder.Entity<QuestionModel>()
            .HasData(
            new QuestionModel()
            {
                Id = 1,
                Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank. Personen ber dig bekräfta ditt kontonummer och lösenord för att \"säkerställa din kontos säkerhet\" efter en påstådd säkerhetsincident. Hur bör du tolka denna situation?",
                Explanation = "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri.",
                SubCategoryId = 1,
            },
            new QuestionModel()
            {
                Id = 2,
                Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida, börjar personen berätta om en plötslig finansiell kris och ber om din hjälp genom att överföra pengar. Vad indikerar detta mest sannolikt?",
                Explanation = "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri.",
                SubCategoryId = 2,
            },
            new QuestionModel()
            {
                Id = 3,
                Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag som påstås ha en revolutionerande ny teknologi, med garantier om exceptionellt hög avkastning på mycket kort tid. Hur bör du förhålla dig till erbjudandet?",
                Explanation = "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier.",
                SubCategoryId = 3,
            },
            new QuestionModel()
            {
                Id = 4,
                Question = "Efter en online-shoppingrunda märker du oidentifierade transaktioner på ditt kreditkortsutdrag från företag du aldrig handlat från. Vad indikerar detta mest sannolikt?",
                Explanation = "Oidentifierade transaktioner på ditt kreditkortsutdrag är en stark indikation på att ditt kortnummer har komprometterats och använts för obehöriga köp, vilket är typiskt för kreditkortsbedrägeri.",
                SubCategoryId = 4,
            },
            new QuestionModel()
            {
                Id = 5,
                Question = "Inom företaget märker man att konfidentiella dokument regelbundet läcker ut till konkurrenter. Efter en intern granskning upptäcks det att en anställd omedvetet har installerat skadlig programvara genom att klicka på en länk i ett phishing-e-postmeddelande. Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?",
                Explanation = "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor.",
                SubCategoryId = 5
            },
            new QuestionModel()
            {
                Id = 6,
                Question = "Inom företaget upptäckts det en sårbarhet i vår programvara som kunde möjliggöra obehörig åtkomst till användardata. Företaget har inte omedelbart en lösning. Vilken är den mest lämpliga första åtgärden?",
                Explanation = "Transparent kommunikation och rådgivning om tillfälliga åtgärder är avgörande för att skydda användarna medan en permanent lösning utvecklas.",
                SubCategoryId = 6
            },
            new QuestionModel()
            {
                Id = 7,
                Question = "Vårt företag blir måltavla för en DDoS-attack som överväldigar våra servrar och gör våra tjänster otillgängliga för kunder. Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?",
                Explanation = "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper.",
                SubCategoryId = 7
            },
            new QuestionModel()
            {
                Id = 8,
                Question = "Med övergången till distansarbete upptäcker vårt företag en ökning av säkerhetsincidenter, inklusive obehörig åtkomst till företagsdata. Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?",
                Explanation = "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö.",
                SubCategoryId = 8
            },
            new QuestionModel()
            {
                Id = 9,
                Question = "Hälsovårdsmyndigheten utsätts för ett cyberangrepp som krypterar patientdata och kräver lösen för att återställa åtkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta för?",
                Explanation = "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård.",
                SubCategoryId = 9
            },
            new QuestionModel()
            {
                Id = 10,
                Question = "Det globala fraktbolaget Maersk blev offer för ett omfattande cyberangrepp som avsevärt störde deras verksamhet världen över. Vilken typ av malware var primärt ansvarig för denna incident?",
                Explanation = "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system. \r\n\r\nMaersk rapporterade att företaget led ekonomiska förluster på grund av NotPetya ransomware-angreppet som uppskattades till cirka 300 miljoner USD. Denna siffra reflekterar de omfattande kostnaderna för störningar i deras globala verksamheter, återställande av system och data, samt förlust av affärer under tiden systemen var nere. NotPetya-angreppet anses vara ett av de mest kostsamma cyberangreppen mot ett enskilt företag och tjänar som en kraftfull påminnelse om de potentiella konsekvenserna av cyberhot. ",
                SubCategoryId = 10
            },
            new QuestionModel()
            {
                Id = 11,
                Question = "Regeringen upptäcker att känslig politisk kommunikation har läckt och misstänker elektronisk övervakning. Vilket fenomen beskriver bäst denna situation?",
                Explanation = "Cyberspionage avser aktiviteter där aktörer, ofta statliga, engagerar sig i övervakning och datainsamling genom cybermedel för att erhålla hemlig information utan målets medgivande, typiskt för politiska, militära eller ekonomiska fördelar.",
                SubCategoryId = 36
            },
            new QuestionModel()
            {
                Id = 12,
                Question = "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day sårbarheter för att infiltrera deras nätverk och stjäla oerhört viktig data. Vilken metod för cyberspionage används sannolikt här?",
                Explanation = "Riktade cyberattacker som utnyttjar noll-dagars Zero-day sårbarheter är en avancerad metod för cyberspionage där angriparen specifikt riktar in sig på ett mål för att komma åt känslig information eller data genom att utnyttja tidigare okända sårbarheter i programvara.",
                SubCategoryId = 37
            },
            new QuestionModel()
            {
                Id = 13,
                Question = "Regeringen i Sverige ökar sitt interna säkerhetsprotokoll för att skydda sig mot utländska underrättelsetjänsters infiltration. Vilken lagstiftning ger ramverket för detta skydd?",
                Explanation = "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot. Lagen ställer krav på säkerhetsskyddsåtgärder för verksamheter av betydelse för Sveriges säkerhet.",
                SubCategoryId = 38
            },
            new QuestionModel()
            {
                Id = 14,
                Question = "Lunds universitet upptäcker att forskningsdata om ny teknologi har stulits. Undersökningar tyder på en välorganiserad grupp med kopplingar till en utländsk stat. Vilken typ av aktör ligger sannolikt bakom detta?",
                Explanation = "Statssponsrade hackers är aktörer som arbetar på uppdrag av eller med stöd från en regering för att genomföra cyberspionage, ofta riktat mot utländska intressen, organisationer eller regeringar för att få strategiska fördelar.",
                SubCategoryId = 39
            },
            new QuestionModel()
            {
                Id = 15,
                Question = "Du får ett e-postmeddelande som ser ut att komma från din bank. Det ber dig klicka på en länk och logga in på ditt konto för att uppdatera din information. Vad bör du göra?",
                Explanation = "Klicka aldrig på länkar som uppges komma från banker via e-post.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 16,
                Question = "Du använder din kreditkort på en betalterminal i en butik. Någon har placerat en skimming-enhet på terminalen för att stjäla kortinformation. Vad bör du vara vaksam på?",
                Explanation = "Skimming är en metod där bedragare placerar en enhet på en betalterminal för att stjäla kortinformation. Genom att inspektera terminalen kan du upptäcka ovanliga tillbehör eller lösa delar som kan indikera att skimming-enheten är närvarande.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 17,
                Question = "Du får ett meddelande om en större transaktion på ditt kreditkort som du inte har gjort. Vad bör du göra?",
                Explanation = "Om du ser en större transaktion på ditt kreditkort som du inte har gjort, bör du agera snabbt. Att kontakta din kreditkortsutgivare direkt hjälper till att förhindra ytterligare skada och identifiera eventuellt bedrägeri.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 18,
                Question = "Du får en e-post med en bifogad faktura från ett företag du inte känner till. Vad bör du göra?",
                Explanation = "Att öppna bifogade fakturor från okända avsändare kan vara farligt. Radera e-postmeddelandet för att undvika att utsätta dig för skadlig kod eller bedrägeriförsök.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 19,
                Question = "Du ser någon slarvigt lämna sitt kreditkort på ett cafébord. Vad bör du göra?",
                Explanation = "Att ta någon annans kreditkort och använda det är olagligt och oetiskt. Lämna kortet där du hittade det eller ge det till personalen för att returnera det till ägaren.",
                SubCategoryId = 1
            },
            new QuestionModel
            {
                Id = 20,
                Question = "Du har flera automatiska betalningar kopplade till ditt kreditkort. Vad bör du göra om du byter kreditkort?",
                Explanation = "Om du byter kreditkort är det viktigt att uppdatera betalningsuppgifterna för alla automatiska betalningar. Annars kan du missa betalningar och få påminnelser eller avgifter.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 21,
                Question = "Vad är ett romansbedrägeri?",
                Explanation = "Ett romansbedrägeri är när en bedragare inleder en romantisk relation med någon i syfte att lura hen på pengar. Det sker oftast på internet, till exempel på sociala medier samt dejtingsidor och dejtingappar.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 22,
                Question = "Vilka typiska drag bör du vara uppmärksam på hos en romansbedragare?",
                Explanation = "Uppmärksamma typiska drag för en romansbedragare, såsom statusyrken, konstlade formuleringar eller slarvigt språkbruk.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 23,
                Question = "Vad krävs för att någon ska åtalas för romansbedrägeri?",
                Explanation = "Romansbedrägeri är brottsligt när någon inleder en kärleksrelation med dig för att lura dig på pengar. Åtal kan väckas om det finns bevis för detta bedrägeri.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 24,
                Question = "Vad bör du göra om du misstänker att du blivit utsatt för romansbedrägeri på nätet?",
                Explanation = "Om du blivit lurad av kärleken du träffat på nätet bör du lista ut vad du ska göra när du blivit utsatt och vart du ska vända dig för hjälp.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 25,
                Question = "Hur skyddar du dig mot romansbedrägeri?",
                Explanation = "Det finns flera saker du kan göra för att skydda dig mot romansbedrägeri. Följ tips och råd om hur du kan undvika att bli lurad.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 26,
                Question = "Vad är ett investeringsbedrägeri?",
                Explanation = "Ett investeringsbedrägeri innebär att någon lurar andra att köpa värdepapper som egentligen inte har något värde eller som är väldigt svåra att värdera. Det kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och ädelstenar.",
                SubCategoryId = 3
            },
            new QuestionModel()
            {
                Id = 27,
                Question = "Vilka varningssignaler bör du vara uppmärksam på vid investeringserbjudanden?",
                Explanation = "Var uppmärksam på varningssignaler som hög avkastning utan risk, bristande dokumentation, och orealistiska löften. Bedragare lockar ofta med snabba vinster och undviker att ge tydlig information om investeringen.",
                SubCategoryId = 3
            },
            new QuestionModel()
            {
                Id = 28,
                Question = "Hur kan du skydda dig mot investeringsbedrägeri?",
                Explanation = "För att skydda dig mot investeringsbedrägeri bör du vara skeptisk mot orealistiska löften, göra grundlig research om investeringen, och undvika att agera impulsivt. Kontrollera även att företaget har tillstånd från Finansinspektionen.",
                SubCategoryId = 3
            },
            new QuestionModel()
            {
                Id = 29,
                Question = "Vad bör du göra om du misstänker att du blivit utsatt för investeringsbedrägeri?",
                Explanation = "Om du misstänker att du blivit utsatt för investeringsbedrägeri bör du omedelbart kontakta Polisen och Finansinspektionen. Samla all relevant information och undvik att göra fler transaktioner med bedragaren.",
                SubCategoryId = 3
            });
        }
        private void SeedAnswerData(ModelBuilder builder)
        {
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
                },
                new AnswerModel()
                {
                    Id = 43,
                    Answer = "Klicka på länken och logga in för att uppdatera din information.",
                    IsCorrect = false,
                    QuestionId = 15
                },
                new AnswerModel()
                {
                    Id = 44,
                    Answer = "Ignorera e-postmeddelandet och radera det omedelbart.",
                    IsCorrect = true,
                    QuestionId = 15
                },
                new AnswerModel()
                {
                    Id = 45,
                    Answer = "Skicka ditt kontonummer och lösenord som begärt.",
                    IsCorrect = false,
                    QuestionId = 15
                },
                new AnswerModel()
                {
                    Id = 46,
                    Answer = "Kontrollera att PIN-koden är synlig för andra.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new AnswerModel()
                {
                    Id = 47,
                    Answer = "Inspektera terminalen för ovanliga tillbehör eller lösa delar.",
                    IsCorrect = true,
                    QuestionId = 16
                },
                new AnswerModel()
                {
                    Id = 48,
                    Answer = "Använd kortet utan att oroa dig.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new AnswerModel()
                {
                    Id = 49,
                    Answer = "Ignorera det och anta att det är en felaktighet.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new AnswerModel()
                {
                    Id = 50,
                    Answer = "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.",
                    IsCorrect = true,
                    QuestionId = 17
                },
                new AnswerModel()
                {
                    Id = 51,
                    Answer = "Vänta och se om det löser sig av sig självt.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new AnswerModel()
                {
                    Id = 52,
                    Answer = "Öppna fakturan och betala den om den verkar legitim.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new AnswerModel()
                {
                    Id = 53,
                    Answer = "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.",
                    IsCorrect = true,
                    QuestionId = 18
                },
                new AnswerModel()
                {
                    Id = 54,
                    Answer = "Vänta och se om det löser sig av sig självt.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new AnswerModel()
                {
                    Id = 55,
                    Answer = "Ta kortet och använd det för egna inköp.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new AnswerModel()
                {
                    Id = 56,
                    Answer = "Ge kortet till personalen på caféet.",
                    IsCorrect = true,
                    QuestionId = 19
                },
                new AnswerModel()
                {
                    Id = 57,
                    Answer = "Klipp sönder kortet.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new AnswerModel()
                {
                    Id = 58,
                    Answer = "Glöm bort det och låt betalningarna fortsätta.",
                    IsCorrect = false,
                    QuestionId = 20
                },
                new AnswerModel()
                {
                    Id = 59,
                    Answer = "Uppdatera betalningsuppgifterna hos varje tjänsteleverantör.",
                    IsCorrect = true,
                    QuestionId = 20
                },
                new AnswerModel()
                {
                    Id = 60,
                    Answer = "Avbryt alla automatiska betalningar.",
                    IsCorrect = false,
                    QuestionId = 20
                },
                new AnswerModel()
                {
                    Id = 61,
                    Answer = "Ett romansbedrägeri är när en bedragare inleder en romantisk relation med någon i syfte att lura hen på pengar. Det sker oftast på internet, till exempel på sociala medier samt dejtingsidor och dejtingappar.",
                    IsCorrect = true,
                    QuestionId = 21
                },
                new AnswerModel()
                {
                    Id = 62,
                    Answer = "Det är när två personer fejkar en romantisk relation för att lura andra.",
                    IsCorrect = false,
                    QuestionId = 21
                },
                new AnswerModel()
                {
                    Id = 63,
                    Answer = "Det handlar om att skapa en falsk identitet för att vinna någon annans förtroende.",
                    IsCorrect = false,
                    QuestionId = 21
                },
                new AnswerModel()
                {
                    Id = 64,
                    Answer = "Statusyrken, konstlade formuleringar eller slarvigt språkbruk.",
                    IsCorrect = true,
                    QuestionId = 22
                },
                new AnswerModel()
                {
                    Id = 65,
                    Answer = "Generös gåva av blommor eller choklad.",
                    IsCorrect = false,
                    QuestionId = 22
                },
                new AnswerModel()
                {
                    Id = 66,
                    Answer = "Överdriven romantik och kärleksgestikulering.",
                    IsCorrect = false,
                    QuestionId = 22
                },
                new AnswerModel()
                {
                    Id = 67,
                    Answer = "Bevis för att personen inlett en kärleksrelation för att lura på pengar.",
                    IsCorrect = true,
                    QuestionId = 23
                },
                new AnswerModel()
                {
                    Id = 68,
                    Answer = "Att personen har skickat kärleksbrev eller romantiska meddelanden.",
                    IsCorrect = false,
                    QuestionId = 23
                },
                new AnswerModel()
                {
                    Id = 69,
                    Answer = "Att personen har använt falsk identitet på sociala medier.",
                    IsCorrect = false,
                    QuestionId = 23
                },
                new AnswerModel()
                {
                    Id = 70,
                    Answer = "Fortsätta kommunicera för att samla mer bevis.",
                    IsCorrect = false,
                    QuestionId = 24
                },
                new AnswerModel()
                {
                    Id = 71,
                    Answer = "Avsluta all kontakt med personen och blockera dem.",
                    IsCorrect = true,
                    QuestionId = 24
                },
                new AnswerModel()
                {
                    Id = 72,
                    Answer = "Dela personlig information för att testa deras äkthet.",
                    IsCorrect = false,
                    QuestionId = 24
                },
                new AnswerModel()
                {
                    Id = 73,
                    Answer = "Öppet dela dina känslor och livshistoria med okända personer.",
                    IsCorrect = false,
                    QuestionId = 25
                },
                new AnswerModel()
                {
                    Id = 74,
                    Answer = "Dela personlig information och bankuppgifter direkt.",
                    IsCorrect = false,
                    QuestionId = 25
                },
                new AnswerModel()
                {
                    Id = 75,
                    Answer = "Var skeptisk mot snabba kärleksförklaringar och ekonomiska problem.",
                    IsCorrect = true,
                    QuestionId = 25
                },
                new AnswerModel()
                {
                    Id = 76,
                    Answer = "Ett investeringsbedrägeri kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och ädelstenar.",
                    IsCorrect = false,
                    QuestionId = 26
                },
                new AnswerModel()
                {
                    Id = 77,
                    Answer = "Det är när någon lurar andra att köpa värdepapper som egentligen inte har något värde eller är svåra att värdera.",
                    IsCorrect = true,
                    QuestionId = 26
                },
                new AnswerModel()
                {
                    Id = 78,
                    Answer = "Investeringar som garanterar snabba vinster utan risk.",
                    IsCorrect = false,
                    QuestionId = 26
                },
                new AnswerModel()
                {
                    Id = 79,
                    Answer = "Hög avkastning utan risk, bristande dokumentation, orealistiska löften.",
                    IsCorrect = true,
                    QuestionId = 27
                },
                new AnswerModel()
                {
                    Id = 80,
                    Answer = "Tydlig information om investeringen, seriösa företag.",
                    IsCorrect = false,
                    QuestionId = 27
                },
                new AnswerModel()
                {
                    Id = 81,
                    Answer = "Snabba vinster och impulsivt agerande.",
                    IsCorrect = false,
                    QuestionId = 27
                },
                new AnswerModel()
                {
                    Id = 82,
                    Answer = "Var skeptisk mot orealistiska löften, gör grundlig research, undvik impulsiva beslut.",
                    IsCorrect = true,
                    QuestionId = 28
                },
                new AnswerModel()
                {
                    Id = 83,
                    Answer = "Dela personlig information och bankuppgifter direkt.",
                    IsCorrect = false,
                    QuestionId = 28
                },
                new AnswerModel()
                {
                    Id = 84,
                    Answer = "Lita på alla investeringsmöjligheter utan att kontrollera företaget.",
                    IsCorrect = false,
                    QuestionId = 28
                },
                new AnswerModel()
                {
                    Id = 85,
                    Answer = "Dela personlig information för att testa deras äkthet.",
                    IsCorrect = false,
                    QuestionId = 29
                },
                new AnswerModel()
                {
                    Id = 86,
                    Answer = "Fortsätta kommunicera för att samla mer bevis.",
                    IsCorrect = false,
                    QuestionId = 29
                },
                new AnswerModel()
                {
                    Id = 87,
                    Answer = "Avsluta all kontakt med personen och blockera dem.",
                    IsCorrect = true,
                    QuestionId = 29
                });
        }
    }
}
