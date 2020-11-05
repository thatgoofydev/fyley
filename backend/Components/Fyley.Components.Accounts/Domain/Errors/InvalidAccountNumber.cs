using DDDCore.Domain.Errors;

namespace Fyley.Components.Accounts.Domain.Errors
{
    public class InvalidAccountNumber : DomainError
    {
        public InvalidAccountNumber(string message) : base(message)
        { }
    }
}