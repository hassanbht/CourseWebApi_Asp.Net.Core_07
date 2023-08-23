using ourseWebApi.GrpcService;
using ourseWebApi.GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();
