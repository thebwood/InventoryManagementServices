using RefData.API.Data;
using RefData.API.Repositories.Interfaces;
using RefData.API.Services.Interfaces;

namespace RefData.API.Services
{
    public class RefDataService : IRefDataService
    {
        private IRefDataRepository _refDataRepository;

        public RefDataService(IRefDataRepository repository) => _refDataRepository = repository;

        public IEnumerable<Genre> GetGenres() => _refDataRepository.GetGenres();
    }
}
