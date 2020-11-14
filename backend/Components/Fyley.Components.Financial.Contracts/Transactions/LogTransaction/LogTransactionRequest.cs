namespace Fyley.Components.Financial.Contracts.Transactions.LogTransaction
{
    public class LogTransactionRequest
    {
        public AccountReferenceOrTransactionAccount Payor { get; set; }
        public AccountReferenceOrTransactionAccount Payee { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string OccuredOn { get; set; }
        
        public class AccountReferenceOrTransactionAccount
        {
            public string AccountReference { get; set; }
            public TransactionAccount TransactionAccount { get; set; }
        }
        
        public class TransactionAccount
        {
            public string Name { get; set; }
            public string AccountNumber { get; set; }
        }
    }
}