using DDDCore.Domain.Events;

namespace Fyley.Components.Dossiers.Domain.Events
{
    public class DossierCreated : IAggregateEvent
    {
        public DossierName Name { get; }

        public DossierCreated(DossierName name)
        {
            Name = name;
        }
    }
}