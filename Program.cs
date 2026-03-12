using Microsoft.EntityFrameworkCore;
using CustomerApi.Data;
using CustomerApi.Models;
using CustomerApi.Repositories;
using CustomerApi.Services;
using CustomerApi.Configuration;


var builder = WebApplication.CreateBuilder(args);

var baseConnection = builder.Configuration.GetConnectionString("CRMConnection");

var user = Environment.GetEnvironmentVariable("CRM_DB_USER");
var password = Environment.GetEnvironmentVariable("CRM_DB_PASSWORD");

var fullConnection =
    $"{baseConnection};User Id={user};Password={password};";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(fullConnection));

builder.Services.AddControllers();

builder.Services.AddScoped<CsvExportService>();

builder.Services.AddScoped<ICustomerDeltaRepository<CRMCustomerDelta>, CustomerDeltaRepository>();

builder.Services.AddScoped<ICustomerDeltaRepository<CRMCustomerContactDelta>, CustomerContactDeltaRepository>();

builder.Services.Configure<SftpSettings>(
    builder.Configuration.GetSection("SftpSettings"));

builder.Services.AddScoped<SftpService>();

var app = builder.Build();

app.MapControllers();

app.Run();