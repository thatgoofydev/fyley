using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit;
using Fyley.Core.Asp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts
{
    [ApiController]
    [Route("bff/desktop/accounts")]
    public class AccountsController : BaseController
    {
        private readonly IAccountViewModelFactory _viewModelFactory;
        private readonly IAccountServiceClient _serviceClient;

        public AccountsController(IAccountViewModelFactory viewModelFactory, IAccountServiceClient serviceClient)
        {
            _viewModelFactory = viewModelFactory;
            _serviceClient = serviceClient;
        }

        [HttpPost("submit-form/{id}")]
        public Task<IActionResult> SubmitForm([FromRoute] string id, [FromBody] SubmitAccountRequest request)
        {
            return ExecuteAsync(async () =>
            {
                if (id == "new")
                {
                    return await _serviceClient.DefineAccount(request);
                }

                // TODO update existing account
                return new SubmitAccountResponse(Guid.Empty);
            });
        }

        [HttpPost("list")]
        public Task<IActionResult> List()
        {
            return ExecuteAsync(async () => await _viewModelFactory.List());
        }
    }
}