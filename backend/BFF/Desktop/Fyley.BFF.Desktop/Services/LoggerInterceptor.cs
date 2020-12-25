using System;
using System.Diagnostics;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Serilog;

namespace Fyley.BFF.Desktop.Services
{
    public class LoggerInterceptor : Interceptor
    {
        private const string MessageTemplate = "{RequestMethod} finished in {Elapsed:0.0000} ms";
        
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            AddCorrelationId(context);
            
            var sw = Stopwatch.StartNew();

            var result = continuation(request, context);
            
            sw.Stop();
            Log.Logger.Information(MessageTemplate,
                context.Method,
                sw.Elapsed.TotalMilliseconds);
            
            return result;
        }

        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context, AsyncClientStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            AddCorrelationId(context);
            return continuation(context);
        }

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncServerStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            AddCorrelationId(context);
            return continuation(request, context);
        }

        public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context, AsyncDuplexStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            AddCorrelationId(context);
            return continuation(context);
        }

        private static void AddCorrelationId<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context)
            where TRequest : class
            where TResponse : class
        {
            var headers = context.Options.Headers;
            
            // Call doesn't have a headers collection to add to.
            // Need to create a new context with headers for the call.
            if (headers == null)
            {
                headers = new Metadata();
                var options = context.Options.WithHeaders(headers);
                context = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, options);
            }
            
            headers.Add("X-Correlation-Id", Guid.NewGuid().ToString());
        }
    }
}