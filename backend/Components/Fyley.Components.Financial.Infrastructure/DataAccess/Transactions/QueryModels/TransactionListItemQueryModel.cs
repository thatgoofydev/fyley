namespace Fyley.Components.Financial.Infrastructure.DataAccess.Transactions.QueryModels
{
    public class TransactionListItemQueryModel
    {
        public int PayorType { get; set; }
        public string PayorValue { get; set; }
        public int PayeeType { get; set; }
        public string PayeeValue { get; set; }
        public decimal Amount { get; set; }
        public string OptionalReference { get; set; }
        public string OccuredOn { get; set; }
        public string LoggedOn { get; set; }
    }
}