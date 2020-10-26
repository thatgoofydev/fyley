using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Application.QueryModels;
using Fyley.Components.Dossiers.Domain;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    public class DossiersQueries : IDossiersQueries
    {
        private readonly IDossiersUnitOfWork _unitOfWork;

        public DossiersQueries(IDossiersUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public Task<FullDossierQueryModel> FetchSingle(DossierId id)
        {
            const string query = @"
                SELECT 
                    d.DossierId,
                    d.Name
                FROM Dossiers.Dossiers d
                WHERE d.DossierId = @DossierId
            ";
            
            var result = _unitOfWork.GetConnection().QuerySingleAsync<FullDossierQueryModel>(query, new { DossierId = id.Value });
            return result;
        }

        public Task<IEnumerable<FullDossierQueryModel>> FetchAll()
        {
            const string query = @"
                SELECT 
                    d.DossierId,
                    d.Name
                FROM Dossiers.Dossiers d
            ";
            
            var result = _unitOfWork.GetConnection().QueryAsync<FullDossierQueryModel>(query);
            return result;
        }
    }
}