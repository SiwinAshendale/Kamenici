using Kamenici.Data;

namespace Kamenici.Models
{
    public interface IOrdersRepository
    {
        Order GetOrder(int id);
        IEnumerable<Order> GetAllOrders();
        Order Add(Order order);
        Order Update(Order order);
        Order Delete(int id);
    }
}
