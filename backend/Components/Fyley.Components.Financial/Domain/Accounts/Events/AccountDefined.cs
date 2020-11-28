﻿using System;
using DDDCore.Domain.Events;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Domain.Accounts.Events
{
    public class AccountDefined : IAggregateEvent
    {
        public AccountName Name { get; }
        public AccountDescription Description { get; }
        public AccountNumber AccountNumber { get; }

        public AccountDefined(AccountName name, AccountDescription description, AccountNumber accountNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            AccountNumber = accountNumber  ?? throw new ArgumentNullException(nameof(accountNumber));
        }
    }
}