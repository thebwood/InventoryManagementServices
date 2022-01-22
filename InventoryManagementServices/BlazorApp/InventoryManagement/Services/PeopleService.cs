using InventoryManagement.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class PeopleService : BaseService
    {
        #region Movies

        public async Task<List<PersonSearchResultsModel>> SearchPeople(PersonSearchModel searchModel)
        {
            var baseURL = "https://localhost:44308/";
            return await this.PostAPIResult<List<PersonSearchResultsModel>, PersonSearchModel>(baseURL, "api/people/search", searchModel);
        }

        public async Task<PeopleModel> GetPerson(long personId)
        {
            var baseURL = "https://localhost:44308/";
            return await this.GetAPIResult<PeopleModel>(baseURL, "api/people/" + personId.ToString());
        }


        public async Task<List<string>> SavePerson(PeopleModel person)
        {
            var baseURL = "https://localhost:44308/";
            return await this.PostAPIResult<List<string>, PeopleModel>(baseURL, "api/people/", person);
        }

        #endregion

        #region Movie Ratings

        public async Task<List<StatesModel>> GetStates()
        {
            var baseURL = "https://localhost:44308/";
            return await this.GetAPIResult<List<StatesModel>>(baseURL, "api/people/states");
        }


        #endregion
    }
}
