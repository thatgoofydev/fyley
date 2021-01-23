using System;
using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Fyley.Services.Transactions.Domain.Events;

namespace Fyley.Services.Transactions.Domain
{
    public class TransactionState : IAggregateState,
        IHandle<TransactionLogged>
    {
        public Money Money { get; set; }
        public AccountDetails Payer { get; set; }
        public AccountDetails Beneficiary { get; set; }
        public DateTime Date { get; set; }
        public DateTime LoggedDate { get; set; }
        
        public void Apply(TransactionLogged @event)
        {
            Money = @event.Money;
            Payer = @event.Payer;
            Beneficiary = @event.Beneficiary;
            Date = @event.Date;
            LoggedDate = DateTime.UtcNow;
        }
    }
}