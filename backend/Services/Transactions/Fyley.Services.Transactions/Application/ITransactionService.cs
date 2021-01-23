using System;
using System.Threading.Tasks;
using Fyley.Services.Transactions.Domain;

namespace Fyley.Services.Transactions.Application
{
    public interface ITransactionService
    {
        Task LogTransaction(Money money, AccountDetails payer, AccountDetails beneficiary, DateTime date);
    }
}