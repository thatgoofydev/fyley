namespace Fyley.Components.Financial.Contracts.Transactions.ListTransactions
{
    public class TransactionListDto
    {
        public string Payor { get; set; }
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string OccuredOn { get; set; }
        public string LoggedOn { get; set; }
    }
}