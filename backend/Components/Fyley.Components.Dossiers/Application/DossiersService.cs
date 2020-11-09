using System.Threading.Tasks;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Contracts.Service.CreateDossier;
using Fyley.Components.Dossiers.Domain;

namespace Fyley.Components.Dossiers.Application
{
    public class DossiersService : IDossiersService
    {
        private readonly IDossiersUnitOfWork _unitOfWork;
        private readonly IDossiersRepository _repository;

        public DossiersService(IDossiersUnitOfWork unitOfWork, IDossiersRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<CreateDossierResponse> CreateDossier(CreateDossierRequest request)
        {
            var dossierName = new DossierName(request.Name);
            var dossier = new Dossier(dossierName);
            await _repository.AddAsync(dossier);
            await _unitOfWork.Commit();
            
            return new CreateDossierResponse
            {
                Id = dossier.Id.Value
            };
        }
    }
}