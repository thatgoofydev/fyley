using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Accounts.Domain.Errors;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountNumber : ValueObject
    {
        public AccountNumberType Type { get; }
        public string Value { get; }
        
        public AccountNumber(AccountNumberType type, string value)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Value = value ?? throw new ArgumentNullException(nameof(value));
            
            if (!Type.IsValid(value)) throw new InvalidAccountNumber();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
        }
    }
}