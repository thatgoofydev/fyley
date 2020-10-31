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
    [Route("/bff/desktop/dossiers")]
    public class DossiersController : BaseController
    {
        private readonly IDossiersService _dossiersService;
        private readonly IDossiersQueryService _dossiersQueryService;

        public DossiersController(IDossiersService dossiersService, IDossiersQueryService dossiersQueryService)
        {
            _dossiersService = dossiersService;
            _dossiersQueryService = dossiersQueryService;
        }

        [HttpPost("submit-form")]
        public Task<IActionResult> SubmitForm([FromBody] CreateDossierRequest request)
        {
            return ExecuteAsync(async () =>
            {
                var result = await _dossiersService.CreateDossier(request);
                return result;
            });
        }

        [HttpPost("fetch-form")]
        public Task<IActionResult> FetchForm([FromBody] FetchDossierRequest request)
        {
            return ExecuteAsync(async () =>
            {
                if (request.Id == "new")
                {
                    return new FetchDossierResponse();
                }
                
                var result = await _dossiersQueryService.FetchDossier(request);
                return result;
            });
        }

        [HttpPost("overview-dossiers")]
        public Task<IActionResult> OverviewDossiers([FromBody] ListDossiersRequest request)
        {
            return ExecuteAsync(async () =>
            {
                var result = await _dossiersQueryService.ListDossiers(request);
                return result;
            });
        }
    }
}