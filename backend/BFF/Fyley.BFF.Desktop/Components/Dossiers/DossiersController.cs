using System.Threading.Tasks;
using Fyley.Components.Dossiers.Application;
using Fyley.Components.Dossiers.Contracts.QueryService.FetchDossier;
using Fyley.Components.Dossiers.Contracts.QueryService.ListDossiers;
using Fyley.Components.Dossiers.Contracts.Service.CreateDossier;
using Fyley.Core.Asp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Components.Dossiers
{
    [ApiController]
    [Route("/bff/dossiers")]
    public class DossiersController : BaseController
    {
        private readonly IDossiersService _dossiersService;
        private readonly IDossiersQueryService _dossiersQueryService;

        public DossiersController(IDossiersService dossiersService, IDossiersQueryService dossiersQueryService)
        {
            _dossiersService = dossiersService;
            _dossiersQueryService = dossiersQueryService;
        }

        [HttpPost("createDossier")]
        public Task<IActionResult> CreateDossier([FromBody] CreateDossierRequest request)
        {
            return ExecuteAsync(async () =>
            {
                var result = await _dossiersService.CreateDossier(request);
                return result;
            });
        }

        [HttpPost("fetchDossier")]
        public Task<IActionResult> FetchDossier([FromBody] FetchDossierRequest request)
        {
            return ExecuteAsync(async () =>
            {
                var result = await _dossiersQueryService.FetchDossier(request);
                return result;
            });
        }

        [HttpPost("listDossiers")]
        public Task<IActionResult> ListDossiers([FromBody] ListDossiersRequest request)
        {
            return ExecuteAsync(async () =>
            {
                var result = await _dossiersQueryService.ListDossiers(request);

                await Task.Delay(1); // TODO remove
                
                return result;
            });
        }
    }
}