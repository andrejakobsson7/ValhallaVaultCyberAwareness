﻿using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Client.Services
{
    public interface IUserAnswersService
    {
        public HttpClient Client { get; set; }

        public Task<bool> AddUserAnswerAsync(UserAnswers newUserAnswer);
    }
}
