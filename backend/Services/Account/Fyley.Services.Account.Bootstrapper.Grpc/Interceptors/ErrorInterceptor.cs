using System;
using System.Threading.Tasks;
using DDDCore.Domain.Errors;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace Fyley.Services.Account.Bootstrapper.Grpc.Interceptors
{
    public class ErrorInterceptor : Interceptor
    {
        private readonly ILogger<ErrorInterceptor> _logger;

        public ErrorInterceptor(ILogger<ErrorInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (DomainError e)
            {
                _logger.LogWarning("An domain exception occured\n{e}", e);
                
                var meta = new Metadata();
                var status = new Fyley.Grpc.Shared.Status
                {
                    Code = $"{e.GetType().Name}",
                    Message = $"Oops, something went wrong. ({ e.GetType().Name })"
                };
                meta.Add("status", status.ToByteArray());
                throw new RpcException(new Status(StatusCode.InvalidArgument, ""), meta);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError("An application exception occured\n{e}", e);
                
                var meta = new Metadata();
                var status = new Fyley.Grpc.Shared.Status
                {
                    Code = "unknown",
                    Message = $"Oops, something went wrong."
                };
                meta.Add("status-bin", status.ToByteArray());
                throw new RpcException(new Status(StatusCode.Internal, ""), meta);
            }
            catch (Exception e)
            {
                _logger.LogError("An unknown exception occured\n{e}", e);
                
                var meta = new Metadata();
                var status = new Fyley.Grpc.Shared.Status
                {
                    Code = "unknown",
                    Message = $"Oops, something went wrong."
                };
                meta.Add("status", status.ToByteArray());
                throw new RpcException(new Status(StatusCode.Unknown, ""), meta);
            }
        }
    }
}