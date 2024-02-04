using BikeShopNET.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var bikeShopConnectionString = builder.Configuration.GetConnectionString("BikeShopConnection") ?? throw new InvalidOperationException("Connection string 'BikeShopConnection' not found.");
builder.Services.AddDbContext<BikeShopContext>(options =>
    options.UseSqlServer(bikeShopConnectionString));

builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.User.RequireUniqueEmail = true)
   .AddRoles<IdentityRole>()
   .AddEntityFrameworkStores<BikeShopContext>();


builder.Services.AddTransient<SeedData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Run seeders
using (var serviceScope = app.Services.CreateScope())
{
    var seeder = serviceScope.ServiceProvider.GetRequiredService<SeedData>();
    seeder.Initialize();
}

app.Run();