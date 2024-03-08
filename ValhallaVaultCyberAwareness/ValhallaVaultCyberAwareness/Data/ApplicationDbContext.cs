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
        }

        private void SeedSegmentData(ModelBuilder builder)
        {
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
        }

        private void SeedSubCategoryData(ModelBuilder builder)
        {
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
        }
        private void SeedQuestionData(ModelBuilder builder)
        {
            builder.Entity<QuestionModel>()
            .HasData(
            new QuestionModel()
            {
                Id = 1,
                Question = "Du f�r ett ov�ntat telefonsamtal fr�n n�gon som p�st�r sig vara fr�n din bank. Personen ber dig bekr�fta ditt kontonummer och l�senord f�r att \"s�kerst�lla din kontos s�kerhet\" efter en p�st�dd s�kerhetsincident. Hur b�r du tolka denna situation?",
                Explanation = "Banker och andra finansiella institutioner beg�r aldrig k�nslig information s�som kontonummer eller l�senord via telefon. Detta �r ett klassiskt tecken p� telefonbedr�geri.",
                SubCategoryId = 1,
            },
            new QuestionModel()
            {
                Id = 2,
                Question = "Efter flera m�nader av daglig kommunikation med n�gon du tr�ffade p� en datingsida, b�rjar personen ber�tta om en pl�tslig finansiell kris och ber om din hj�lp genom att �verf�ra pengar. Vad indikerar detta mest sannolikt?",
                Explanation = "Beg�ran om pengar, s�rskilt under omst�ndigheter d�r tv� personer aldrig har tr�ffats fysiskt, �r ett vanligt tecken p� romansbedr�geri.",
                SubCategoryId = 2,
            },
            new QuestionModel()
            {
                Id = 3,
                Question = "Du f�r ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-f�retag som p�st�s ha en revolutionerande ny teknologi, med garantier om exceptionellt h�g avkastning p� mycket kort tid. Hur b�r du f�rh�lla dig till erbjudandet?",
                Explanation = "Erbjudanden som lovar h�g avkastning med liten eller ingen risk, s�rskilt via o�nskade e-postmeddelanden, �r ofta tecken p� investeringsbedr�gerier.",
                SubCategoryId = 3,
            },
            new QuestionModel()
            {
                Id = 4,
                Question = "Efter en online-shoppingrunda m�rker du oidentifierade transaktioner p� ditt kreditkortsutdrag fr�n f�retag du aldrig handlat fr�n. Vad indikerar detta mest sannolikt?",
                Explanation = "Oidentifierade transaktioner p� ditt kreditkortsutdrag �r en stark indikation p� att ditt kortnummer har komprometterats och anv�nts f�r obeh�riga k�p, vilket �r typiskt f�r kreditkortsbedr�geri.",
                SubCategoryId = 4,
            },
            new QuestionModel()
            {
                Id = 5,
                Question = "Inom f�retaget m�rker man att konfidentiella dokument regelbundet l�cker ut till konkurrenter. Efter en intern granskning uppt�cks det att en anst�lld omedvetet har installerat skadlig programvara genom att klicka p� en l�nk i ett phishing-e-postmeddelande. Vilken �tg�rd b�r prioriteras f�r att f�rhindra framtida incidenter?",
                Explanation = "Utbildning i digital s�kerhet �r avg�rande f�r att hj�lpa anst�llda att k�nna igen och undvika s�kerhetshot som phishing, vilket �r en vanlig attackvektor.",
                SubCategoryId = 5
            },
            new QuestionModel()
            {
                Id = 6,
                Question = "Inom f�retaget uppt�ckts det en s�rbarhet i v�r programvara som kunde m�jligg�ra obeh�rig �tkomst till anv�ndardata. F�retaget har inte omedelbart en l�sning. Vilken �r den mest l�mpliga f�rsta �tg�rden?",
                Explanation = "Transparent kommunikation och r�dgivning om tillf�lliga �tg�rder �r avg�rande f�r att skydda anv�ndarna medan en permanent l�sning utvecklas.",
                SubCategoryId = 6
            },
            new QuestionModel()
            {
                Id = 7,
                Question = "V�rt f�retag blir m�ltavla f�r en DDoS-attack som �verv�ldigar v�ra servrar och g�r v�ra tj�nster otillg�ngliga f�r kunder. Vilken typ av akt�r �r mest sannolikt ansvarig f�r denna typ av attack?",
                Explanation = "DDoS-attacker kr�ver ofta betydande resurser och koordinering, vilket �r karakteristiskt f�r organiserade cyberbrottsliga grupper.",
                SubCategoryId = 7
            },
            new QuestionModel()
            {
                Id = 8,
                Question = "Med �verg�ngen till distansarbete uppt�cker v�rt f�retag en �kning av s�kerhetsincidenter, inklusive obeh�rig �tkomst till f�retagsdata. Vilken �tg�rd b�r f�retaget vidta f�r att adressera denna nya riskmilj�?",
                Explanation = "St�rkt autentisering �r kritisk f�r att s�kra fj�rr�tkomst och skydda mot obeh�rig �tkomst i en distribuerad arbetsmilj�.",
                SubCategoryId = 8
            },
            new QuestionModel()
            {
                Id = 9,
                Question = "H�lsov�rdsmyndigheten uts�tts f�r ett cyberangrepp som krypterar patientdata och kr�ver l�sen f�r att �terst�lla �tkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta f�r?",
                Explanation = "Ransomware-angrepp involverar kryptering av offerdata och kr�ver l�sen f�r dekryptering, vilket �r s�rskilt skadligt f�r kritiska sektorer som h�lsov�rd.",
                SubCategoryId = 9
            },
            new QuestionModel()
            {
                Id = 10,
                Question = "Det globala fraktbolaget Maersk blev offer f�r ett omfattande cyberangrepp som avsev�rt st�rde deras verksamhet v�rlden �ver. Vilken typ av malware var prim�rt ansvarig f�r denna incident?",
                Explanation = "Maersk utsattes f�r NotPetya ransomware-angreppet, som ledde till omfattande st�rningar och f�rluster genom att kryptera f�retagets globala system. \r\n\r\nMaersk rapporterade att f�retaget led ekonomiska f�rluster p� grund av NotPetya ransomware-angreppet som uppskattades till cirka 300 miljoner USD. Denna siffra reflekterar de omfattande kostnaderna f�r st�rningar i deras globala verksamheter, �terst�llande av system och data, samt f�rlust av aff�rer under tiden systemen var nere. NotPetya-angreppet anses vara ett av de mest kostsamma cyberangreppen mot ett enskilt f�retag och tj�nar som en kraftfull p�minnelse om de potentiella konsekvenserna av cyberhot. ",
                SubCategoryId = 10
            },
            new QuestionModel()
            {
                Id = 11,
                Question = "Regeringen uppt�cker att k�nslig politisk kommunikation har l�ckt och misst�nker elektronisk �vervakning. Vilket fenomen beskriver b�st denna situation?",
                Explanation = "Cyberspionage avser aktiviteter d�r akt�rer, ofta statliga, engagerar sig i �vervakning och datainsamling genom cybermedel f�r att erh�lla hemlig information utan m�lets medgivande, typiskt f�r politiska, milit�ra eller ekonomiska f�rdelar.",
                SubCategoryId = 36
            },
            new QuestionModel()
            {
                Id = 12,
                Question = "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day s�rbarheter f�r att infiltrera deras n�tverk och stj�la oerh�rt viktig data. Vilken metod f�r cyberspionage anv�nds sannolikt h�r?",
                Explanation = "Riktade cyberattacker som utnyttjar noll-dagars Zero-day s�rbarheter �r en avancerad metod f�r cyberspionage d�r angriparen specifikt riktar in sig p� ett m�l f�r att komma �t k�nslig information eller data genom att utnyttja tidigare ok�nda s�rbarheter i programvara.",
                SubCategoryId = 37
            },
            new QuestionModel()
            {
                Id = 13,
                Question = "Regeringen i Sverige �kar sitt interna s�kerhetsprotokoll f�r att skydda sig mot utl�ndska underr�ttelsetj�nsters infiltration. Vilken lagstiftning ger ramverket f�r detta skydd?",
                Explanation = "S�kerhetsskyddslagen �r en svensk lagstiftning som syftar till att skydda nationellt k�nslig information fr�n spioneri, sabotage, terroristbrott och andra s�kerhetshot. Lagen st�ller krav p� s�kerhetsskydds�tg�rder f�r verksamheter av betydelse f�r Sveriges s�kerhet.",
                SubCategoryId = 38
            },
            new QuestionModel()
            {
                Id = 14,
                Question = "Lunds universitet uppt�cker att forskningsdata om ny teknologi har stulits. Unders�kningar tyder p� en v�lorganiserad grupp med kopplingar till en utl�ndsk stat. Vilken typ av akt�r ligger sannolikt bakom detta?",
                Explanation = "Statssponsrade hackers �r akt�rer som arbetar p� uppdrag av eller med st�d fr�n en regering f�r att genomf�ra cyberspionage, ofta riktat mot utl�ndska intressen, organisationer eller regeringar f�r att f� strategiska f�rdelar.",
                SubCategoryId = 39
            },
            new QuestionModel()
            {
                Id = 15,
                Question = "Du f�r ett e-postmeddelande som ser ut att komma fr�n din bank. Det ber dig klicka p� en l�nk och logga in p� ditt konto f�r att �uppdatera din information�. Vad b�r du g�ra?",
                Explanation = "Klicka aldrig p� l�nkar som uppges komma fr�n banker via e-post.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 16,
                Question = "Du anv�nder din kreditkort p� en betalterminal i en butik. N�gon har placerat en skimming-enhet p� terminalen f�r att stj�la kortinformation. Vad b�r du vara vaksam p�?",
                Explanation = "Skimming �r en metod d�r bedragare placerar en enhet p� en betalterminal f�r att stj�la kortinformation. Genom att inspektera terminalen kan du uppt�cka ovanliga tillbeh�r eller l�sa delar som kan indikera att skimming-enheten �r n�rvarande.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 17,
                Question = "Du f�r ett meddelande om en st�rre transaktion p� ditt kreditkort som du inte har gjort. Vad b�r du g�ra?",
                Explanation = "Om du ser en st�rre transaktion p� ditt kreditkort som du inte har gjort, b�r du agera snabbt. Att kontakta din kreditkortsutgivare direkt hj�lper till att f�rhindra ytterligare skada och identifiera eventuellt bedr�geri.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 18,
                Question = "Du f�r en e-post med en bifogad faktura fr�n ett f�retag du inte k�nner till. Vad b�r du g�ra?",
                Explanation = "Att �ppna bifogade fakturor fr�n ok�nda avs�ndare kan vara farligt. Radera e-postmeddelandet f�r att undvika att uts�tta dig f�r skadlig kod eller bedr�gerif�rs�k.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 19,
                Question = "Du ser n�gon slarvigt l�mna sitt kreditkort p� ett caf�bord. Vad b�r du g�ra?",
                Explanation = "Att ta n�gon annans kreditkort och anv�nda det �r olagligt och oetiskt. L�mna kortet d�r du hittade det eller ge det till personalen f�r att returnera det till �garen.",
                SubCategoryId = 1
            },
            new QuestionModel
            {
                Id = 20,
                Question = "Du har flera automatiska betalningar kopplade till ditt kreditkort. Vad b�r du g�ra om du byter kreditkort?",
                Explanation = "Om du byter kreditkort �r det viktigt att uppdatera betalningsuppgifterna f�r alla automatiska betalningar. Annars kan du missa betalningar och f� p�minnelser eller avgifter.",
                SubCategoryId = 1
            },
            new QuestionModel()
            {
                Id = 21,
                Question = "Vad �r ett romansbedr�geri?",
                Explanation = "Ett romansbedr�geri �r n�r en bedragare inleder en romantisk relation med n�gon i syfte att lura hen p� pengar. Det sker oftast p� internet, till exempel p� sociala medier samt dejtingsidor och dejtingappar.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 22,
                Question = "Vilka typiska drag b�r du vara uppm�rksam p� hos en romansbedragare?",
                Explanation = "Uppm�rksamma typiska drag f�r en romansbedragare, s�som statusyrken, konstlade formuleringar eller slarvigt spr�kbruk.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 23,
                Question = "Vad kr�vs f�r att n�gon ska �talas f�r romansbedr�geri?",
                Explanation = "Romansbedr�geri �r brottsligt n�r n�gon inleder en k�rleksrelation med dig f�r att lura dig p� pengar. �tal kan v�ckas om det finns bevis f�r detta bedr�geri.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 24,
                Question = "Vad b�r du g�ra om du misst�nker att du blivit utsatt f�r romansbedr�geri p� n�tet?",
                Explanation = "Om du blivit lurad av k�rleken du tr�ffat p� n�tet b�r du lista ut vad du ska g�ra n�r du blivit utsatt och vart du ska v�nda dig f�r hj�lp.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 25,
                Question = "Hur skyddar du dig mot romansbedr�geri?",
                Explanation = "Det finns flera saker du kan g�ra f�r att skydda dig mot romansbedr�geri. F�lj tips och r�d om hur du kan undvika att bli lurad.",
                SubCategoryId = 2
            },
            new QuestionModel()
            {
                Id = 26,
                Question = "Vad �r ett investeringsbedr�geri?",
                Explanation = "Ett investeringsbedr�geri inneb�r att n�gon lurar andra att k�pa v�rdepapper som egentligen inte har n�got v�rde eller som �r v�ldigt sv�ra att v�rdera. Det kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och �delstenar.",
                SubCategoryId = 3
            },
            new QuestionModel()
            {
                Id = 27,
                Question = "Vilka varningssignaler b�r du vara uppm�rksam p� vid investeringserbjudanden?",
                Explanation = "Var uppm�rksam p� varningssignaler som h�g avkastning utan risk, bristande dokumentation, och orealistiska l�ften. Bedragare lockar ofta med snabba vinster och undviker att ge tydlig information om investeringen.",
                SubCategoryId = 3
            },
            new QuestionModel()
            {
                Id = 28,
                Question = "Hur kan du skydda dig mot investeringsbedr�geri?",
                Explanation = "F�r att skydda dig mot investeringsbedr�geri b�r du vara skeptisk mot orealistiska l�ften, g�ra grundlig research om investeringen, och undvika att agera impulsivt. Kontrollera �ven att f�retaget har tillst�nd fr�n Finansinspektionen.",
                SubCategoryId = 3
            },
            new QuestionModel()
            {
                Id = 29,
                Question = "Vad b�r du g�ra om du misst�nker att du blivit utsatt f�r investeringsbedr�geri?",
                Explanation = "Om du misst�nker att du blivit utsatt f�r investeringsbedr�geri b�r du omedelbart kontakta Polisen och Finansinspektionen. Samla all relevant information och undvik att g�ra fler transaktioner med bedragaren.",
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
                },
                new AnswerModel()
                {
                    Id = 43,
                    Answer = "Klicka p� l�nken och logga in f�r att uppdatera din information.",
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
                    Answer = "Skicka ditt kontonummer och l�senord som beg�rt.",
                    IsCorrect = false,
                    QuestionId = 15
                },
                new AnswerModel()
                {
                    Id = 46,
                    Answer = "Kontrollera att PIN-koden �r synlig f�r andra.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new AnswerModel()
                {
                    Id = 47,
                    Answer = "Inspektera terminalen f�r ovanliga tillbeh�r eller l�sa delar.",
                    IsCorrect = true,
                    QuestionId = 16
                },
                new AnswerModel()
                {
                    Id = 48,
                    Answer = "Anv�nd kortet utan att oroa dig.",
                    IsCorrect = false,
                    QuestionId = 16
                },
                new AnswerModel()
                {
                    Id = 49,
                    Answer = "Ignorera det och anta att det �r en felaktighet.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new AnswerModel()
                {
                    Id = 50,
                    Answer = "Kontakta din kreditkortsutgivare omedelbart f�r att rapportera misst�nkt bedr�geri.",
                    IsCorrect = true,
                    QuestionId = 17
                },
                new AnswerModel()
                {
                    Id = 51,
                    Answer = "V�nta och se om det l�ser sig av sig sj�lvt.",
                    IsCorrect = false,
                    QuestionId = 17
                },
                new AnswerModel()
                {
                    Id = 52,
                    Answer = "�ppna fakturan och betala den om den verkar legitim.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new AnswerModel()
                {
                    Id = 53,
                    Answer = "Kontakta din kreditkortsutgivare omedelbart f�r att rapportera misst�nkt bedr�geri.",
                    IsCorrect = true,
                    QuestionId = 18
                },
                new AnswerModel()
                {
                    Id = 54,
                    Answer = "V�nta och se om det l�ser sig av sig sj�lvt.",
                    IsCorrect = false,
                    QuestionId = 18
                },
                new AnswerModel()
                {
                    Id = 55,
                    Answer = "Ta kortet och anv�nd det f�r egna ink�p.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new AnswerModel()
                {
                    Id = 56,
                    Answer = "Ge kortet till personalen p� caf�et.",
                    IsCorrect = true,
                    QuestionId = 19
                },
                new AnswerModel()
                {
                    Id = 57,
                    Answer = "Klipp s�nder kortet.",
                    IsCorrect = false,
                    QuestionId = 19
                },
                new AnswerModel()
                {
                    Id = 58,
                    Answer = "Gl�m bort det och l�t betalningarna forts�tta.",
                    IsCorrect = false,
                    QuestionId = 20
                },
                new AnswerModel()
                {
                    Id = 59,
                    Answer = "Uppdatera betalningsuppgifterna hos varje tj�nsteleverant�r.",
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
                    Answer = "Ett romansbedr�geri �r n�r en bedragare inleder en romantisk relation med n�gon i syfte att lura hen p� pengar. Det sker oftast p� internet, till exempel p� sociala medier samt dejtingsidor och dejtingappar.",
                    IsCorrect = true,
                    QuestionId = 21
                },
                new AnswerModel()
                {
                    Id = 62,
                    Answer = "Det �r n�r tv� personer fejkar en romantisk relation f�r att lura andra.",
                    IsCorrect = false,
                    QuestionId = 21
                },
                new AnswerModel()
                {
                    Id = 63,
                    Answer = "Det handlar om att skapa en falsk identitet f�r att vinna n�gon annans f�rtroende.",
                    IsCorrect = false,
                    QuestionId = 21
                },
                new AnswerModel()
                {
                    Id = 64,
                    Answer = "Statusyrken, konstlade formuleringar eller slarvigt spr�kbruk.",
                    IsCorrect = true,
                    QuestionId = 22
                },
                new AnswerModel()
                {
                    Id = 65,
                    Answer = "Gener�s g�va av blommor eller choklad.",
                    IsCorrect = false,
                    QuestionId = 22
                },
                new AnswerModel()
                {
                    Id = 66,
                    Answer = "�verdriven romantik och k�rleksgestikulering.",
                    IsCorrect = false,
                    QuestionId = 22
                },
                new AnswerModel()
                {
                    Id = 67,
                    Answer = "Bevis f�r att personen inlett en k�rleksrelation f�r att lura p� pengar.",
                    IsCorrect = true,
                    QuestionId = 23
                },
                new AnswerModel()
                {
                    Id = 68,
                    Answer = "Att personen har skickat k�rleksbrev eller romantiska meddelanden.",
                    IsCorrect = false,
                    QuestionId = 23
                },
                new AnswerModel()
                {
                    Id = 69,
                    Answer = "Att personen har anv�nt falsk identitet p� sociala medier.",
                    IsCorrect = false,
                    QuestionId = 23
                },
                new AnswerModel()
                {
                    Id = 70,
                    Answer = "Forts�tta kommunicera f�r att samla mer bevis.",
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
                    Answer = "Dela personlig information f�r att testa deras �kthet.",
                    IsCorrect = false,
                    QuestionId = 24
                },
                new AnswerModel()
                {
                    Id = 73,
                    Answer = "�ppet dela dina k�nslor och livshistoria med ok�nda personer.",
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
                    Answer = "Var skeptisk mot snabba k�rleksf�rklaringar och ekonomiska problem.",
                    IsCorrect = true,
                    QuestionId = 25
                },
                new AnswerModel()
                {
                    Id = 76,
                    Answer = "Ett investeringsbedr�geri kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och �delstenar.",
                    IsCorrect = false,
                    QuestionId = 26
                },
                new AnswerModel()
                {
                    Id = 77,
                    Answer = "Det �r n�r n�gon lurar andra att k�pa v�rdepapper som egentligen inte har n�got v�rde eller �r sv�ra att v�rdera.",
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
                    Answer = "H�g avkastning utan risk, bristande dokumentation, orealistiska l�ften.",
                    IsCorrect = true,
                    QuestionId = 27
                },
                new AnswerModel()
                {
                    Id = 80,
                    Answer = "Tydlig information om investeringen, seri�sa f�retag.",
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
                    Answer = "Var skeptisk mot orealistiska l�ften, g�r grundlig research, undvik impulsiva beslut.",
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
                    Answer = "Lita p� alla investeringsm�jligheter utan att kontrollera f�retaget.",
                    IsCorrect = false,
                    QuestionId = 28
                },
                new AnswerModel()
                {
                    Id = 85,
                    Answer = "Dela personlig information f�r att testa deras �kthet.",
                    IsCorrect = false,
                    QuestionId = 29
                },
                new AnswerModel()
                {
                    Id = 86,
                    Answer = "Forts�tta kommunicera f�r att samla mer bevis.",
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
