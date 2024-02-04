using BikeShopNET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

public class BikeShopContext : IdentityDbContext<AppUser>
{
    public BikeShopContext(DbContextOptions<BikeShopContext> options)
        : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<UserProfile> userProfiles { get; set; }


    // Restul metodelor și configurărilor...

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // Relația One-to-Many între User și Order
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.AppUser)
            .HasForeignKey(o => o.UserId);

        // Relația Many-to-Many între Order și Product necesită o entitate de join
        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => new { od.OrderId, od.ProductId }); // Cheia primară compusă pentru OrderDetail

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);
        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

        modelBuilder.Entity<AppUser>()
        .HasOne(u => u.UserProfile) // Un User are un UserProfile
        .WithOne(up => up.AppUser) // Un UserProfile este asociat cu un User
        .HasForeignKey<UserProfile>(up => up.UserId); // Cheia străină este în UserProfile

    }
}
