using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Services.Transactions.Domain
{
    public class AccountDetails : ValueObject
    {
        public AccountReference Reference { get; }
        public AccountName Name { get; }
        public AccountNumber AccountNumber { get; }

        private AccountDetails(AccountReference reference, AccountName name, AccountNumber accountNumber)
        {
            Reference = reference;
            Name = name;
            AccountNumber = accountNumber;
        }

        public bool HasReference()
        {
            return Reference != null;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Reference;
            yield return Name;
            yield return AccountNumber;
        }

        public static AccountDetails For(AccountReference reference)
        {
            return new AccountDetails(reference, null, null);
        }
        
        public static AccountDetails For(AccountName name, AccountNumber accountNumber)
        {
            return new AccountDetails(null, name, accountNumber);
        }
    }
}