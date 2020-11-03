using DDDCore.Domain.Aggregates;
using JetBrains.Annotations;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountState : IAggregateState
    {
        public AccountName Name { get; set; }
        public AccountDescription Description { get; set; }
        public AccountNumber AccountNumber { get; set; }

        [UsedImplicitly]
        public AccountState()
        { }
    }
}