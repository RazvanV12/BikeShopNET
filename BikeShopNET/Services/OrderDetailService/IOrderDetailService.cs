using BikeShopNET.Models;

namespace BikeShopNET.Services.OrderDetailService
{
    public interface IOrderDetailService
    {
        void CreateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(string orderDetailId);
        List<OrderDetail> GetAllOrderDetails();
    }
}
