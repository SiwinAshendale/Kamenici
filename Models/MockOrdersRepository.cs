using Kamenici.Data;

namespace Kamenici.Models
{
    public class MockOrdersRepository:IOrdersRepository
    {
        private List<Order> _orderList;
        public MockOrdersRepository()
        {
            _orderList = new List<Order>()
            {
                new Order() { OrderId = 1, OrderDate = DateTime.Now, DueDate =DateTime.Today, CreatedBy = "c918217c-d1fd-4da6-9d0a-fb4c98ec05b2", Status = "Not Approved"}
            };
        }

        public Order Add(Order order)
        {
            throw new NotImplementedException();
        }

        public Order Delete(int id)
        {
            Order order = _orderList.FirstOrDefault(o => o.OrderId == id);
            if(order != null)
            {
                _orderList.Remove(order);
            }
            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderList;
        }

        public Order GetOrder(int id)
        {
            return _orderList.FirstOrDefault(o => o.OrderId == id);
        }

        public Order Update(Order orderChanges)
        {
            Order order = _orderList.FirstOrDefault(o => o.OrderId == orderChanges.OrderId);
            if (order != null)
            {
                order.OrderDate = orderChanges.OrderDate;
                order.CreatedBy = orderChanges.CreatedBy;
                order.DueDate = orderChanges.DueDate;
                order.Status = orderChanges.Status;
            }
            return order;
        }
    }
}
