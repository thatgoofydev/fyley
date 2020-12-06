using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.List;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts
{
    public interface IAccountViewModelFactory
    {
        Task<ListResponse> List();
    }
}