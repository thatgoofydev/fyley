using System;

namespace Fyley.Services.Account.Application.DataAccess.QueryModels
{
    public class ListAccountQueryModel
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AccountNumberType { get; set; }
        public string AccountNumberValue { get; set; }
    }
}