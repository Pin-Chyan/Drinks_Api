using Saluteo.Repository;
using Saluteo.Models.Entity;
using Saluteo.Models.Enums;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Log or print the connection string
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
Console.WriteLine($"Connection String: {connectionString}");

// Configure DbContext
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    // Replace "YourConnectionString" with your actual connection string name
});

// Register Services
// Entity
builder.Services.AddScoped<IRepository<Audit>, RepositoryContext<Audit>>();
builder.Services.AddScoped<IRepository<Branch>, RepositoryContext<Branch>>();
builder.Services.AddScoped<IRepository<Client>, RepositoryContext<Client>>();
builder.Services.AddScoped<IRepository<Company>, RepositoryContext<Company>>();
builder.Services.AddScoped<IRepository<Discount>, RepositoryContext<Discount>>();
builder.Services.AddScoped<IRepository<Location>, RepositoryContext<Location>>();
builder.Services.AddScoped<IRepository<Product>, RepositoryContext<Product>>();
builder.Services.AddScoped<IRepository<Promotion>, RepositoryContext<Promotion>>();
builder.Services.AddScoped<IRepository<PromotionBranch>, RepositoryContext<PromotionBranch>>();
builder.Services.AddScoped<IRepository<PromotionClientClaimed>, RepositoryContext<PromotionClientClaimed>>();
builder.Services.AddScoped<IRepository<PromotionPeriod>, RepositoryContext<PromotionPeriod>>();
builder.Services.AddScoped<IRepository<PromotionProduct>, RepositoryContext<PromotionProduct>>();
builder.Services.AddScoped<IRepository<Review>, RepositoryContext<Review>>();
builder.Services.AddScoped<IRepository<ReviewConfiguration>, RepositoryContext<ReviewConfiguration>>();
builder.Services.AddScoped<IRepository<User>, RepositoryContext<User>>();
builder.Services.AddScoped<IRepository<UserBranchAccess>, RepositoryContext<UserBranchAccess>>();

// Enums
builder.Services.AddScoped<IRepository<EnumCompanyCategory>, RepositoryContext<EnumCompanyCategory>>();
builder.Services.AddScoped<IRepository<EnumCountry>, RepositoryContext<EnumCountry>>();
builder.Services.AddScoped<IRepository<EnumCurrency>, RepositoryContext<EnumCurrency>>();
builder.Services.AddScoped<IRepository<EnumProductCategory>, RepositoryContext<EnumProductCategory>>();
builder.Services.AddScoped<IRepository<EnumPromotionType>, RepositoryContext<EnumPromotionType>>();
builder.Services.AddScoped<IRepository<EnumRecurringType>, RepositoryContext<EnumRecurringType>>();
builder.Services.AddScoped<IRepository<EnumRegion>, RepositoryContext<EnumRegion>>();
builder.Services.AddScoped<IRepository<EnumReviewType>, RepositoryContext<EnumReviewType>>();
builder.Services.AddScoped<IRepository<EnumSecurityAccessCode>, RepositoryContext<EnumSecurityAccessCode>>();
builder.Services.AddScoped<IRepository<EnumValueType>, RepositoryContext<EnumValueType>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Check the database connection
using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    // Execute a simple query to get the current database
    using (var command = new SqlCommand("SELECT DB_NAME() AS CurrentDatabase", connection))
    {
        var currentDatabase = command.ExecuteScalar();
        Console.WriteLine($"Connected to Database: {currentDatabase}");
    }
}

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
