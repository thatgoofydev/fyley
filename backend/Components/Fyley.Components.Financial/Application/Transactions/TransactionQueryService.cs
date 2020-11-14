using System.Linq;
using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Contracts.Transactions.ListTransactions;

namespace Fyley.Components.Financial.Application.Transactions
{
    public class TransactionQueryService : ITransactionQueryService
    {
        private readonly ITransactionQueries _transactionQueries;

        public TransactionQueryService(ITransactionQueries transactionQueries)
        {
            _transactionQueries = transactionQueries;
        }
        
        public async Task<ListTransactionsResponse> List()
        {
            var queryItems = await _transactionQueries.QueryTransactionListItems();
            
            var transactions = queryItems.Select(qi =>
            {
                var payorAccountDetails = new ListTransactionsResponse.TransactionDto.AccountDetails
                { // TODO get account details if PayorAccountReference
                    Name = qi.PayorTransactionAccountName,
                    AccountNumber = qi.PayorTransactionAccountNumberValue
                };
                var payeeAccountDetails = new ListTransactionsResponse.TransactionDto.AccountDetails
                { // TODO get account details if PayeeAccountReference
                    Name = qi.PayeeTransactionAccountName,
                    AccountNumber = qi.PayeeTransactionAccountNumberValue
                };

                return new ListTransactionsResponse.TransactionDto
                {
                    TransactionId = qi.TransactionId,
                    Payor = payorAccountDetails,
                    Payee = payeeAccountDetails,
                    Amount = qi.Amount,
                    Reference = qi.OptionalReference,
                    OccuredOn = qi.OccuredOn
                };
            }).ToArray();

            return new ListTransactionsResponse
            {
                Transactions = transactions
            };
        }
    }
}