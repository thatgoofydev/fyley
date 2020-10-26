using System.Threading.Tasks;
using Fyley.Components.Dossiers.Contracts.Service.CreateDossier;

namespace Fyley.Components.Dossiers.Application
{
    public interface IDossiersService
    {
        Task<CreateDossierResponse> CreateDossier(CreateDossierRequest request);
    }
}