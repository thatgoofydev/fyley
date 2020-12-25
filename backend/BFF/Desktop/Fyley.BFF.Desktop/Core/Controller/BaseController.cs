using System;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Fyley.BFF.Desktop.Core.Controller
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
            catch (Exception exception)
            {
                Log.Logger.Error("Uncaught exception: {exception}", exception);
                throw;
            }
        }
        
        protected async Task<IActionResult> ExecuteAsync<TResponse>(Func<Task<TResponse>> func)
            where TResponse : class
        {
            try
            {
                var data = await func.Invoke();
                return Ok(new ApiResponse<TResponse>
                {
                    Ok = true,
                    Data = data
                });
            }
            catch (Exception exception)
            {
                Log.Logger.Error("Uncaught exception: {exception}", exception);
                throw;
            }
        }
        
    }
}