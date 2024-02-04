using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShopNET.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }

        // Navigational properties
        public AppUser AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

}
