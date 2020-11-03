using DDDCore.Domain.Errors;

namespace Fyley.Components.Accounts.Domain.Errors
{
    public class AccountNameToLong : DomainError
    {
        public AccountNameToLong(int maxLength) : base($"Account name is to long! Maximum {maxLength} characters are allowed.")
        { }
    }
}