using Kamenici.Data;
using Kamenici.Models;
using Kamenici.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace Kamenici.Controllers
{
    public class FramesController : Controller
    {
        private IFramesRepository _framesRepository;
        private readonly UserManager<IdentityUser> userManager;
        public FramesController(IFramesRepository framesRepository, UserManager<IdentityUser> userManager)
        {
            _framesRepository = framesRepository;
            this.userManager = userManager;
        }
        [HttpGet] 
        public IActionResult CreateFrame()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFrame(CreateFrameViewModel model)
        {
            var username = HttpContext.User.Identity.Name;
            var createdbyid = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            if (ModelState.IsValid)
            {
                Frame frame = new Frame(model.Width, model.Height, model.Price, createdbyid);
                _framesRepository.Add(frame);
            }
            return RedirectToAction("AllFrames");
        }
        [HttpGet]
        public ViewResult AllFrames()
        {
            var model = _framesRepository.getAllFrames();
            return View(model);
        }
    }
}
