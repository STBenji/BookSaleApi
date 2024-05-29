using BookApi.Data;
using BookApi.Data.Repositories;
using BookApi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
builder.Services.AddAuthorization();
builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

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
app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
