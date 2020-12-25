using System;
using DDDCore.Domain.Aggregates;
using Fyley.Services.Account.Domain.Events;

namespace Fyley.Services.Account.Domain
{
    public class Account : AggregateBase<AccountId, AccountState>
    {
        public AccountName Name => State.Name;
        public AccountDescription Description => State.Description;
        public AccountNumber AccountNumber => State.AccountNumber;
        
        public Account(AccountName name, AccountDescription description, AccountNumber accountNumber)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (accountNumber == null) throw new ArgumentNullException(nameof(accountNumber));
            Emit(new AccountDefined(name, description, accountNumber));
        }

        public Account(AccountId id, AccountState state, long version) : base(id, state, version)
        { }
    }
}