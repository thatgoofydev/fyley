using System.Threading.Tasks;
using Fyley.Services.Account.Application.DataAccess.QueryModels;

namespace Fyley.Services.Account.Application.DataAccess
{
    public interface IQueries
    {
        Task<ListAccountQueryModel[]> ListAccounts();
    }
}