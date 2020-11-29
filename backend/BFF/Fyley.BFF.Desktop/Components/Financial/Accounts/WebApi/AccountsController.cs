﻿using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Adapters;
using Fyley.BFF.Desktop.Components.Financial.Accounts.ViewModel;
using Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit;
using Fyley.Core.Asp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi
{
    [ApiController]
    [Route("bff/desktop/accounts")]
    public class AccountsController : BaseController
    {
        private readonly AccountServiceAdapter _serviceAdapter;
        private readonly AccountViewModelFactory _viewModelFactory;

        public AccountsController(AccountServiceAdapter serviceAdapter, AccountViewModelFactory viewModelFactory)
        {
            _serviceAdapter = serviceAdapter;
            _viewModelFactory = viewModelFactory;
        }

        [HttpPost("submit/{id}")]
        public Task<IActionResult> Submit([FromRoute] string id, [FromBody] SubmitAccountRequest request)
        {
            return ExecuteAsync(async () =>
            {
                if (id == "new")
                {
                    return await _serviceAdapter.DefineAccount(request);
                }

                return new SubmitAccountResponse(Guid.Empty);
            });
        }

        [HttpPost("list")]
        public Task<IActionResult> List()
        {
            return ExecuteAsync(async () => await _viewModelFactory.List());
        }
    }
}