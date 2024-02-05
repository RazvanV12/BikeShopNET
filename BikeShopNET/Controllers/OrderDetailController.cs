using Microsoft.AspNetCore.Mvc;
using BikeShopNET.Services.OrderDetailService;
using BikeShopNET.Models;

namespace BikeShopNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        [Route("GetAllOrderDetails")]
        public List<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailService.GetAllOrderDetails();
        }

        [HttpDelete]
        [Route("DeleteOrderDetail")]
        public void DeleteOrderDetail([FromBody] string orderDetailId)
        {
            _orderDetailService.DeleteOrderDetail(orderDetailId);
        }

        [HttpPost]
        [Route("AddOrderDetail")]
        public void AddOrderDetail([FromBody] OrderDetail orderDetail)
        {
            _orderDetailService.CreateOrderDetail(orderDetail);
        }

    }
}
