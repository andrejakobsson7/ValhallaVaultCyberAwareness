using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests.TestData
{
    public static class SegmentTestData
    {
        public static List<SegmentModel> Segments { get; set; } = new()
        {
            new SegmentModel()
            {
                Id = 1,
                Name = "Segment 1",
                Description = "Beskrivning av segment 1",
                CategoryId = 1,
                Category = CategoryTestData.Categories.First(c => c.Id == 1),
                SubCategories = SubCategoryTestData.SubCategories.Where(s => s.SegmentId == 1).ToList()
            },
        };
    }
}
