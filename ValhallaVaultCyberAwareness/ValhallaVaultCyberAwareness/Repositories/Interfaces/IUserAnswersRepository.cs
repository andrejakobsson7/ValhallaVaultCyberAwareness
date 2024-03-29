﻿using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface IUserAnswersRepository
    {
        public ApplicationDbContext _context { get; set; }

        public Task<bool> AddUserAnswersAsync(List<UserAnswers> newUserAnswers);
    }
}
