using DDDCore.Domain.Errors;

namespace Fyley.Components.Accounts.Domain.Errors
{
    public class InvalidAccountName : DomainError
    {
        public InvalidAccountName(string invalidAccountName) 
            : base($"Invalid account invalidAccountName: '{invalidAccountName}'! Account names can only include alphanumeric characters, spaces and '-' '_' '@' '#' '(' ')' .")
        {
        }
    }
}