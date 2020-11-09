using System.Threading.Tasks;
using Fyley.Components.Accounts.Application;
using Fyley.Components.Accounts.Contracts.Service.DefineAccount;
using Fyley.Core.Asp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Components.Accounts
{
    [ApiController]
    [Route("/bff/desktop/accounts")]
    public class AccountsController : BaseController
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost("submit-form")]
        public Task<IActionResult> SubmitForm([FromBody] DefineAccountRequest request)
        {
            return ExecuteAsync(async () =>
            {
                var result = await _accountsService.DefineAccount(request);
                return result;
            });
        }
    }
}