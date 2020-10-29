using System;
using System.Linq;
using System.Threading.Tasks;
using DDDCore.Application.Errors;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Contracts.QueryService.FetchDossier;
using Fyley.Components.Dossiers.Contracts.QueryService.ListDossiers;
using Fyley.Components.Dossiers.Domain;

namespace Fyley.Components.Dossiers.Application
{
    public class DossiersQueryService : IDossiersQueryService
    {
        private readonly IDossiersQueries _queries;

        public DossiersQueryService(IDossiersQueries queries)
        {
            _queries = queries;
        }
        
        public async Task<FetchDossierResponse> FetchDossier(FetchDossierRequest request)
        {
            var dossierId = new DossierId(Guid.Parse(request.Id));
            var dossier = await _queries.FetchSingle(dossierId);
            if (dossier == null)
            {
                throw new AggregateNotFound(dossierId);
            }
            
            return new FetchDossierResponse
            {
                Dossier = new Contracts.QueryService.FetchDossier.DossierDto
                {
                    Id = dossier.DossierId.ToString(),
                    Name = dossier.Name
                }
            };
        }

        public async Task<ListDossiersResponse> ListDossiers(ListDossiersRequest request)
        {
            var dossiers = await _queries.FetchAll();
            
            return new ListDossiersResponse
            {
                Dossiers = dossiers
                    .Select(dossier => new Contracts.QueryService.ListDossiers.DossierDto
                    {
                        Id = dossier.DossierId.ToString(),
                        Name = dossier.Name
                    })
                    .ToArray()
            };
        }
        
    }
}