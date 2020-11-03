using DDDCore.Domain.Errors;

namespace Fyley.Components.Accounts.Domain.Errors
{
    public class AccountDescriptionToLong : DomainError
    {
        public AccountDescriptionToLong(int maxLength) : base($"Account description is to long! Maximum {maxLength} characters are allowed.")
        { }
    }
}