using System;

namespace Fyley.BFF.Desktop.Components.Financial.Transactions.ViewModelFactories.Models.TransactionsOverview
{
    public class OverviewTransactionViewModel
    {
        public Guid TransactionId { get; set; }
        public string OtherName { get; set; }
        public string OtherAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string OccuredOn { get; set; }
    }
}