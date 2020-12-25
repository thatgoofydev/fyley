using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Fyley.Services.Account.Application.DataAccess;
using Fyley.Services.Account.Application.DataAccess.QueryModels;

namespace Fyley.Services.Account.Infrastructure
{
    public class Queries : IQueries
    {
        private readonly AccountDbContext _context;

        public Queries(AccountDbContext context)
        {
            _context = context;
        }
        
        public async Task<ListAccountQueryModel[]> ListAccounts()
        {
            await using var connection = _context.GetConnection();
            
            const string sqlQuery = @"
                SELECT
                    a.AccountId,
                    a.Name,
                    a.Description,
                    a.AccountNumber_Type as AccountNumberType,
                    a.AccountNumber_Value as AccountNumberValue
                FROM Accounts.Accounts a
            ";

            var data = await connection.QueryAsync<ListAccountQueryModel>(sqlQuery);
            return data.ToArray();
        }
    }
}