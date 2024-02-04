using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BikeShopNET.Models
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
