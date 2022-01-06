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
            ViewBag.Today = DateOnly.FromDateTime(DateTime.Today);
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
        [HttpGet]
        public async Task<IActionResult> EditFrame(int id)
        {
            var frame = _framesRepository.getFrame(id);
            if (frame == null)
            {
                ViewBag.ErrorMessage = $"Frame with Id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new EditFrameViewModel
            {
                FrameId = frame.FrameId,
                Width = frame.Width,
                Height = frame.Height,
                Available = frame.Available.HasValue ? frame.Available.Value : false,
                Price = frame.Price,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditFrame(EditFrameViewModel model)
        {
            var frame = _framesRepository.getFrame(model.FrameId);
            if(frame == null)
            {
                ViewBag.ErrorMessage = $"Frame with Id = {model.FrameId} cannot be found";
                return View("NotFound");
            } else
            {
                frame.Width= model.Width;
                frame.Height= model.Height;
                frame.Available= model.Available;
                frame.Price= model.Price;
                var result = _framesRepository.Update(frame);
                if (result != null)
                {
                    return RedirectToAction("AllFrames");
                }
                return View(model);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DeleteFrame(int frameId)
        {
            if(frameId == null)
            {
                return View("NotFound");
            }

            var frame = _framesRepository.getFrame(frameId);
            if(frame == null)
            {
                return View("NotFound");
            }
            var model = new DeleteFrameViewModel
            {
                FrameId = frameId,
                Available = frame.Available.HasValue ? frame.Available.Value : false,
                Price = frame.Price,
                Height = frame.Height,
                Width = frame.Width
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int frameId)
        {
            _framesRepository.Delete(frameId);
            return RedirectToAction("AllFrames");
        }
    }
}
