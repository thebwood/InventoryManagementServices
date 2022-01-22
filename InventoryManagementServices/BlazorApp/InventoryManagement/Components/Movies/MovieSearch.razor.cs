
using InventoryManagement.Models.Movies;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.Components.Movies
{
    public partial class MovieSearch : CommonMovieFunctions
    {
        #region Private Variables

        private MovieSearchModel _searchModel = new MovieSearchModel();
        private List<MovieGenresModel> _movieGenres = new List<MovieGenresModel>();
        private List<MovieRatingsModel> _movieRatings = new List<MovieRatingsModel>();

        private Task<List<MovieGenresModel>> _movieGenresTask;
        private Task<List<MovieRatingsModel>> _movieRatingsTask;
        #endregion

        #region Parameters

        [Parameter]
        public EventCallback<MovieSearchModel> OnSearch { get; set; }

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _movieRatingsTask = this.Service.GetMovieRatings();
            _movieGenresTask =  this.Service.GetMovieGenres();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await Task.WhenAll(_movieRatingsTask, _movieGenresTask);
                _movieRatings = _movieRatingsTask.Result;
                _movieGenres = _movieGenresTask.Result;
                this.StateHasChanged();

            }
        }
        #endregion

        #region Events

        private void SearchMovie()
        {
            if(OnSearch.HasDelegate)
            {
                OnSearch.InvokeAsync(_searchModel);
            }
        }
        private void ResetSearch()
        {
            _searchModel = new MovieSearchModel();
        }
        #endregion
    }
}
