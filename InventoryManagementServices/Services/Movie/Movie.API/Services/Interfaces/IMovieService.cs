using Movie.API.Data;
using Movie.API.Models;
using System.Collections.Generic;

namespace Movie.API.Services.Interfaces
{
    public interface IMovieService
    {
        List<string> SaveDetail(MoviesModel movie);
        IEnumerable<Movies> GetMovies();
        Movies GetMovie(Guid? movieId);
        IEnumerable<MovieRatings> GetMovieRatings();
        IEnumerable<MovieGenres> GetMovieGenres();
        List<MovieSearchResultsModel> SearchMovies(MovieSearchModel model);
    }
}