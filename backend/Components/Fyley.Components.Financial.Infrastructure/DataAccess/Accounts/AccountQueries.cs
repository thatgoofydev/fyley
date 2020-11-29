using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Fyley.Components.Financial.Application.Accounts.DataAccess;
using Fyley.Components.Financial.Application.Accounts.DataAccess.QueryModels;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Financial.Infrastructure.DataAccess.Accounts
{
    public class AccountQueries : IAccountQueries
    {
        private readonly DbConnection _connection;
        
        public AccountQueries(FinancialContext context)
        {
            _connection = context.Database.GetDbConnection();
        }

        public async Task<ListAccountQueryModel[]> QueryAccountListItems()
        {
            const string sqlQuery = @"
                SELECT
                    a.AccountId,
                    a.Name,
                    a.Description,
                    a.AccountNumber_Type as AccountNumberType,
                    a.AccountNumber_Value as AccountNumberValue
                FROM Financial.Accounts a
            ";
            var data = await _connection.QueryAsync <ListAccountQueryModel>(sqlQuery);
            return data.ToArray();
        }
    }
}