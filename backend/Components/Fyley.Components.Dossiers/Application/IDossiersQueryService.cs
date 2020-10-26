using System.Threading.Tasks;
using Fyley.Components.Dossiers.Contracts.QueryService.FetchDossier;
using Fyley.Components.Dossiers.Contracts.QueryService.ListDossiers;

namespace Fyley.Components.Dossiers.Application
{
    public interface IDossiersQueryService
    {
        Task<FetchDossierResponse> FetchDossier(FetchDossierRequest request);
        Task<ListDossiersResponse> ListDossiers(ListDossiersRequest request);
    }
}