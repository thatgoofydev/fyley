using DDDCore.Domain.Errors;

namespace Fyley.Components.Financial.Domain.Shared.Errors
{
    public class AccountNumberInvalid : DomainError
    {
        public AccountNumberInvalid(string message) : base(message)
        { }
    }
}