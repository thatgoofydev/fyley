using System;
using DDDCore.Domain.Events;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Domain.Transactions.Events
{
    public class TransactionLogged : IAggregateEvent
    {
        public AccountNumber Payor { get; }
        public AccountNumber Payee { get; }
        public Money Amount { get; }
        public OptionalReference OptionalReference { get; }
        public TransactionDateTime OccuredOn { get; }
        public TransactionDateTime LoggedOn { get; }

        public TransactionLogged(
            AccountNumber payor,
            AccountNumber payee,
            Money amount,
            OptionalReference optionalReference,
            TransactionDateTime occuredOn)
        {
            Payor = payor ?? throw new ArgumentNullException(nameof(payor));
            Payee = payee ?? throw new ArgumentNullException(nameof(payee));
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            OptionalReference = optionalReference ?? throw new ArgumentNullException(nameof(optionalReference));
            OccuredOn = occuredOn ?? throw new ArgumentNullException(nameof(occuredOn));
            LoggedOn = TransactionDateTime.Now;
        }
    }
}