using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Fyley.Components.Financial.Application.Transactions.DataAccess;
using Fyley.Components.Financial.Application.Transactions.DataAccess.QueryModels;
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
        
        public async Task<ListTransactionsQueryModel[]> QueryTransactionListItems()
        {
            const string sqlQuery = @"
                SELECT
                    t.TransactionId,
                    t.Payor_AccountReference as PayorAccountReference,
                    t.Payor_TransactionAccount_Name as PayorTransactionAccountName,
                    t.Payor_TransactionAccount_Number_Type as PayorTransactionAccountNumberType,
                    t.Payor_TransactionAccount_Number_Value as PayorTransactionAccountNumberValue,
                    t.Payee_AccountReference as PayeeAccountReference,
                    t.Payee_TransactionAccount_Name as PayeeTransactionAccountName,
                    t.Payee_TransactionAccount_Number_Type as PayeeTransactionAccountNumberType,
                    t.Payee_TransactionAccount_Number_Value as PayeeTransactionAccountNumberValue,
                    t.Amount,
                    t.OptionalReference,
                    t.OccuredOn
                FROM Financial.Transactions t
            ";

            var data = await _connection.QueryAsync<ListTransactionsQueryModel>(sqlQuery);
            return data.ToArray();
        }
    }
}