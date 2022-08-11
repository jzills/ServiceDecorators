using ValidationDecorator.Extensions;
using ValidationDecorator.Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddScoped<ApplicationService>();
// builder.Services.AddScoped<IApplicationService>(provider =>
//     new ApplicationServiceValidationDecorator(
//         provider.GetRequiredService<ApplicationService>()
//     )
// );
builder.Services.AddDecorator<IApplicationService, ApplicationService>(
    typeof(ApplicationServiceValidationDecorator),
    typeof(ApplicationServiceCacheDecorator)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
