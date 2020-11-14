using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi.Models.List;
using Fyley.Components.Financial.Application.Transactions;
using Fyley.Components.Financial.Contracts.Transactions.ListTransactions;

namespace Fyley.BFF.Desktop.Components.Financial.Transactions.Adapters
{
    public class TransactionQueryServiceAdapter
    {
        private readonly ITransactionQueryService _service;

        public TransactionQueryServiceAdapter(ITransactionQueryService service)
        {
            _service = service;
        }

        public async Task<ListTransactionsViewResponse> ListTransactions()
        {
            var response = await _service.List();
            
            return new ListTransactionsViewResponse
            {
                Transactions = Map(response.Transactions)
            };
        }

        private static ListTransactionsViewResponse.TransactionDto[] Map(ListTransactionsResponse.TransactionDto[] dtos)
        {
            if (dtos.Length == 0) return new ListTransactionsViewResponse.TransactionDto[0];

            return dtos.Select(dto => new ListTransactionsViewResponse.TransactionDto
            {
                TransactionId = dto.TransactionId,
                Payor = Map(dto.Payor),
                Payee = Map(dto.Payee),
                Amount = dto.Amount,
                Reference = dto.Reference,
                OccuredOn = dto.OccuredOn
            }).ToArray();
        }

        private static ListTransactionsViewResponse.TransactionDto.AccountDetails Map(
            ListTransactionsResponse.TransactionDto.AccountDetails details)
        {
            if (details == null) return null;
            return new ListTransactionsViewResponse.TransactionDto.AccountDetails
            {
                Name = details.Name,
                AccountNumber = details.AccountNumber
            };
        }
    }
}