using InventoryManagement.Models.Movies;
using InventoryManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.StateManagement
{
    public class MovieSearchState
    {
        #region Constructor

        public MovieSearchState(MoviesService movieService)
        {
            _movieService = movieService;
        }

        #endregion

        #region Private Variables

        private MoviesService _movieService;

        #endregion


        #region Events

        public async Task SearchMovies(MovieSearchModel searchModel)
        {
            var results = await _movieService.SearchMovies(searchModel);
            OnMoviesSearched?.Invoke(results);
        }

        public async Task LoadRatings()
        {
            var results = await _movieService.GetMovieRatings();
            HandleRatingsLoaded?.Invoke(results);
        }
        #endregion


        #region Actions

        public Action<List<MovieSearchResultsModel>> OnMoviesSearched { get; set; }
        public Action<List<MovieRatingsModel>> HandleRatingsLoaded { get; set; }
        #endregion
    }
}
