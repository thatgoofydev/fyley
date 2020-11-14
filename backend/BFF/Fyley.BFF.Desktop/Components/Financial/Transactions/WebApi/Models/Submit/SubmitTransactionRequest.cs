namespace Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi.Models.Submit
{
    public class SubmitTransactionRequest
    {
        public AccountReferenceOrTransactionAccount Payor { get; set; }
        public AccountReferenceOrTransactionAccount Payee { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string OccuredOn { get; set; }
        
        public class AccountReferenceOrTransactionAccount
        {
            public string AccountReference { get; set; }
            public TransactionAccount Account { get; set; }
        }
        
        public class TransactionAccount
        {
            public string Name { get; set; }
            public string AccountNumber { get; set; }
        }
    }
}