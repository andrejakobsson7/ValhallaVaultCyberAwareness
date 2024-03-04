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
        }

    }
}
