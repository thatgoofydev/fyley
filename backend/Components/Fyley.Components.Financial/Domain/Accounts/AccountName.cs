using System;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Financial.Domain.Accounts.Errors;

namespace Fyley.Components.Financial.Domain.Accounts
{
    public class AccountName : SingleValueObject<string>
    {
        private const int MaxLength = 40;
        
        public AccountName(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            var trimmed = value.Trim();
            if (trimmed.Length > MaxLength) throw new AccountNameToLong(MaxLength);
            Value = value.Trim();
        }
    }
}