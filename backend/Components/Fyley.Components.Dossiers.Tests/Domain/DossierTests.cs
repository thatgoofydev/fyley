using DDDCore.Domain.Events;
using Fyley.Components.Dossiers.Domain;
using Fyley.Components.Dossiers.Domain.Events;
using NUnit.Framework;

namespace Fyley.Components.Dossiers.Tests.Domain
{
    [TestFixture]
    public class DossierTests
    {
        public class ConstructorShould : DossierTests
        {
            [Test]
            public void SetNameAndHaveDossierCreatedEvent()
            {
                // Arrange
                var dossierName = new DossierName("dossier1");
                
                // Act
                var result = new Dossier(dossierName);
                
                // Assert
                Assert.That(result.Name, Is.EqualTo(dossierName));
                
                var events = result.FlushUncommitedEvents();
                Assert.That(events, Has.Length.EqualTo(1));
                Assert.That(events,
                    Has.Exactly(1).Matches<DomainEvent>(@event =>
                        (@event.AggregateEvent as DossierCreated)?.Name == dossierName));
            }
        }        
    }
}