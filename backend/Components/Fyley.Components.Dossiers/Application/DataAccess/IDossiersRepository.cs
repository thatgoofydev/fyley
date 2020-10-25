using DDDCore.Application.DataAccess;
using Fyley.Components.Dossiers.Domain;

namespace Fyley.Components.Dossiers.Application.DataAccess
{
    public interface IDossiersRepository : IRepository<Dossier, DossierId, DossierState>
    { }
}