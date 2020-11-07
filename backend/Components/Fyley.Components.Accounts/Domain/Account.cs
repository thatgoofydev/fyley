using System;
using DDDCore.Domain.Aggregates;
using Fyley.Components.Accounts.Domain.Events;

namespace Fyley.Components.Accounts.Domain
{
    public class Account : AggregateBase<AccountId, AccountState>
    {
        
        public AccountName Name => State.Name;
        public AccountDescription Description => State.Description;
        public AccountNumber AccountNumber => State.AccountNumber;
        public Money Balance => State.Balance;

        public Account(AccountName name, AccountDescription description, AccountNumber accountNumber, Money startingBalance)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (accountNumber == null) throw new ArgumentNullException(nameof(accountNumber));
            if (startingBalance == null) throw new ArgumentNullException(nameof(startingBalance));
            Emit(new AccountDefined(name, description, accountNumber, startingBalance));
        }

        public Account(AccountId id, AccountState state, long version) : base(id, state, version)
        {
        }
    }
}