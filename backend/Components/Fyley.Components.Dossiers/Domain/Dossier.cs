using DDDCore.Domain.Aggregates;
using Fyley.Components.Dossiers.Domain.Events;
using JetBrains.Annotations;

namespace Fyley.Components.Dossiers.Domain
{
    public sealed class Dossier : AggregateBase<DossierId, DossierState>
    {
        public DossierName Name => State.Name;

        public Dossier(DossierName name)
        {
            Emit(new DossierCreated(name));
        }
        
        [UsedImplicitly]
        public Dossier(DossierId id, DossierState state, long version) : base(id, state, version)
        { }
    }
}