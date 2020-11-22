using DDDCore.Domain.Errors;

namespace Fyley.Components.Financial.Domain.Shared.Errors
{
    public class AccountNameToLong : DomainError
    {
        public AccountNameToLong(in int maxLength) : base($"Account name is to long. Maximum length of {maxLength}")
        {
        }
    }
}