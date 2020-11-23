using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Fyley.Components.Financial.Domain.Accounts.Events;
using Fyley.Components.Financial.Domain.Shared;
using JetBrains.Annotations;

namespace Fyley.Components.Financial.Domain.Accounts
{
    public class AccountState : IAggregateState,
        IHandle<AccountDefined>
    {
        public AccountName Name { get; [UsedImplicitly] set; }
        public AccountNumber AccountNumber { get; [UsedImplicitly] set; }
        
        [UsedImplicitly]
        public AccountState()
        { }

        public void Apply(AccountDefined @event)
        {
            Name = @event.Name;
            AccountNumber = @event.AccountNumber;
        }
    }
}