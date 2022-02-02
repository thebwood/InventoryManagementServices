using RefData.API.Data;

namespace RefData.API.Repositories.Interfaces
{
    public interface IRefDataRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}
