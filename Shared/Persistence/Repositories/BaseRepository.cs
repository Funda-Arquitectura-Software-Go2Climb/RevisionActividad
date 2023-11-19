using ActivityReview.Shared.Persistence.Contexts;

namespace ActivityReview.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;
    
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}