using AutoMapper;
using InventoryManagement.Web.Base.Services;
using Microsoft.Extensions.Logging;
using Movie.Core.Models;
using Movie.Core.Services.Interfaces;
using Movie.Infrastructure.Entities;
using Movie.Infrastructure.Repositories.Interfaces;

namespace Movie.Core.Services
{
    public class MovieService : InventoryManagementServices<MovieService>, IMovieService
    {
        private IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(ILogger<MovieService> logger,  IMovieRepository repo, IMapper mapper) : base(logger)
        {
            _movieRepository = repo;
            _mapper = mapper;
        }

        public IEnumerable<MoviesModel> GetMovies()
        {
            var moviesModelList = new List<MoviesModel>();
            var movies = _movieRepository.GetMovies();

            _mapper.Map(movies, moviesModelList);
            return moviesModelList;
        }

        public List<MovieSearchResultsModel> SearchMovies(MovieSearchModel model)
        {
            var movieSearch = new MovieSearch();
            _mapper.Map(model, movieSearch);

            var movieSearchResults = _movieRepository.SearchMovies(movieSearch);
            var movieSearchResultsModel = new List<MovieSearchResultsModel>();

            _mapper.Map(movieSearchResults, movieSearchResultsModel);

            return movieSearchResultsModel;
        }

        public MoviesModel GetMovie(Guid? movieId)
        {
            var movie =_movieRepository.GetMovie(movieId);
            var movieModel = new MoviesModel();
            _mapper.Map(movie, movieModel);

            return movieModel;
        }

        public IEnumerable<MovieRatingsModel> GetMovieRatings()
        {
            var movieRatings = _movieRepository.GetMovieRatings();
            var movieRatingsModel = new List<MovieRatingsModel>();

            _mapper.Map(movieRatings, movieRatingsModel);
            return movieRatingsModel;
        }
        public IEnumerable<MovieGenresModel> GetMovieGenres()
        {
            var movieGenres = _movieRepository.GetMovieGenres();
            var movieGenresModel = new List<MovieGenresModel>();
            
            _mapper.Map(movieGenres, movieGenresModel);

            return movieGenresModel;
        }

        public List<string> SaveDetail(MoviesModel movie)
        {
            var errors = ValidateMovie(movie);
            if (errors.Count() == 0)
            {
                var existingMovie = new Movies();
                if (movie.Id != null)
                    existingMovie = _movieRepository.GetMovie(movie.Id);

                _mapper.Map<MoviesModel, Movies>(movie, existingMovie);
                _movieRepository.SaveDetail(existingMovie);
            }

            return errors;
        }

        private List<string> ValidateMovie(MoviesModel movie)
        {
            var errors = new List<string>();

            if (String.IsNullOrWhiteSpace(movie.Title))
            {
                errors.Add("Title is required");
            }
            if (String.IsNullOrWhiteSpace(movie.Description))
            {
                errors.Add("Description is required");
            }


            return errors;
        }
    }
}
