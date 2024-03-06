using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Managers
{
    public class AdminManager
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly ISubcategoryRepository _subcategoryRepository;
        public readonly ISegmentRepository _segmentRepository;
        public readonly IQuestionRepository _questionRepository;

        public AdminManager
            (ICategoryRepository categoryRepository,
            ISubcategoryRepository subcategoryRepository,
            ISegmentRepository segmentRepository,
            IQuestionRepository questionRepository)
        {
            categoryRepository = _categoryRepository;
            subcategoryRepository = _subcategoryRepository;
            segmentRepository = _segmentRepository;
            questionRepository = _questionRepository;
        }

    }
}
