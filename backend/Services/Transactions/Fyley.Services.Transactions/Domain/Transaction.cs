using System;
using DDDCore.Domain.Aggregates;
using Fyley.Services.Transactions.Domain.Events;

namespace Fyley.Services.Transactions.Domain
{
    public class Transaction : AggregateBase<TransactionId, TransactionState>
    {
        public Money Money => State.Money;
        public AccountDetails Payer => State.Payer;
        public AccountDetails Beneficiary => State.Beneficiary;
        public DateTime Date => State.Date;
        public DateTime LoggedDate => State.LoggedDate;
        
        public Transaction(
            Money money,
            AccountDetails payer,
            AccountDetails beneficiary,
            DateTime date)
        {
            if (money == null) throw new ArgumentNullException(nameof(money));
            if (payer == null) throw new ArgumentNullException(nameof(payer));
            if (beneficiary == null) throw new ArgumentNullException(nameof(beneficiary));
            Emit(new TransactionLogged(money, payer, beneficiary, date));
        }

        public Transaction(TransactionId id, TransactionState state, long version) : base(id, state, version)
        {
        }
    }
}