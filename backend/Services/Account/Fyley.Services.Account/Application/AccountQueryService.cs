using System.Threading.Tasks;
using Fyley.Services.Account.Application.DataAccess;
using Fyley.Services.Account.Application.DataAccess.QueryModels;

namespace Fyley.Services.Account.Application
{
    public class AccountQueryService : IAccountQueryService
    {
        private readonly IQueries _queries;

        public AccountQueryService(IQueries queries)
        {
            _queries = queries;
        }
        
        public async Task<ListAccountQueryModel[]> ListAccounts()
        {
            return await _queries.ListAccounts();
        }
    }
}