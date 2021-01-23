
using DDDCore.Domain.Errors;

namespace Fyley.Services.Transactions.Domain.Errors
{
    public class AccountNumberInvalid : DomainError
    {
        public AccountNumberInvalid(string message) : base(message)
        { }
    }
}