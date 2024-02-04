using Microsoft.AspNetCore.Identity;



namespace BikeShopNET.Models
{
    public class SeedData
    {

        private readonly BikeShopContext context;

        public SeedData(BikeShopContext _context)
        {
            context = _context;
        }
        public void Initialize()
        {
            SeedRoles();
        }


        private void SeedRoles()
        {
            if (context.Roles.Any())
            {
                return; // baza de date contine deja roluri
            }
            // CREAREA ROLURILOR IN BD
            // daca nu contine roluri, acestea se vor crea
            context.Roles.AddRange(
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af483d56fd7210", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Id = "2c5e174e-3b0e-446f-86af483d56fd7212", Name = "User", NormalizedName = "User".ToUpper() }
            );

            var hasher = new PasswordHasher<AppUser>();


            // CREAREA USERILOR IN BD
            // Se creeaza cate un user pentru fiecare rol
            context.Users.AddRange(
                new AppUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb0",
                    UserName = "admin@test.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "ADMIN@TEST.COM",
                    Email = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin1!")
                },
                new AppUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb2",
                    UserName = "user@test.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "USER@TEST.COM",
                    Email = "user@test.com",
                    NormalizedUserName = "USER@TEST.COM",
                    PasswordHash = hasher.HashPassword(null, "User1!")
                }
            );

            // ASOCIEREA USER-ROLE
            context.UserRoles.AddRange(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
                },
               new IdentityUserRole<string>
               {
                   RoleId = "2c5e174e-3b0e-446f-86af483d56fd7212",
                   UserId = "8e445865-a24d-4543-a6c6-9443d048cdb2"
               }
            );



            context.SaveChanges();
        }
    }

}
