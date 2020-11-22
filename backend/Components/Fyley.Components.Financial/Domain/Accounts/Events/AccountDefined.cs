using System;
using DDDCore.Domain.Events;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Domain.Accounts.Events
{
    public class AccountDefined : IAggregateEvent
    {
        public AccountName Name { get; }
        public AccountNumber AccountNumber { get; }

        public AccountDefined(AccountName name, AccountNumber accountNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AccountNumber = accountNumber  ?? throw new ArgumentNullException(nameof(accountNumber));
        }
    }
}