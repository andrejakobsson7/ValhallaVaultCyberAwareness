using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests.TestData
{
    public static class CategoryTestData
    {
        public static List<CategoryModel> Categories { get; set; } = new()
        {
            new CategoryModel()
            {
                Id = 1,
                Name = "Att skydda sig mot bedrägerier",
                Segments = SegmentTestData.Segments.Where(s => s.CategoryId == 1).ToList()
            },
        };
    }
}
