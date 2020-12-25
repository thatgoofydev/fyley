using System.Threading.Tasks;
using Fyley.Services.Account.Application.DataAccess.QueryModels;

namespace Fyley.Services.Account.Application
{
    public interface IAccountQueryService
    {
        Task<ListAccountQueryModel[]> ListAccounts();
    }
}