using ValhallaVaultCyberAwareness.Repositories;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;

namespace ValhallaVaultCyberAwareness.Managers
{
    public class AdminManager
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly ISubCategoryRepository _subcategoryRepository;
        public readonly ISegmentRepository _segmentRepository;
        public readonly IQuestionRepository _questionRepository;
        public readonly IAnswersRepository _answersRepository;

        public AdminManager
            (ICategoryRepository categoryRepository,
            ISubCategoryRepository subcategoryRepository,
            ISegmentRepository segmentRepository,
            IQuestionRepository questionRepository,
            IAnswersRepository answersRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _segmentRepository = segmentRepository;
            _questionRepository = questionRepository;
            _answersRepository = answersRepository;
        }

    }
}
