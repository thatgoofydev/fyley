using DDDCore.Domain.Aggregates;
using DDDCore.Domain.Events;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Transactions.Events;
using JetBrains.Annotations;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class TransactionState : IAggregateState,
        IHandle<TransactionLogged>
    {
        public AccountNumber Payor { get; set; }
        public AccountNumber Payee { get; set; }
        public Money Amount { get; set; }
        public OptionalReference OptionalReference { get; set; }
        public TransactionDateTime OccuredOn { get; set; }
        public TransactionDateTime LoggedOn { get; set; }

        [UsedImplicitly]
        public TransactionState()
        { }

        public void Apply(TransactionLogged @event)
        {
            Payor = @event.Payor;
            Payee = @event.Payee;
            Amount = @event.Amount;
            OptionalReference = @event.OptionalReference;
            OccuredOn = @event.OccuredOn;
            LoggedOn = @event.LoggedOn;
        }
    }
}