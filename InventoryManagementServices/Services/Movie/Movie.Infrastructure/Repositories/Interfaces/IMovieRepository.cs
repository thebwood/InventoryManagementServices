using Movie.Infrastructure.Entities;

namespace Movie.Infrastructure.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetMovies();
        Movies GetMovie(Guid? movieId);
        IEnumerable<MovieRatings> GetMovieRatings();
        void SaveDetail(Movies movie);
        List<MovieSearchResults> SearchMovies(MovieSearch model);
        IEnumerable<MovieGenres> GetMovieGenres();
    }
}