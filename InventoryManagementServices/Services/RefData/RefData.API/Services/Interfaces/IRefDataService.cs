
using RefData.API.Data;

namespace RefData.API.Services.Interfaces
{
    public interface IRefDataService
    {
        IEnumerable<Genre> GetGenres();
    }
}
