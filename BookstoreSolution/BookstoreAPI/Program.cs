using MediatR;
using BookstoreApplication;
using BookstoreInfrastructure;
using BookstoreApplication.Features.Authors.Commands;
using BookstoreApplication.Features.Books.Commands;
using BookstoreInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookstoreDomain.Entities;
using BookstoreInfrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using BookstoreInfrastructure.Seed;
using BookstoreApplication.Common.Interfaces;
using BookstoreInfrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity EFCore
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Register AuthService
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentitySeeder.SeedRolesAndAdminAsync(services);
}

app.Run();


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//builder.Services.AddMediatR(cfg =>
//    cfg.RegisterServicesFromAssembly(typeof(CreateBookCommand).Assembly));

////builder.Services.AddApplication();       // <- we'll add this in a moment
//builder.Services.AddInfrastructure(builder.Configuration);

////AppDbContext
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

////Identity EFCore
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>();

//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();


//    var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await IdentitySeeder.SeedRolesAndAdminAsync(services);
//}

//app.Run();
