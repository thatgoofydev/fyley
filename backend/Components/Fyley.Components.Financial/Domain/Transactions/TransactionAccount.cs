using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Financial.Domain.Shared;
using JetBrains.Annotations;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class TransactionAccount : ValueObject
    {
        public AccountName Name { get; }
        public AccountNumber Number { get; }

        [UsedImplicitly]
        protected TransactionAccount()
        { }
        
        public TransactionAccount(AccountName name, [CanBeNull] AccountNumber accountNumber)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Number = accountNumber;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Number;
        }
    }
}