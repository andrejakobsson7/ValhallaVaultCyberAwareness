using ValhallaVaultCyberAwareness.Data;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SegmentRepository
    {
        ApplicationDbContext _context;

        public SegmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
