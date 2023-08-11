using CourseWebApi.WebAPI;

var builder = WebApplication.CreateBuilder(args);


var app = builder.ConfigureServices().ConfigurePipeline();

//Test secrectUser
app.MapGet("/GetJWTInfo", async (HttpContext context, IConfiguration configs) =>
{
    context.Response.StatusCode = 200;
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync($" <h1>{configs["JWTUserName"]} - {configs["JWTPassword"]} </h1>");
});
app.Run();
