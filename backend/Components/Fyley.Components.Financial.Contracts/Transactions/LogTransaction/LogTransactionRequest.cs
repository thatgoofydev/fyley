using System;

namespace Fyley.Components.Financial.Contracts.Transactions.LogTransaction
{
    public class LogTransactionRequest
    {
        public string Payor { get; set; }
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string OccuredOn { get; set; }
    }
}