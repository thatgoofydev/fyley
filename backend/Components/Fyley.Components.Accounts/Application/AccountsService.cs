using System.Threading.Tasks;
using Fyley.Components.Accounts.Application.DataAccess;
using Fyley.Components.Accounts.Contracts.Service.DefineAccount;
using Fyley.Components.Accounts.Domain;

namespace Fyley.Components.Accounts.Application
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountRepository _repository;
        private readonly IAccountsUnitOfWork _unitOfWork;

        public AccountsService(IAccountRepository repository, IAccountsUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<DefineAccountResponse> DefineAccount(DefineAccountRequest request)
        {
            var name = new AccountName(request.Name);
            var description = new AccountDescription(request.Description);
            var accountNumberType = AccountNumberType.FromValue(request.AccountNumberType);
            var accountNumber = new AccountNumber(accountNumberType, request.AccountNumber);
            var startingBalance = new Money(request.StartingBalance);
            
            var account = new Account(name, description, accountNumber, startingBalance);

            await _repository.AddAsync(account);
            await _unitOfWork.Commit();

            return new DefineAccountResponse
            {
                Id = account.Id.Value
            };
        }
    }
}