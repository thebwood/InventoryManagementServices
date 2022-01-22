using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Domain.Models;

namespace InventoryManagement.Services
{
    public class TestService : BaseService
    {
        public async Task<List<StateModel>> GetStates()
        {
            var baseURL = "https://localhost:44330/";
            return await this.GetAPIResult<List<StateModel>>(baseURL, "api/test/states");
        }
        public async Task<List<StatusModel>> GetStatuses()
        {
            var baseURL = "https://localhost:44330/";
            return await this.GetAPIResult<List<StatusModel>>(baseURL, "api/test/statuses");
        }
        public async Task<List<RoleModel>> GetRoles()
        {
            var baseURL = "https://localhost:44330/";
            return await this.GetAPIResult<List<RoleModel>>(baseURL, "api/test/roles");
        }
        public async Task<List<PersonModel>> GetPeople()
        {
            var baseURL = "https://localhost:44330/";
            return await this.GetAPIResult<List<PersonModel>>(baseURL, "api/test/people");
        }

    }
}
