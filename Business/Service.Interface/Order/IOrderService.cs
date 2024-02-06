using Model.Order;
using Entity.Model;


namespace Service.Interface.Order
{
    public interface IOrderService
    {
        Task<ReadOrder> CreateOrderFromCart(AddOrder request);
        Task<Entity.Model.Order> DeleteOrder(DeleteOrder request);
        float? CalculateTotalAmount(List<OrderItem> orderItems);
        Task<List<ReadOrder>> GetOrdersByUserId();

    }
}
