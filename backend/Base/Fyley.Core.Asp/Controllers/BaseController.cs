using System;
using System.Threading.Tasks;
using DDDCore.Domain.Errors;
using Fyley.Core.Asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fyley.Core.Asp.Controllers
{
    public class BaseController : ControllerBase
    {
        
        protected async Task<IActionResult> ExecuteAsync(Func<Task> func)
        {
            try
            {
                await func.Invoke();
                return Ok(new ApiResponse
                {
                    Ok = true
                });
            }
            catch (DomainError ex)
            {
                return Ok(new ApiResponse
                {
                    Ok = false,
                    Error = ex.Message // TODO add clean error or something
                });
            }
        }

        protected async Task<IActionResult> ExecuteAsync<TResponse>(Func<Task<TResponse>> func)
        {
            try
            {
                var response = await func.Invoke();
                return Ok(new ApiResponse<TResponse>
                {
                    Ok = true,
                    Data = response
                });
            }
            catch (DomainError ex)
            {
                return Ok(new ApiResponse<TResponse>
                {
                    Ok = false,
                    Error = ex.Message // TODO add clean error text
                });
            }
        }
        
    }
}