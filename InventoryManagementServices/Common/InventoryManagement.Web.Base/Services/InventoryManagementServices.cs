using Microsoft.Extensions.Logging;

namespace InventoryManagement.Web.Base.Services
{
    public class InventoryManagementServices<T> where T : class
    {
        private ILogger<T> _logger { get; }

        protected InventoryManagementServices(ILogger<T> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        protected ILogger<T> Logger
        {
            get { return _logger; }
        }

    }
}
