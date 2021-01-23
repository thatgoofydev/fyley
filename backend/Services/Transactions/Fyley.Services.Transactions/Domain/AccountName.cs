using DDDCore.Domain.ValueObjects;
using Fyley.Services.Transactions.Domain.Errors;

namespace Fyley.Services.Transactions.Domain
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