﻿using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaTests.TestData
{
    public static class SubCategoryTestData
    {
        public static List<SubCategoryModel> SubCategories { get; set; } = new()
        {
            new SubCategoryModel()
            {
                Id = 1,
                Name = "Subkategori 1",
                Description = "Beskrivning av subkategori 1",
                SegmentId = 1,
                Questions = QuestionTestData.Questions.Where(q => q.SubCategoryId == 1).ToList(),
            },
            new SubCategoryModel()
            {
                Id = 2,
                Name = "Subkategori 2",
                Description = "Beskrivning av subkategori 2",
                SegmentId = 1,
                Questions = QuestionTestData.Questions.Where(q => q.SubCategoryId == 2).ToList()
            }
        };
    }
}
