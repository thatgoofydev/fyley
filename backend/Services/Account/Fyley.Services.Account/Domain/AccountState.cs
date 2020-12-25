using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Fyley.Services.Account.Domain.Events;
using JetBrains.Annotations;

namespace Fyley.Services.Account.Domain
{
    public class AccountState : IAggregateState,
        IHandle<AccountDefined>
    {
        public AccountName Name { get; [UsedImplicitly] set; }
        public AccountDescription Description { get; [UsedImplicitly] set; }
        public AccountNumber AccountNumber { get; [UsedImplicitly] set; }
        
        [UsedImplicitly]
        public AccountState()
        { }

        public void Apply(AccountDefined @event)
        {
            Name = @event.Name;
            Description = @event.Description;
            AccountNumber = @event.AccountNumber;
        }
    }
}