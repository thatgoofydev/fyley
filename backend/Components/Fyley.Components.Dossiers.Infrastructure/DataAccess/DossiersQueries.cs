using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using Fyley.Components.Dossiers.Application.DataAccess;
using Fyley.Components.Dossiers.Application.QueryModels;
using Fyley.Components.Dossiers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Dossiers.Infrastructure.DataAccess
{
    public class DossiersQueries : IDossiersQueries
    {
        private readonly DbConnection _connection; 

        public DossiersQueries(DossiersContext context)
        {
            _connection = context.Database.GetDbConnection();
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
            
            var result = _connection.QuerySingleAsync<FullDossierQueryModel>(query, new { DossierId = id.Value });
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
            
            var result = _connection.QueryAsync<FullDossierQueryModel>(query);
            return result;
        }
    }
}