using ValhallaVaultCyberAwareness.Client.Services;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Managers
{
    public class AdminManager
    {
        private readonly ICategoryService _categoryService;
        private readonly ISegmentRepository _segmentService;

        public AdminManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void AddCategory()
        {

        }

        public void UpdateCategory()
        {

        }

        public void DeleteCategory()
        {

        }
    }
}
