using System.Threading.Tasks;
using Fyley.Components.Financial.Application.Accounts.DataAccess.QueryModels;

namespace Fyley.Components.Financial.Application.Accounts.DataAccess
{
    public interface IAccountQueries
    {
        Task<ListAccountQueryModel[]> QueryAccountListItems();
    }
}