﻿using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Domain.Models;

namespace ValhallaVaultCyberAwareness.Repositories.Interfaces
{
    public interface ISegmentRepository
    {
        public ApplicationDbContext _context { get; set; }

        public Task<SegmentModel?> GetSegmentByIdAsync(int segmentId);

        public Task<List<SegmentModel>> GetSegmentsByCategoryIdAsync(int categoryId, string userId);
        public Task<List<SegmentModel>> GetAllSegmentsWithIncludeAsync();

        public Task<SegmentModel> AddSegmentAsync(SegmentModel newSegment);

        public Task<bool> RemoveSegmentAsync(int segmentId);

        public Task<bool> UpdateSegmentAsync(SegmentModel segment);
    }
}
