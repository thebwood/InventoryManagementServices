using InventoryManagement.Models.Movies;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace InventoryManagement.Components.Movies
{
    public partial class MoviesGrid : CommonMovieFunctions
    {
        #region Parameters

        [Parameter]
        public List<MovieSearchResultsModel> Models { get; set; }
        #endregion


        public void EditMovie(Guid? movieId)
        {
            this.NavigationManager.NavigateTo("movies/" + movieId.ToString());

        }
    }
}
