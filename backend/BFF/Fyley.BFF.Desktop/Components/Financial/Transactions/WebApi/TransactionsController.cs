using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Transactions.Adapters;
using Fyley.BFF.Desktop.Components.Financial.Transactions.ViewModelFactories;
using Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi.Models.Submit;
using Fyley.Core.Asp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi
{
    [ApiController]
    [Route("/bff/desktop/transactions")]
    public class TransactionsController : BaseController
    {
        private readonly TransactionServiceAdapter _serviceAdapter;
        private readonly TransactionViewModelFactory _viewModelFactory;

        public TransactionsController(TransactionServiceAdapter serviceAdapter, TransactionViewModelFactory viewModelFactory)
        {
            _serviceAdapter = serviceAdapter;
            _viewModelFactory = viewModelFactory;
        }

        [HttpPost("submit")]
        public Task<IActionResult> Submit(SubmitTransactionRequest request)
        {
            return ExecuteAsync(async () => await _serviceAdapter.LogTransaction(request));
        }

        [HttpPost("overview")]
        public Task<IActionResult> List()
        {
            return ExecuteAsync(async () => await _viewModelFactory.GetOverviewViewModel());
        }
        
    }
}