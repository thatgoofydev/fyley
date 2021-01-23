using System;
using DDDCore.Domain.Events;

namespace Fyley.Services.Transactions.Domain.Events
{
    public class TransactionLogged : IAggregateEvent
    {
        public Money Money { get; }
        public AccountDetails Payer { get; }
        public AccountDetails Beneficiary { get; }
        public DateTime Date { get; }

        protected TransactionLogged()
        {
        }
        
        public TransactionLogged(Money money, AccountDetails payer, AccountDetails beneficiary, DateTime date)
        {
            Money = money ?? throw new ArgumentNullException(nameof(money));
            Payer = payer ?? throw new ArgumentNullException(nameof(payer));
            Beneficiary = beneficiary ?? throw new ArgumentNullException(nameof(beneficiary));
            Date = date;
        }
    }
}