using System;
using System.Collections.Generic;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class AccountReference : ValueObject
    {
        private const string ReferenceTypeIdentifier = "Account";

        public Guid Value { get; }

        public AccountReference(string reference)
        {
            if (string.IsNullOrEmpty(reference)) throw new ArgumentNullException(nameof(reference));
            var parts = reference.Split("/");
            if (parts.Length != 2) throw new ArgumentException(nameof(reference));
            if (!parts[0].Equals(ReferenceTypeIdentifier)) throw new ArgumentException(nameof(reference));
            if (!Guid.TryParse(parts[1], out var value)) throw new ArgumentException(nameof(reference));
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ReferenceTypeIdentifier;
            yield return Value;
        }

        public override string ToString()
        {
            return $"{ReferenceTypeIdentifier}/{Value}";
        }
    }
}