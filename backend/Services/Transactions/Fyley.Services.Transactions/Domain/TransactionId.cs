using System;
using DDDCore.Domain.Aggregates;

namespace Fyley.Services.Transactions.Domain
{
    public class TransactionId : Identifier
    {
        private const string AggregateName = "Transaction";
        
        public TransactionId(Guid value) : base(AggregateName, value)
        { }
    }
}