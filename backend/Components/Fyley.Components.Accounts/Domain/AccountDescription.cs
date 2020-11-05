using System;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Accounts.Domain.Errors;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountDescription : SingleValueObject<string>
    {
        private const int MaxLength = 120;
        
        public AccountDescription(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            if (value.Length > MaxLength) throw new AccountDescriptionToLong(MaxLength);
        }
    }
}