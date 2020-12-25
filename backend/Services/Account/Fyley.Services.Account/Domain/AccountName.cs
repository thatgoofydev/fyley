using DDDCore.Domain.ValueObjects;
using Fyley.Services.Account.Domain.Errors;

namespace Fyley.Services.Account.Domain
{
    public class AccountName : SingleValueObject<string>
    {
        private const int MaxLength = 50;
        
        public AccountName(string value) : base(value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new AccountNameRequired();
            if (value.Length > MaxLength) throw new AccountNameToLong(MaxLength);
        }
    }
}