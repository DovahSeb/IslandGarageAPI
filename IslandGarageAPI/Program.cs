using IslandGarageAPI.Application.Extensions;
using IslandGarageAPI.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    var allowedOrigin = builder.Configuration.GetValue<string>("CORSPolicy:AllowedOrigin");

    options.AddDefaultPolicy(x => {
        x.WithOrigins(allowedOrigin);
        x.AllowAnyMethod();
        x.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
