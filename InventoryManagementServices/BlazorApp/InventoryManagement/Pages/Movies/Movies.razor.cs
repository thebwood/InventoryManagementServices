using InventoryManagement.Models.Movies;
using InventoryManagement.Services;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.Movies
{
    public partial class Movies : CommonMovieFunctions
    {

        #region Private Variables
        private List<MovieSearchResultsModel> _movies;
        #endregion



        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            await HandleSearch(new MovieSearchModel());
            if (_movies == null)
                _movies = new List<MovieSearchResultsModel>();
        }
        #endregion

        #region Events
        private async Task HandleSearch(MovieSearchModel searchModel)
        {
            _movies = await this.Service.SearchMovies(searchModel);
        }
        private void AddMovie()
        {
            this.NavigationManager.NavigateTo("movies/0");

        }
        #endregion
    }
}
