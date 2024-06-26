﻿using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface IAnswersRepository
    {
        public Task<List<AnswerModel>> AddAnswersAsync(List<AnswerModel> answers);
        public Task<AnswerModel> UpdateAnswerAsync(AnswerModel newAnswer);
        public Task<List<AnswerModel>> GetAnswersByQuestionIdAsync(int questionId);
    }
}
