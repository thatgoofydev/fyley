using System;

namespace Fyley.Components.Financial.Application.Transactions.DataAccess.QueryModels
{
    public class ListTransactionsQueryModel
    {
        public Guid TransactionId { get; set; }
        public string PayorAccountReference { get; set; }
        public string PayorTransactionAccountName { get; set; }
        public string PayorTransactionAccountNumberValue { get; set; }
        public string PayeeAccountReference { get; set; }
        public string PayeeTransactionAccountName { get; set; }
        public string PayeeTransactionAccountNumberValue { get; set; }
        public decimal Amount { get; set; }
        public string OptionalReference { get; set; }
        public string OccuredOn { get; set; }
    }
}