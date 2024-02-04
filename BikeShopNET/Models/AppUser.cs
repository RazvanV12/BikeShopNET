using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BikeShopNET.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Please insert your First Name"), MaxLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please insert your Last Name"), MaxLength(100)]
        public string LastName { get; set; }

        public AppUser(ApplicationUserDTO audto)
        {
            FirstName = audto.FirstName;
            LastName = audto.LastName;
            Email = audto.Email;
        }
        public AppUser(AccountUserDTO accto)
        {
            FirstName = accto.FirstName;
            LastName = accto.LastName;
            Email = accto.Email;
            PhoneNumber = accto.PhoneNumber;
        }

        public AppUser() { }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
