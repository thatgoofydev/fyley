using System.Threading.Tasks;
using DDDCore.Application.Validation;
using Fyley.Components.Financial.Application.Accounts.DataAccess;
using Fyley.Components.Financial.Domain.Accounts;
using Fyley.Components.Financial.Domain.Shared;

namespace Fyley.Components.Financial.Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IFinancialUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository repository, IFinancialUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountId> DefineAccount(AccountName name, AccountDescription description, AccountNumber accountNumber)
        {
            Guard.ArgumentNotNull(nameof(name), name);
            Guard.ArgumentNotNull(nameof(description), description);
            Guard.ArgumentNotNull(nameof(accountNumber), accountNumber);
            
            var account = new Account(name, description, accountNumber);

            await _repository.AddAsync(account);
            await _unitOfWork.Commit();

            return account.Id;
        }
        
    }
}