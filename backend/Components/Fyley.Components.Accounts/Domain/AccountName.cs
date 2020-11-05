using System;
using System.Text.RegularExpressions;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Accounts.Domain.Errors;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountName : SingleValueObject<string>
    {
        private static readonly Regex NameRegex = new Regex("^[a-zA-Z0-9\\s-_@#()]*$");
        private const int MaxLength = 40;
        
        public AccountName(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            var trimmed = value.Trim();
            if (trimmed.Length > MaxLength) throw new AccountNameToLong(MaxLength);
            if (!NameRegex.IsMatch(trimmed)) throw new InvalidAccountName(trimmed);

            Value = value.Trim(); // override to trim
        }
    }
}