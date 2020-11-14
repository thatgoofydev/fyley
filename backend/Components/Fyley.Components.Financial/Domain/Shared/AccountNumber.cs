using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Financial.Domain.Shared.Errors;

namespace Fyley.Components.Financial.Domain.Shared
{
    public class AccountNumber : ValueObject
    {
        public AccountNumberType Type { get; }
        public string Value { get; }
        
        public AccountNumber(AccountNumberType type, string value)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            if (value == null) throw new ArgumentNullException(nameof(value));
            Value = Type.Format(value);

            var validationResult = Type.IsValid(value);
            if (!validationResult.IsValid) throw new AccountNumberInvalid(validationResult.Error);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
        }
    }
}