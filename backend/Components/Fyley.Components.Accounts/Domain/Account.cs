using DDDCore.Domain.Aggregates;

namespace Fyley.Components.Accounts.Domain
{
    public class Account : AggregateBase<AccountId, AccountState>
    {
        
        public AccountName Name => State.Name;
        public AccountDescription Description => State.Description;
        public AccountNumber AccountNumber => State.AccountNumber;

        protected Account()
        {
        }

        protected Account(AccountId id, AccountState state, long version) : base(id, state, version)
        {
        }
    }
}