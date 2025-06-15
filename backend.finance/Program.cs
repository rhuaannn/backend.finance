using backend.finance.application.Interface;
using backend.finance.application.Mapper;
using backend.finance.application.Mapping;
using backend.finance.application.Service;
using backend.finance.infra.Context;
using backend.finance.infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Registrar DbContext
builder.Services.AddDbContext<Connection>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios e serviços
builder.Services.AddScoped<IAccountRepository, RepositoryAccount>();
builder.Services.AddScoped<IUserRepository, RepositoyUser>();
builder.Services.AddScoped<IUser, UserServices>();
builder.Services.AddScoped<IAccount, AccountServices>();
builder.Services.AddScoped<ITransferAccountRepository, RepositoryTransfer>();
builder.Services.AddScoped<ITransferAccount, TransferAccountService>();
builder.Services.AddScoped<MapToAccount>();
builder.Services.AddScoped<MapToUser>();
builder.Services.AddScoped<MapToTransfer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
