using BikeShopNET.Models;

namespace BikeShopNET.Repositories.OrderDetailsRepository
{
    public interface IOrderDetailsRepository
    {
        void Create(OrderDetail entity);
        void Delete(OrderDetail entity);
        List<OrderDetail> GetAll();

        OrderDetail? GetById(string id);
    }
}
