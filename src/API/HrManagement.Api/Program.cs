using HrManagement.Application;
using HrManagement.Infrastructure;
using HrManagement.EfCore;

var builder = WebApplication.CreateBuilder(args);
string corsPolicy = "CorsPolicy";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureEfCoreServices(builder.Configuration); // wireup
builder.Services.ConfigureInfrastructureServices(builder.Configuration); 
builder.Services.ConfigureApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p =>
{
    p.AddPolicy(corsPolicy, r => r
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corsPolicy);

app.MapControllers();

app.Run();
