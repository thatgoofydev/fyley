using System.Collections.Generic;
using System.Threading.Tasks;
using Fyley.Components.Dossiers.Application.QueryModels;
using Fyley.Components.Dossiers.Domain;

namespace Fyley.Components.Dossiers.Application.DataAccess
{
    public interface IDossiersQueries
    {
        Task<FullDossierQueryModel> FetchSingle(DossierId id);

        Task<IEnumerable<FullDossierQueryModel>> FetchAll();
    }
}