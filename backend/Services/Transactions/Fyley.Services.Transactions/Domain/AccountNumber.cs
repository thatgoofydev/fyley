using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;
using Fyley.Services.Transactions.Domain.Errors;

namespace Fyley.Services.Transactions.Domain
{
    public class AccountNumber : ValueObject
    {
        public AccountNumberType Type { get; }
        public string Value { get; }
        
        public AccountNumber(AccountNumberType type, string value)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            if (value == null) throw new AccountNumberValueRequired();

            var validationResult = Type.IsValid(value);
            if (!validationResult.IsValid) throw new AccountNumberInvalid(validationResult.Error);

            Value = Type.Format(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
        }
    }
}