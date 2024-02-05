using BikeShopNET.Models;
using BikeShopNET.Repositories.OrderDetailsRepository;

namespace BikeShopNET.Services.OrderDetailService
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailsRepository.Create(orderDetail);
        }

        public void DeleteOrderDetail(string orderDetailId)
        {
            var orderDetail = _orderDetailsRepository.GetById(orderDetailId);
            _orderDetailsRepository.Delete(orderDetail);
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailsRepository.GetAll();
        }
    }
}
