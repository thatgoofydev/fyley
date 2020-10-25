using System.Threading.Tasks;
using DDDCore.Infrastructure.DataAccess;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Domain;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    public class DossiersRepository : RepositoryBase<Dossier, DossierId, DossierState>, IDossiersRepository
    {
        public DossiersRepository(DossiersContext context) : base(context, context.Dossiers, "DossierId")
        { }

        protected override async Task<DossierState> FetchState(DossierId id)
        {
            return await Repository.FindAsync(id.Value);
        }
    }
}