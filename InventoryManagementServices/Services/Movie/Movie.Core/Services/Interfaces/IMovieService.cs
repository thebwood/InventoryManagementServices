using Movie.Core.Models;

namespace Movie.Core.Services.Interfaces
{
    public interface IMovieService
    {
        List<string> SaveDetail(MoviesModel movie);
        IEnumerable<MoviesModel> GetMovies();
        MoviesModel GetMovie(Guid? movieId);
        IEnumerable<MovieRatingsModel> GetMovieRatings();
        IEnumerable<MovieGenresModel> GetMovieGenres();
        List<MovieSearchResultsModel> SearchMovies(MovieSearchModel model);
    }
}