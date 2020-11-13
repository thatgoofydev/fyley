using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Contracts.Transactions.ListTransactions;
using Fyley.Components.Financial.Infrastructure.DataAccess.Transactions.QueryModels;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Financial.Infrastructure.DataAccess.Transactions
{
    public class TransactionQueries : ITransactionQueries
    {
        private readonly DbConnection _connection;
        
        public TransactionQueries(FinancialContext context)
        {
            _connection = context.Database.GetDbConnection();
        }
        
        public async Task<TransactionListDto[]> QueryTransactionListItems()
        {
            const string sqlQuery = @"
                SELECT
                    Payor_Value as PayorValue,
                    Payee_Value as PayeeValue,
                    Amount,
                    OptionalReference,
                    OccuredOn,
                    LoggedOn
                FROM Financial.Transactions;
            ";
            
            var data = await _connection.QueryAsync<TransactionListItemQueryModel>(sqlQuery);
            
            return data.Select(transaction => new TransactionListDto
            {
                Payor = transaction.PayorValue,
                Payee = transaction.PayeeValue,
                Amount = transaction.Amount,
                Reference = transaction.OptionalReference,
                OccuredOn = transaction.OccuredOn,
                LoggedOn = transaction.LoggedOn
            }).ToArray();
        }
    }
}