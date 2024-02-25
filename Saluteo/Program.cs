using Saluteo.Repository;
using Saluteo.Models.Entity;
using Saluteo.Models.Enums;
using Saluteo.Services.Entity;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Saluteo.Services;

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

// Entity
builder.Services.AddScoped<IGenericRepository<Audit>, GenericRepository<Audit>>();
builder.Services.AddScoped<IGenericRepository<Branch>, GenericRepository<Branch>>();
builder.Services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
builder.Services.AddScoped<IGenericRepository<Company>, GenericRepository<Company>>();
builder.Services.AddScoped<IGenericRepository<Discount>, GenericRepository<Discount>>();
builder.Services.AddScoped<IGenericRepository<Location>, GenericRepository<Location>>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericRepository<Promotion>, GenericRepository<Promotion>>();
builder.Services.AddScoped<IGenericRepository<PromotionBranch>, GenericRepository<PromotionBranch>>();
builder.Services.AddScoped<IGenericRepository<PromotionClientClaimed>, GenericRepository<PromotionClientClaimed>>();
builder.Services.AddScoped<IGenericRepository<PromotionPeriod>, GenericRepository<PromotionPeriod>>();
builder.Services.AddScoped<IGenericRepository<PromotionProduct>, GenericRepository<PromotionProduct>>();
builder.Services.AddScoped<IGenericRepository<Review>, GenericRepository<Review>>();
builder.Services.AddScoped<IGenericRepository<ReviewConfiguration>, GenericRepository<ReviewConfiguration>>();
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<UserBranchAccess>, GenericRepository<UserBranchAccess>>();

// Services
builder.Services.AddScoped<BranchService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<DiscountService>();
builder.Services.AddScoped<LocationService>();
//builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<PromotionBranchService>();
builder.Services.AddScoped<PromotionClientClaimedService>();

// Enums
builder.Services.AddScoped<IGenericRepository<EnumCompanyCategory>, GenericRepository<EnumCompanyCategory>>();
builder.Services.AddScoped<IGenericRepository<EnumCountry>, GenericRepository<EnumCountry>>();
builder.Services.AddScoped<IGenericRepository<EnumCurrency>, GenericRepository<EnumCurrency>>();
builder.Services.AddScoped<IGenericRepository<EnumProductCategory>, GenericRepository<EnumProductCategory>>();
builder.Services.AddScoped<IGenericRepository<EnumPromotionType>, GenericRepository<EnumPromotionType>>();
builder.Services.AddScoped<IGenericRepository<EnumRecurringType>, GenericRepository<EnumRecurringType>>();
builder.Services.AddScoped<IGenericRepository<EnumRegion>, GenericRepository<EnumRegion>>();
builder.Services.AddScoped<IGenericRepository<EnumReviewType>, GenericRepository<EnumReviewType>>();
builder.Services.AddScoped<IGenericRepository<EnumSecurityAccessCode>, GenericRepository<EnumSecurityAccessCode>>();
builder.Services.AddScoped<IGenericRepository<EnumValueType>, GenericRepository<EnumValueType>>();

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
