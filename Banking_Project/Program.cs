using Banking_Project.Connection;
using Banking_Project.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = builder.Configuration.GetConnectionString("myconnection");
builder.Services.AddDbContext<ApplicationDbContext>(op=>op.UseSqlServer(connection));
builder.Services.AddScoped<ICustomerReposatory, CustomerReposatory>();
builder.Services.AddScoped<IBankReposatory, BankReposatory>();
builder.Services.AddScoped<IAccountReposatory, AccountReposatory>();    
builder.Services.AddScoped<ITransactionnReposatory, TransactionnReposatory>();

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
