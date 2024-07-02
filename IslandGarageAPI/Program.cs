using IslandGarageAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using IslandGarageAPI.Application.Extensions;
using IslandGarageAPI.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("IslandGarageAPI.Infrastructure"));
});

builder.Services.AddCors(options =>
{
    var allowedOrigin = builder.Configuration.GetValue<string>("CORSPolicy:AllowedOrigin");

    options.AddDefaultPolicy(x => {
        x.WithOrigins(allowedOrigin);
        x.AllowAnyMethod();
        x.AllowAnyHeader();
    });
});

builder.Services.AddInfrastructure();
builder.Services.AddServices();

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
