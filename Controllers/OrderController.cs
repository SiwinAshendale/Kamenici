using Kamenici.Models;
using Microsoft.AspNetCore.Mvc;
namespace Kamenici.Controllers
{
    public class OrderController : Controller
    {
        private IOrdersRepository _ordersRepository;
        public OrderController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public ViewResult AllOrders()
        {
            var model = _ordersRepository.GetAllOrders();
            return View(model);
        }
    }
}
