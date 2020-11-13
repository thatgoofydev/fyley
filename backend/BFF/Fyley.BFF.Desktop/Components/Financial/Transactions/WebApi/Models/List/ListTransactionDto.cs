namespace Fyley.BFF.Desktop.Components.Financial.Transactions.WebApi.Models.List
{
    public class ListTransactionDto
    {
        public string Payor { get; set; }
        public string Payee { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string OccuredOn { get; set; }
        public string LoggedOn { get; set; }
    }
}