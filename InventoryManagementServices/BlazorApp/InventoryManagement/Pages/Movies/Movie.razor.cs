using InventoryManagement.Models.Movies;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.Movies
{
    public partial class Movie : CommonMovieFunctions
    {

        #region Private Variables

        private EditContext _editContext;
        private MovieDetailState _movieDetailStateMangement;

        private MoviesModel _movie = new MoviesModel();
        private List<MovieRatingsModel> _movieRatings = new List<MovieRatingsModel>();

        #endregion

        #region Parameters
        [Parameter]
        public long MovieId { get; set; } = 0;

        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _movieDetailStateMangement = new MovieDetailState(Service);
            _movieDetailStateMangement.HandleMovieLoaded += MovieLoaded;
            _movieDetailStateMangement.HandleRatingsLoaded += RatingsLoaded;
            _movieDetailStateMangement.OnMovieSavedSuccessfully += OnSaved;
            if (MovieId > 0)
            {
                await _movieDetailStateMangement.LoadMovie(MovieId);
            }
            else
            {
                _movie = new MoviesModel();
                _editContext = new EditContext(_movie);
            }
            await _movieDetailStateMangement.LoadRatings();
        }

        #endregion

        #region Events

        private async Task SaveMovie()
        {
            if (_editContext.Validate())
            {
                await _movieDetailStateMangement.SaveMovie(_movie);
            }
        }

        private void OnSaved()
        {
            this.NavigationManager.NavigateTo("movies");
        }


        private void CancelSave()
        {
            this.NavigationManager.NavigateTo("movies");
        }

        protected void Dispose()
        {
            _movieDetailStateMangement.HandleMovieLoaded -= MovieLoaded;
            _movieDetailStateMangement.HandleRatingsLoaded -= RatingsLoaded;
            _movieDetailStateMangement.OnMovieSavedSuccessfully -= OnSaved;
        }

        private void RatingsLoaded(List<MovieRatingsModel> ratings)
        {
            _movieRatings = ratings;
            StateHasChanged();
        }

        private void MovieLoaded(MoviesModel movie)
        {
            _movie = movie;
            _editContext = new EditContext(_movie);
            StateHasChanged();
        }

        #endregion
    }
}
