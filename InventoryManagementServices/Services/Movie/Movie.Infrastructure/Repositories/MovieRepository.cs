using Movie.Infrastructure.Repositories.Interfaces;
using Movie.Infrastructure.Entities;

namespace Movie.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MoviesContext _context;

        public MovieRepository(MoviesContext context) => _context = context;

        public IEnumerable<Movies> GetMovies() => _context.Movies;
        public Movies GetMovie(Guid? movieId) => _context.Movies.Where(x => x.Id == movieId).SingleOrDefault();

        public void SaveDetail(Movies movie)
        {
            if (movie.Id != null)
                _context.Movies.Update(movie);
            else
                _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public IEnumerable<MovieRatings> GetMovieRatings() => _context.MovieRatings;

        public IEnumerable<MovieGenres> GetMovieGenres() => _context.MovieGenres;


        public List<MovieSearchResults> SearchMovies(MovieSearch searchRequest)
        {
            var results =
                    (from m in _context.Movies
                     join mg in _context.MovieGenres on m.Id equals mg.MovieId into mgs
                     from mg in mgs.DefaultIfEmpty()
                     join mr in _context.MovieRatings on m.MovieRatingsId equals mr.Id into mrs
                     from mr in mrs.DefaultIfEmpty()
                     where ((string.IsNullOrWhiteSpace(searchRequest.Title) || m.Title.Contains(searchRequest.Title)) &&
                     (string.IsNullOrWhiteSpace(searchRequest.Description) || m.Description.Contains(searchRequest.Description)) &&
                     (searchRequest.ReleaseYear == null || (m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year == searchRequest.ReleaseYear)) &&
                     (searchRequest.MovieRatingsId == null || mr.Id == searchRequest.MovieRatingsId)
                     //searchRequest.MovieGenreIds.Contains(m.MovieGenresId.Value) &&
                     //(m.MovieGenresId.HasValue && searchRequest.MovieGenreIds.Contains(m.MovieGenresId.Value)) &&
                     //(searchRequest.MovieRatingIds.Contains(m.MovieRatingsId))
                     )
                     select new MovieSearchResults
                     {
                         Id = m.Id,
                         Title = m.Title,
                         Description = m.Description,
                         Hours = m.Hours,
                         Minutes = m.Minutes,
                         MovieGenre = mg.GenreDescription,
                         MovieRating = mr.Rating,
                         BoxOffice = m.BoxOffice
                     })
                    .OrderBy(a => a.Title)
                    .Take(1000)
                    .ToList();

            return results;

        }

    }
}
