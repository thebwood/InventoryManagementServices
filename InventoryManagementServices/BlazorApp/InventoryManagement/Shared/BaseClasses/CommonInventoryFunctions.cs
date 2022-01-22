using InventoryManagement.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Shared.BaseClasses
{
    public class CommonInventoryFunctions : CommonComponent
    {
        #region Dependency Injection
        [Inject]
        public InventoryService Service { get; set; }
        #endregion

    }
}
