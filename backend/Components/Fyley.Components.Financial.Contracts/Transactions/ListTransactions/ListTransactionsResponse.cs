﻿using System;

namespace Fyley.Components.Financial.Contracts.Transactions.ListTransactions
{
    public class ListTransactionsResponse
    {
        public TransactionDto[] Transactions { get; set; }
        
        public class TransactionDto
        {
            public Guid TransactionId { get; set; }
            public AccountDetails Payor { get; set; }
            public AccountDetails Payee { get; set; }
            public decimal Amount { get; set; }
            public string Reference { get; set; }
            public string OccuredOn { get; set; }

            public class AccountDetails
            {
                public string Name { get; set; }
                public string AccountNumber { get; set; }
            }
        }
    }
}