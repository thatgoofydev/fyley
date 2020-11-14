using System;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Financial.Domain.Shared.Errors;

namespace Fyley.Components.Financial.Domain.Shared
{
    public class AccountName : SingleValueObject<string>
    {
        private const int MaxLength = 40;
        
        public AccountName(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            if (value.Length > MaxLength) throw new AccountNameToLong(MaxLength);
            
        }
    }
}