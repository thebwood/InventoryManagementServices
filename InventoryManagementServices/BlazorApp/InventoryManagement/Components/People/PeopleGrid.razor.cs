using InventoryManagement.Models.People;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace InventoryManagement.Components.People
{
    public partial class PeopleGrid : CommonPeopleFunctions
    {
        #region Parameters

        [Parameter]
        public List<PersonSearchResultsModel> Models { get; set; }

        #endregion

        #region Events

        private void EditPerson(long personId)
        {
            this.NavigationManager.NavigateTo("people/" + personId.ToString());
        }

        #endregion
    }
}
