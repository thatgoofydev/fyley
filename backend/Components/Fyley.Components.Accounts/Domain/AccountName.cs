using System;
using System.Text.RegularExpressions;
using DDDCore.Domain.ValueObjects;
using Fyley.Components.Accounts.Domain.Errors;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountName : SingleValueObject<string>
    {
        private static readonly Regex NameRegex = new Regex("^[a-zA-Z0-9\\s-_@#()]*$");
        private const int MaxLength = 60;
        
        public AccountName(string value) : base(value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length > MaxLength) throw new AccountNameToLong(MaxLength);
            if (!NameRegex.IsMatch(value)) throw new InvalidAccountName(value);
        }
    }
}