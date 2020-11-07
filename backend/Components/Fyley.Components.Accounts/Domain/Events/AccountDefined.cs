using DDDCore.Domain.Events;

namespace Fyley.Components.Accounts.Domain.Events
{
    public class AccountDefined : IAggregateEvent
    {
        public AccountName Name { get; }
        public AccountDescription Description { get; }
        public AccountNumber AccountNumber { get; }
        public Money StartingBalance { get; }

        public AccountDefined(AccountName name, AccountDescription description, AccountNumber accountNumber,
            Money startingBalance)
        {
            Name = name;
            Description = description;
            AccountNumber = accountNumber;
            StartingBalance = startingBalance;
        }
    }
}