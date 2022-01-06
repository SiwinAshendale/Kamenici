using Kamenici.Data;
using Kamenici.Models;
using Kamenici.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kamenici.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersRepository _ordersRepository;
        private readonly UserManager<IdentityUser> userManager;
        private IFramesRepository _framesRepository;
        public OrdersController(IOrdersRepository ordersRepository, UserManager<IdentityUser> userManager, IFramesRepository framesRepository)
        {
            _ordersRepository = ordersRepository;
            this.userManager = userManager;
            _framesRepository = framesRepository;
        }

        public ViewResult AllOrders()
        {
            var model = _ordersRepository.GetAllOrders();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateOrder(int FrameId)
        {
            var model = new CreateOrderViewModel(FrameId);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            var username = HttpContext.User.Identity.Name;
            var createdbyid = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            if (ModelState.IsValid)
            {
                Order order = new Order(model.FrameId, model.DueDate, createdbyid);
                _ordersRepository.Add(order);
            }
            return RedirectToAction("MyOrders");
        }
        [HttpGet]
        public async Task<IActionResult> NewOrder()
        {
            var model = _framesRepository.getAllFrames();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditOrder(int orderid)
        {
            var order = _ordersRepository.GetOrder(orderid);
            if(order == null)
            {
                ViewBag.ErrorMessage = $"Frame with Id = {orderid} canot be found";
                return View("NotFound");
            }
            var model = new EditOrderViewModel
            {
                OrderId = order.OrderId,
                OrderDate = order.DueDate,
                DueDate = order.DueDate,
                Status = order.Status,
                FrameId = order.FrameId,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditOrder(EditOrderViewModel model)
        {
            var order = _ordersRepository.GetOrder(model.OrderId);
            if(order == null)
            {
                ViewBag.ErrorMessage = $"Order with Id = {model.OrderId} cannot be found";
                return View("NotFound");
            } else
            {
                order.Status = model.Status;
                order.DueDate = model.DueDate;
                order.OrderDate = model.OrderDate;
                model.FrameId = order.FrameId;
                var result = _ordersRepository.Update(order);
                if(result != null)
                {
                    return RedirectToAction("AllOrders");
                }
                return View(model);
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            if(orderId == null)
            {
                return View("NotFound");
            }
            var order = _ordersRepository.GetOrder(orderId);
            if(order == null)
            {
                return View("NotFound");
            }
            var model = new DeleteOrderViewModel
            {
                OrderId = orderId,
                DueDate = order.DueDate,
                FrameId = order.FrameId,
                OrderDate = order.OrderDate,
                Status = order.Status,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int orderId)
        {
            _ordersRepository.Delete(orderId);
            return RedirectToAction("AllOrders");
        }
        public ViewResult MyOrders()
        {
            var allorders = _ordersRepository.GetAllOrders();
            var username = HttpContext.User.Identity.Name;
            var createdbyid = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            var model = new List<Order>();
            foreach (var order in allorders)
            {
                if(order.CreatedBy == createdbyid)
                {
                    model.Add(order);
                }
            }
            return View(model);
        }
    }
}
