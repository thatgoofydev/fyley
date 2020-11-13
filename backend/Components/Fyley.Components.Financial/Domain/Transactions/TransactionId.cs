using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class TransactionId : Identifier
    {
        private const string AggregateName = "Account";
        
        public TransactionId(Guid value) : base(AggregateName, value)
        { }
    }
}