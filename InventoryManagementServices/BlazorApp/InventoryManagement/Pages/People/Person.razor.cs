using InventoryManagement.Models.People;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.People
{
    public partial class Person : CommonPeopleFunctions
    {
        #region Private Variables
        private EditContext _editContext;

        private PeopleModel _person = new PeopleModel();
        private List<StatesModel> _states = new List<StatesModel>();

        private Task<PeopleModel> _personTask;
        private Task<List<StatesModel>> _statesTask;

        #endregion

        #region Private Variables

        [Parameter]
        public long PersonId { get; set; }

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _editContext = new EditContext(_person);
            if (PersonId > 0)
            {
                _personTask = this.Service.GetPerson(PersonId);
            }
            _statesTask = this.Service.GetStates();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

                if (PersonId > 0)
                {
                    await Task.WhenAll(_personTask, _statesTask);
                    _person = _personTask.Result;
                }
                else
                {
                    await Task.WhenAll(_statesTask);
                }

                _states = _statesTask.Result;
                this.StateHasChanged();
            }
        }

        #endregion

        #region Events

        private async Task SavePerson()
        {
            if(_editContext.Validate())
            {
                var messages = await this.Service.SavePerson(_person);
                if (messages.Count == 0)
                {
                    this.NavigationManager.NavigateTo("people");
                }

            }
        }

        private void CancelSave()
        {
            this.NavigationManager.NavigateTo("people");
        }
        #endregion

    }
}
