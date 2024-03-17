using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class UserAnswersRepository : IUserAnswersRepository
    {
        public ApplicationDbContext _context { get; set; }

        public UserAnswersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a list of useranswers to the database.
        /// The list sent as a parameter might include useranswers that already exists, so a check is made to ensure that no duplicates are added.
        /// 
        /// </summary>
        /// <param name="newUserAnswers"></param>
        /// <returns>True if the operation was successful, otherwise false.</returns>

        public async Task<bool> AddUserAnswersAsync(List<UserAnswers> newUserAnswers)
        {
            List<UserAnswers> uniqueUserAnswers = await ExtractUniqueUserAnswersFromDb(newUserAnswers);
            try
            {
                await _context.UserAnswers.AddRangeAsync(uniqueUserAnswers);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task<List<UserAnswers>> ExtractUniqueUserAnswersFromDb(List<UserAnswers> userAnswersToCheck)
        {
            List<UserAnswers> uniqueUserAnswers = new();
            foreach (var userAnswer in userAnswersToCheck)
            {
                UserAnswers? ua = await GetUserAnswerByIds(userAnswer.AnswerId, userAnswer.UserId);
                if (ua == null)
                {
                    uniqueUserAnswers.Add(userAnswer);
                }
                else
                {
                    continue;
                }
            }
            return uniqueUserAnswers;

        }

        private async Task<UserAnswers?> GetUserAnswerByIds(int answerId, string userId)
        {
            return await _context.UserAnswers.FirstOrDefaultAsync(ua => ua.AnswerId == answerId && ua.UserId == userId);
        }
    }
}
