using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;
using JetBrains.Annotations;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class AccountReferenceOrTransactionAccount : ValueObject
    {
        public AccountReference AccountReference { get; }
        public TransactionAccount TransactionAccount { get; }

        [UsedImplicitly]
        protected AccountReferenceOrTransactionAccount()
        { }
        
        public AccountReferenceOrTransactionAccount([CanBeNull] AccountReference accountReference, [CanBeNull] TransactionAccount transactionAccount)
        {
            AccountReference = accountReference;
            TransactionAccount = transactionAccount;
            
            if (accountReference == null && transactionAccount == null
                || accountReference != null && transactionAccount != null)
            {
                throw new Exception("");
            }
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AccountReference;
            yield return TransactionAccount;
        }
    }
}