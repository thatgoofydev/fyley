using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Fyley.Components.Accounts.Domain.Events;
using JetBrains.Annotations;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountState : IAggregateState,
        IHandle<AccountDefined>
    {
        public AccountName Name { get; set; }
        public AccountDescription Description { get; set; }
        public AccountNumber AccountNumber { get; set; }
        public Money Balance { get; set; }

        [UsedImplicitly]
        public AccountState()
        { }

        public void Apply(AccountDefined @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            AccountNumber = @event.AccountNumber;
            Balance = @event.StartingBalance;
        }
    }
}