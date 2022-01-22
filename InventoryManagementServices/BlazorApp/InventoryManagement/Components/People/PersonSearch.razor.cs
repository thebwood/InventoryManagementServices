using InventoryManagement.Models.People;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Components.People
{
    public partial class PersonSearch : CommonPeopleFunctions
    {
        #region Private Variables

        private PersonSearchModel _searchModel = new PersonSearchModel();
        private List<StatesModel> _states = new List<StatesModel>();

        private Task<List<StatesModel>> _statesTask;
        #endregion

        #region Parameters

        [Parameter]
        public EventCallback<PersonSearchModel> OnSearchPeople { get; set; }

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _statesTask = this.Service.GetStates();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.WhenAll( _statesTask);
                _states = _statesTask.Result;
                this.StateHasChanged();

            }
        }
        #endregion

        #region Events

        private void SearchPerson()
        {
            if (OnSearchPeople.HasDelegate)
            {
                OnSearchPeople.InvokeAsync(_searchModel);
            }
        }
        private void ResetSearch()
        {
            _searchModel = new PersonSearchModel();
        }
        #endregion
    }
}
