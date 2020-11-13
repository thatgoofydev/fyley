using DDDCore.Domain.Errors;

namespace Fyley.Components.Financial.Domain.Shared.Errors
{
    public class InvalidAccountNumber : DomainError
    {
        public InvalidAccountNumber(string message) : base(message)
        { }
    }
}