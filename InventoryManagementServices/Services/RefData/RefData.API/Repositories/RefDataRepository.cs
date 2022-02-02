using RefData.API.Data;
using RefData.API.Repositories.Interfaces;

namespace RefData.API.Repositories
{
    public class RefDataRepository : IRefDataRepository
    {
        private RefDataContext _context;
        public RefDataRepository(RefDataContext context) => _context = context;

        public IEnumerable<Genre> GetGenres() => _context.Genres.OrderBy(x => x.Description);
    }
}
