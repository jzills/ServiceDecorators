using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServiceDecorators.Extensions;
using ServiceDecorators.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddScopedWithDecorator<IApplicationService, ApplicationService>(
    typeof(ApplicationServiceValidationDecorator),
    typeof(ApplicationServiceCacheDecorator)
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(config => 
{
    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Service Decorators");
    config.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();