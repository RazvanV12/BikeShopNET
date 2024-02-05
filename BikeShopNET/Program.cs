using BikeShopNET.Models;
using BikeShopNET.Services.AppUserService;
using BikeShopNET.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BikeShopNET.Repositories.ProductRepository;
using BikeShopNET.Services.ProductService;


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
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});


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