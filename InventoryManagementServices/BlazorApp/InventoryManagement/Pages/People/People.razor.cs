using InventoryManagement.Models.People;
using InventoryManagement.Shared.BaseClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.People
{
    public partial class People : CommonPeopleFunctions
    {
        #region Private Variables
        private List<PersonSearchResultsModel> _people;
        #endregion



        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            await HandlePeopleSearch(new PersonSearchModel());
            if (_people == null)
                _people = new List<PersonSearchResultsModel>();
        }
        #endregion

        #region Events
        private async Task HandlePeopleSearch(PersonSearchModel searchModel)
        {
            _people = await this.Service.SearchPeople(searchModel);
        }
        private void AddPerson()
        {
            this.NavigationManager.NavigateTo("people/0");

        }
        #endregion
    }
}
