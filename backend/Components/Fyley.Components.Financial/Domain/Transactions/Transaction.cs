using System;
using DDDCore.Domain.Aggregates;
using Fyley.Components.Financial.Domain.Transactions.Events;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class Transaction : AggregateBase<TransactionId, TransactionState>
    {
        public AccountReferenceOrTransactionAccount Payor => State.Payor;
        public AccountReferenceOrTransactionAccount Payee => State.Payee;
        public Money Amount => State.Amount;
        public OptionalReference OptionalReference => State.OptionalReference;
        public TransactionDateTime OccuredOn => State.OccuredOn;
        public TransactionDateTime LoggedOn => State.LoggedOn;
        // TODO Tags

        public Transaction(
            AccountReferenceOrTransactionAccount payor,
            AccountReferenceOrTransactionAccount payee,
            Money amount,
            OptionalReference optionalReference,
            TransactionDateTime occuredOn)
        {
            if (payor == null) throw new ArgumentNullException(nameof(payor));
            if (payee == null) throw new ArgumentNullException(nameof(payee));
            if (amount == null) throw new ArgumentNullException(nameof(amount));
            if (optionalReference == null) throw new ArgumentNullException(nameof(optionalReference));
            if (occuredOn == null) throw new ArgumentNullException(nameof(occuredOn));
            Emit(new TransactionLogged(payor, payee, amount, optionalReference, occuredOn));
        }
        
        public Transaction(TransactionId id, TransactionState state, long version) : base(id, state, version)
        {
        }
    }
}