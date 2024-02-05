using BikeShopNET.Models;

namespace BikeShopNET.Repositories.OrderDetailsRepository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly BikeShopContext _context;

        public OrderDetailsRepository(BikeShopContext context)
        {
            _context = context;
        }

        public void Create(OrderDetail entity)
        {
            _context.OrderDetails.Add(entity);
        }

        public void Delete(OrderDetail entity)
        {
            _context.OrderDetails.Remove(entity);
        }

        public List<OrderDetail> GetAll()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetail? GetById(string id)
        {
            return _context.OrderDetails.Find(id);
        }
    }
}
