using backend.finance.application.Interface;
using backend.finance.application.Mapping;
using backend.finance.application.Service;
using backend.finance.infra.Context;
using backend.finance.infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar DbContext
builder.Services.AddDbContext<Connection>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositórios e serviços
builder.Services.AddScoped<IAccountRepository, RepositoryAccount>();
builder.Services.AddScoped<IUserRepository, RepositoyUser>();
builder.Services.AddScoped<IAccount, AccountServices>();
builder.Services.AddScoped<ITransferAccountRepository, RepositoryTransfer>();
builder.Services.AddScoped<ITransferAccount, TransferAccountService>();
builder.Services.AddScoped<MapToAccount>();

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
