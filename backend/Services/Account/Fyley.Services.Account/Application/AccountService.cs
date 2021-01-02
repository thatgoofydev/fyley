using System.Threading.Tasks;
using DDDCore.Application.DataAccess;
using DDDCore.Application.Validation;
using Fyley.Services.Account.Application.DataAccess;
using Fyley.Services.Account.Domain;

namespace Fyley.Services.Account.Application
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
        }
        
        public async Task<AccountId> DefineAccount(AccountName name, AccountDescription description, AccountNumber accountNumber)
        {
            Guard.ArgumentNotNull(nameof(name), name);
            Guard.ArgumentNotNull(nameof(description), description);
            Guard.ArgumentNotNull(nameof(accountNumber), accountNumber);
            
            var account = new Domain.Account(name, description, accountNumber);

            await _accountRepository.AddAsync(account);
            await _unitOfWork.Commit();
            
            return account.Id;
        }

        public async Task ArchiveAccount(AccountId accountId)
        {
            Guard.ArgumentNotNull(nameof(accountId), accountId);

            var account = await _accountRepository.FetchAsync(accountId);

            account.Archive();
            
            await _accountRepository.Update(account);
            await _unitOfWork.Commit();
        }
    }
}