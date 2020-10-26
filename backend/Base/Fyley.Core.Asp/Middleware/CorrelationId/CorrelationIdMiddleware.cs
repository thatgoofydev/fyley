using System;
using System.Linq;
using System.Threading.Tasks;
using DDDCore.Infrastructure.CorrelationId;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;

namespace Fyley.Core.Asp.Middleware.CorrelationId
{
    public class CorrelationIdMiddleware
    {
        private const string Header = "X-Correlation-Id";
            
        private readonly RequestDelegate  _next;

        public CorrelationIdMiddleware(RequestDelegate  next)
        {
            _next = next;
        }

        [UsedImplicitly]
        public async Task InvokeAsync(HttpContext context, ICorrelationContextFactory factory)
        {
            var hasCorrelationId = context.Request.Headers.TryGetValue(Header, out var stringValues);
            var correlationId = hasCorrelationId ? stringValues.First() : Guid.NewGuid().ToString();
            factory.CreateContext(correlationId);
            await _next(context);
        }
    }
}