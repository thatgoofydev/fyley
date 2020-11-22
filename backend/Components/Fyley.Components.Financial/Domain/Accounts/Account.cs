using System;
using DDDCore.Domain.Aggregates;
using Fyley.Components.Financial.Domain.Accounts.Events;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Domain.Accounts
{
    public class Account : AggregateBase<AccountId, AccountState>
    {
        public AccountName Name => State.Name;
        public AccountNumber AccountNumber => State.AccountNumber;
        
        public Account(AccountName name, AccountNumber accountNumber)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (accountNumber == null) throw new ArgumentNullException(nameof(accountNumber));
            Emit(new AccountDefined(name, accountNumber));
        }
        
        public Account(AccountId id, AccountState state, long version) : base(id, state, version)
        {
        }
    }
}