using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IOrderService
    {
        List<OrderModel> AllOrders();

        string Create(OrderModel orderModel);

        string CreateOrderDetail(OrderDetailModel orderDetailModel);

        OrderModel GetByUserId(string userId);
    }
}
