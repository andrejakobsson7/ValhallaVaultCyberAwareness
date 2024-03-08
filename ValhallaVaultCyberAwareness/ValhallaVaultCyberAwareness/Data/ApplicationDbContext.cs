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
                    Name = "Att skydda sig mot bedr�gerier",
                },
                new CategoryModel()
                {
                    Id = 2,
                    Name = "Cybers�kerhet f�r f�retag"
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
                    Name = "Del 1 - Att skydda sig mot bedr�gerier",
                    CategoryId = 1,
                },
                new SegmentModel()
                {
                    Id = 2,
                    Name = "Del 2 - Att skydda sig mot bedr�gerier",
                    CategoryId = 1,
                },
                new SegmentModel()
                {
                    Id = 3,
                    Name = "Del 3 - Att skydda sig mot bedr�gerier",
                    CategoryId = 1,
                },

                new SegmentModel()
                {
                    Id = 4,
                    Name = "Del 1 - Cybers�kerhet f�r f�retag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 5,
                    Name = "Del 2 - Cybers�kerhet f�r f�retag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 6,
                    Name = "Del 3 - Cybers�kerhet f�r f�retag",
                    CategoryId = 2,
                },
                new SegmentModel()
                {
                    Id = 7,
                    Name = "Del 4 - Cybers�kerhet f�r f�retag",
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
                    Name = "Kreditkortsbedr�geri",
                    SegmentId = 1
                },
                new SubCategoryModel()
                {
                    Id = 2,
                    Name = "Romansbedr�geri",
                    SegmentId = 1
                },
                new SubCategoryModel()
                {
                    Id = 3,
                    Name = "Investeringsbedr�geri",
                    SegmentId = 1
                },
                new SubCategoryModel()
                {
                    Id = 4,
                    Name = "Telefonbedr�geri",
                    SegmentId = 1
                },


                new SubCategoryModel()
                {
                    Id = 5,
                    Name = "Bedr�gerier i hemmet",
                    SegmentId = 2
                },
                new SubCategoryModel()
                {
                    Id = 6,
                    Name = "Identitetsst�ld",
                    SegmentId = 2
                },
                new SubCategoryModel()
                {
                    Id = 7,
                    Name = "N�tfiske och bluffmejl",
                    SegmentId = 2
                },
                new SubCategoryModel()
                {
                    Id = 8,
                    Name = "Investeringsbedr�geri p� n�tet",
                    SegmentId = 2
                },


                new SubCategoryModel()
                {
                    Id = 9,
                    Name = "Abonnemangsf�llor och falska fakturor",
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
                    Name = "Statistik och f�rh�llningss�tt",
                    SegmentId = 3
                },


                new SubCategoryModel()
                {
                    Id = 12,
                    Name = "Digital s�kerhet p� f�retag",
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
                    Name = "Akt�rer inom cyberbrott",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 15,
                    Name = "�kad digital n�rvaro och distansarbete",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 16,
                    Name = "Cyberangrepp mot k�nsliga sektorer",
                    SegmentId = 4
                },
                new SubCategoryModel()
                {
                    Id = 17,
                    Name = "Cyberr�net mot Mersk",
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
                    Name = "N�tfiske och skr�ppost",
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
                    Name = "Varning f�r vishing",
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
                    Name = "�neangrepp och presentkortsbluffar",
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
                    Name = "S� kan det g� till",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 26,
                    Name = "N�tverksintr�ng",
                    SegmentId = 6
                },
                new SubCategoryModel()
                {
                    Id = 27,
                    Name = "Dataintr�ng",
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
                    Name = "V�garna in",
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
                    Name = "Mirai, Wannacry och fallet D�sseldorf",
                    SegmentId = 7
                },
                new SubCategoryModel()
                {
                    Id = 35,
                    Name = "De s�rbara molnen",
                    SegmentId = 7
                },


                new SubCategoryModel
                {
                    Id = 36,
                    Name = "Allm�nt om cyberspionage",
                    SegmentId = 8
                },
                new SubCategoryModel
                {
                    Id = 37,
                    Name = "Metoder f�r cyberspionage",
                    SegmentId = 8
                },
                new SubCategoryModel
                {
                    Id = 38,
                    Name = "S�kerhetsskyddslagen",
                    SegmentId = 8
                },
                new SubCategoryModel
                {
                    Id = 39,
                    Name = "Cyberspionagets akt�rer",
                    SegmentId = 8
                },


                new SubCategoryModel
                {
                    Id = 40,
                    Name = "V�rvningsf�rs�k",
                    SegmentId = 9
                },
                new SubCategoryModel
                {
                    Id = 41,
                    Name = "Aff�rsspionage",
                    SegmentId = 9
                },
                new SubCategoryModel
                {
                    Id = 42,
                    Name = "P�verkanskampanjer",
                    SegmentId = 9
                },


                new SubCategoryModel
                {
                    Id = 43,
                    Name = "Svensk underr�ttelsetj�nst och cyberf�rsvar",
                    SegmentId = 10
                },
                new SubCategoryModel
                {
                    Id = 44,
                    Name = "Signalspaning, informationss�kerhet och 5G",
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
                    Question = "Du f�r ett ov�ntat telefonsamtal fr�n n�gon som p�st�r sig vara fr�n din bank. Personen ber dig bekr�fta ditt kontonummer och l�senord f�r att \"s�kerst�lla din kontos s�kerhet\" efter en p�st�dd s�kerhetsincident. Hur b�r du tolka denna situation?",
                    SubCategoryId = 1,
                },
                new QuestionModel()
                {
                    Id = 2,
                    Question = "Efter flera m�nader av daglig kommunikation med n�gon du tr�ffade p� en datingsida, b�rjar personen ber�tta om en pl�tslig finansiell kris och ber om din hj�lp genom att �verf�ra pengar. Vad indikerar detta mest sannolikt?",
                    SubCategoryId = 2,
                },
                new QuestionModel()
                {
                    Id = 3,
                    Question = "Du f�r ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-f�retag som p�st�s ha en revolutionerande ny teknologi, med garantier om exceptionellt h�g avkastning p� mycket kort tid. Hur b�r du f�rh�lla dig till erbjudandet?",
                    SubCategoryId = 3,
                },
                new QuestionModel()
                {
                    Id = 4,
                    Question = "Efter en online-shoppingrunda m�rker du oidentifierade transaktioner p� ditt kreditkortsutdrag fr�n f�retag du aldrig handlat fr�n. Vad indikerar detta mest sannolikt?",
                    SubCategoryId = 4,
                },
                new QuestionModel()
                {
                    Id = 5,
                    Question = "Inom f�retaget m�rker man att konfidentiella dokument regelbundet l�cker ut till konkurrenter. Efter en intern granskning uppt�cks det att en anst�lld omedvetet har installerat skadlig programvara genom att klicka p� en l�nk i ett phishing-e-postmeddelande. Vilken �tg�rd b�r prioriteras f�r att f�rhindra framtida incidenter?",
                    SubCategoryId = 5
                },
                new QuestionModel()
                {
                    Id = 6,
                    Question = "Inom f�retaget uppt�ckts det en s�rbarhet i v�r programvara som kunde m�jligg�ra obeh�rig �tkomst till anv�ndardata. F�retaget har inte omedelbart en l�sning. Vilken �r den mest l�mpliga f�rsta �tg�rden?",
                    SubCategoryId = 6
                },
                new QuestionModel()
                {
                    Id = 7,
                    Question = "V�rt f�retag blir m�ltavla f�r en DDoS-attack som �verv�ldigar v�ra servrar och g�r v�ra tj�nster otillg�ngliga f�r kunder. Vilken typ av akt�r �r mest sannolikt ansvarig f�r denna typ av attack?",
                    SubCategoryId = 7
                },
                new QuestionModel()
                {
                    Id = 8,
                    Question = "Med �verg�ngen till distansarbete uppt�cker v�rt f�retag en �kning av s�kerhetsincidenter, inklusive obeh�rig �tkomst till f�retagsdata. Vilken �tg�rd b�r f�retaget vidta f�r att adressera denna nya riskmilj�?",
                    SubCategoryId = 8
                },
                new QuestionModel()
                {
                    Id = 9,
                    Question = "H�lsov�rdsmyndigheten uts�tts f�r ett cyberangrepp som krypterar patientdata och kr�ver l�sen f�r att �terst�lla �tkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta f�r?",
                    SubCategoryId = 9
                },
                new QuestionModel()
                {
                    Id = 10,
                    Question = "Det globala fraktbolaget Maersk blev offer f�r ett omfattande cyberangrepp som avsev�rt st�rde deras verksamhet v�rlden �ver. Vilken typ av malware var prim�rt ansvarig f�r denna incident?",
                    SubCategoryId = 10
                },
                new QuestionModel()
                {
                    Id = 11,
                    Question = "Regeringen uppt�cker att k�nslig politisk kommunikation har l�ckt och misst�nker elektronisk �vervakning. Vilket fenomen beskriver b�st denna situation?",
                    SubCategoryId = 36
                },
                new QuestionModel()
                {
                    Id = 12,
                    Question = "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day s�rbarheter f�r att infiltrera deras n�tverk och stj�la oerh�rt viktig data. Vilken metod f�r cyberspionage anv�nds sannolikt h�r?",
                    SubCategoryId = 37
                },
                new QuestionModel()
                {
                    Id = 13,
                    Question = "Regeringen i Sverige �kar sitt interna s�kerhetsprotokoll f�r att skydda sig mot utl�ndska underr�ttelsetj�nsters infiltration. Vilken lagstiftning ger ramverket f�r detta skydd?",
                    SubCategoryId = 38
                },
                new QuestionModel()
                {
                    Id = 14,
                    Question = "Lunds universitet uppt�cker att forskningsdata om ny teknologi har stulits. Unders�kningar tyder p� en v�lorganiserad grupp med kopplingar till en utl�ndsk stat. Vilken typ av akt�r ligger sannolikt bakom detta?",
                    SubCategoryId = 39
                });

            builder.Entity<AnswerModel>()
                .HasData(
                new AnswerModel()
                {
                    Id = 1,
                    Answer = "Ett legitimt f�rs�k fr�n banken att skydda ditt konto",
                    IsCorrect = false,
                    QuestionId = 1

                },
                new AnswerModel()
                {
                    Id = 2,
                    Answer = "En informationsinsamling f�r en marknadsunders�kning",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new AnswerModel()
                {
                    Id = 3,
                    Answer = "Ett potentiellt telefonbedr�geri",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new AnswerModel()
                {
                    Id = 4,
                    Answer = "En legitim beg�ran om hj�lp fr�n en person i n�d",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new AnswerModel()
                {
                    Id = 5,
                    Answer = "Ett romansbedr�geri",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new AnswerModel()
                {
                    Id = 6,
                    Answer = "En tillf�llig ekonomisk sv�righet",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new AnswerModel()
                {
                    Id = 7,
                    Answer = "Genomf�ra omedelbar investering f�r att inte missa m�jligheten",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new AnswerModel()
                {
                    Id = 8,
                    Answer = "Investeringsbedr�geri",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new AnswerModel()
                {
                    Id = 9,
                    Answer = "Beg�ra mer information f�r att utf�ra en noggrann \"due diligence\"",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new AnswerModel()
                {
                    Id = 10,
                    Answer = "Ett misstag av kreditkortsf�retaget",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new AnswerModel()
                {
                    Id = 11,
                    Answer = "Kreditkortsbedr�geri",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new AnswerModel()
                {
                    Id = 12,
                    Answer = "Obeh�riga k�p av en familjemedlem",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new AnswerModel()
                {
                    Id = 13,
                    Answer = "Utbildning i digital s�kerhet f�r alla anst�llda",
                    IsCorrect = true,
                    QuestionId = 5
                },
                new AnswerModel()
                {
                    Id = 14,
                    Answer = "Installera en starkare brandv�gg",
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
                    Answer = "Informera alla anv�ndare om s�rbarheten och rekommendera tempor�ra skydds�tg�rder",
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
                    Answer = "St�nga ner tj�nsten tillf�lligt",
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
                    Answer = "En konkurrerande f�retagsentitet",
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
                    Answer = "�terg� till kontorsarbete",
                    IsCorrect = false,
                    QuestionId = 8
                },
                new AnswerModel()
                {
                    Id = 23,
                    Answer = "Inf�ra striktare l�senordspolicyer och tv�faktorsautentisering f�r fj�rr�tkomst",
                    IsCorrect = true,
                    QuestionId = 8
                },
                new AnswerModel()
                {
                    Id = 24,
                    Answer = "F�rbjuda anv�ndning av personliga enheter f�r arbete",
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
                    Answer = "Social ingenj�rskonst",
                    IsCorrect = false,
                    QuestionId = 12
                },
                new AnswerModel
                {
                    Id = 35,
                    Answer = "Mass�vervakning",
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
                    Answer = "S�kerhetsskyddslagen",
                    IsCorrect = true,
                    QuestionId = 13
                },
                new AnswerModel
                {
                    Id = 39,
                    Answer = "IT-s�kerhetslagen",
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
