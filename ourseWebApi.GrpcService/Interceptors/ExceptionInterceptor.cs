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
    }
}
