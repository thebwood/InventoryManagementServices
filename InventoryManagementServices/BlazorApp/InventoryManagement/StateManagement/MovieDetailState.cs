using InventoryManagement.Models.Movies;
using InventoryManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.StateManagement
{
    public class MovieDetailState
    {
        #region Constructor

        public MovieDetailState(MoviesService movieService)
        {
            _movieService = movieService;
        }

        #endregion

        #region Private Variables

        private MoviesService _movieService;

        #endregion

        #region Events

        public async Task SaveMovie(MoviesModel moviesModel)
        {
            var results = await _movieService.SaveMovie(moviesModel);
            if (results.Count() > 0)
                OnError?.Invoke(results);
            else
                OnMovieSavedSuccessfully?.Invoke();
        }

        public async Task LoadRatings()
        {
            var results = await _movieService.GetMovieRatings();
            HandleRatingsLoaded?.Invoke(results);
        }
        public async Task LoadMovie(long movieId)
        {
            var result = await _movieService.GetMovie(movieId);
            HandleMovieLoaded?.Invoke(result);
        }

        #endregion
        #region Actions

        public Action OnMovieSavedSuccessfully { get; set; }
        public Action<List<MovieRatingsModel>> HandleRatingsLoaded { get; set; }
        public Action<MoviesModel> HandleMovieLoaded { get; set; }
        public Action<List<string>> OnError { get; private set; }

        #endregion
    }
}
