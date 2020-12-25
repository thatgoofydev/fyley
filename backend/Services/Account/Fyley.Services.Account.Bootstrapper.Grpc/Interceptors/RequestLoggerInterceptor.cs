using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Serilog;

namespace Fyley.Services.Account.Bootstrapper.Grpc.Interceptors
{
    public class RequestLoggerInterceptor : Interceptor
    {
        private const string MessageTemplate = "{RequestMethod} responded {StatusCode} in {Elapsed:0.0000} ms";
        
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var correlationId = context.RequestHeaders.FirstOrDefault(h => h.Key.Equals("X-Correlation-Id", StringComparison.OrdinalIgnoreCase))?.Value;
            using var _ = Serilog.Context.LogContext.PushProperty("CorrelationID", correlationId);
            
            var sw = Stopwatch.StartNew();
            
            var response = await continuation(request, context);

            sw.Stop();
            Log.Logger.Information(MessageTemplate,
                context.Method,
                context.Status.StatusCode,
                sw.Elapsed.TotalMilliseconds);

            return response;
        }
    }
}