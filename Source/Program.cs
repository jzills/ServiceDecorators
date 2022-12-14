using Microsoft.EntityFrameworkCore;
using Source.Data;
using Source.Extensions;
using Source.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase(nameof(ApplicationDbContext))
);

builder.Services.AddMemoryCache();

builder.Services.AddWithDecorators<IApplicationService, ApplicationService>(
    ServiceLifetime.Scoped,
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