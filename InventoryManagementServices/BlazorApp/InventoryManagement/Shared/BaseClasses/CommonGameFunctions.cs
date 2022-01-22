using InventoryManagement.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.BaseClasses
{
    public class CommonGameFunctions : CommonComponent
    {
        #region Dependency Injection
        [Inject]
        public GamesService Service { get; set; }
        #endregion

        #region Events

        public string GetRatingWithAge(string rating, int age)
        {
            return rating + " (" + age.ToString() + "+)";

        }

        #endregion

    }
}
