using DA3.Models;

namespace DA3.Service.Contract
{
    public interface IOrderService
    {
        List<OrderModel> GetAllOrders();

        string Create(OrderModel orderModel);

        string CreateOrderDetail(OrderDetailModel orderDetailModel);

        OrderModel GetByUserId(string userId);

        OrderModel GetById(string orderId);

        string Update(OrderModel model);
    }
}
