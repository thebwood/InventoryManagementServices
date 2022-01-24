using Movie.API.Data;
using Movie.API.Models;

namespace Movie.API.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetMovies();
        Movies GetMovie(Guid? movieId);
        IEnumerable<MovieRatings> GetMovieRatings();
        void SaveDetail(Movies movie);
        List<MovieSearchResultsModel> SearchMovies(MovieSearchModel model);
        IEnumerable<MovieGenres> GetMovieGenres();
    }
}