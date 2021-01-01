using System.Threading.Tasks;
using Fyley.BFF.Desktop.Core.Controller;
using Fyley.BFF.Desktop.Financial.Accounts.Adapters;
using Fyley.BFF.Desktop.Financial.Accounts.Factories;
using Fyley.BFF.Desktop.Financial.Accounts.Models.DefineAccountForm;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Financial.Accounts.Controllers
{
    [ApiController]
    [Route("/bff/accounts")]
    public class AccountsController : BaseController
    {
        private readonly AccountListViewModelFactory _accountListViewModelFactory;
        private readonly SubmitDefineAccountFormAdapter _submitDefineAccountFormAdapter;

        public AccountsController(
            AccountListViewModelFactory accountListViewModelFactory,
            SubmitDefineAccountFormAdapter submitDefineAccountFormAdapter)
        {
            _accountListViewModelFactory = accountListViewModelFactory;
            _submitDefineAccountFormAdapter = submitDefineAccountFormAdapter;
        }
        
        [HttpPost("submit_define_account_form")]
        public Task<IActionResult> SubmitDefineAccountForm([FromBody] AccountFormViewModel request)
        {
            return ExecuteAsync(async () => await _submitDefineAccountFormAdapter.Handle(request));
        }
        
        [HttpPost("list_accounts")]
        public Task<IActionResult> ListAccounts()
        {
            return ExecuteAsync(async () => await _accountListViewModelFactory.Create());
        }
        
    }
}