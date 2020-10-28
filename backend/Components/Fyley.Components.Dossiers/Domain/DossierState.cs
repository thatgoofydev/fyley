using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Fyley.Components.Dossiers.Domain.Events;
using JetBrains.Annotations;

namespace Fyley.Components.Dossiers.Domain
{
    public class DossierState : IAggregateState,
        IHandle<DossierCreated>
    {
        public DossierName Name { get; set; }

        [UsedImplicitly]
        public DossierState()
        { }
        
        public void Apply(DossierCreated @event)
        {
            Name = @event.Name;
        }
    }
}