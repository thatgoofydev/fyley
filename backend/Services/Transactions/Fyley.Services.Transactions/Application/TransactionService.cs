using System;
using System.Threading.Tasks;
using Fyley.Services.Transactions.Application.DataAccess;
using Fyley.Services.Transactions.Domain;

namespace Fyley.Services.Transactions.Application
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionUnitOfWork _unitOfWork;

        public TransactionService(ITransactionUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task LogTransaction(Money money, AccountDetails payer, AccountDetails beneficiary, DateTime date)
        {
            var transaction = new Transaction(money, payer, beneficiary, date);
            
            await _unitOfWork.TransactionRepo.AddAsync(transaction);
            await _unitOfWork.Commit();
        }
    }
}