using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Adapters;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit;
using Fyley.Core.Asp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi
{
    [ApiController]
    [Route("bff/desktop/accounts")]
    public class AccountsController : BaseController
    {
        private readonly AccountServiceAdapter _serviceAdapter;

        public AccountsController(AccountServiceAdapter serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        [HttpPost("submit")]
        public Task<IActionResult> Submit([FromBody] SubmitAccountRequest request)
        {
            return ExecuteAsync(async () => await _serviceAdapter.DefineAccount(request));
        }
    }
}