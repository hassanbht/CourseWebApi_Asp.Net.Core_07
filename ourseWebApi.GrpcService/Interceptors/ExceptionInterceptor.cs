using Azure.Core;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace CourseWebApi.GrpcService.Interceptors
{
    public class ExceptionInterceptor: Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }

        public override AsyncClientStreamingCall<TRequest, TResponse> AsyncClientStreamingCall<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context, AsyncClientStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            try
            {
                return base.AsyncClientStreamingCall(context, continuation);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }

        public override AsyncDuplexStreamingCall<TRequest, TResponse> AsyncDuplexStreamingCall<TRequest, TResponse>(ClientInterceptorContext<TRequest, TResponse> context, AsyncDuplexStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            try
            {
                return base.AsyncDuplexStreamingCall(context, continuation);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncServerStreamingCallContinuation<TRequest, TResponse> continuation)
        {           
            try
            {
                return base.AsyncServerStreamingCall(request, context, continuation);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {            
            try
            {
                return base.AsyncUnaryCall(request, context, continuation);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                trailers.Add("Interceptor", "True");
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }
        public override async Task<TResponse> ClientStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, ServerCallContext context, ClientStreamingServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(requestStream, context);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }
        public override Task DuplexStreamingServerHandler<TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream, IServerStreamWriter<TResponse> responseStream, ServerCallContext context, DuplexStreamingServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return base.DuplexStreamingServerHandler(requestStream, responseStream, context, continuation);
            }
            catch (Exception ex)
            {
                var correlationId = Guid.NewGuid().ToString();
                Metadata trailers = new Metadata();
                trailers.Add("CorrelationId", correlationId);
                throw new RpcException(new Status(StatusCode.Internal, ex.Message), trailers, "Serverside Excetption Message");
            }
        }
    }
}
