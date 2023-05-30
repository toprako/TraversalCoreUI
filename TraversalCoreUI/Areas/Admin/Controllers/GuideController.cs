using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var guide = _guideService.TGetList();
            return View(guide);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide entity)
        {
            GuideValidator validations = new GuideValidator();
            ValidationResult result = validations.Validate(entity);
            if (result.IsValid)
            {
                _guideService.TAdd(entity);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditGuide(int Id)
        {
            var guide = _guideService.TGetByID(Id);
            return View(guide);
        }

        [HttpPost]
        public IActionResult EditGuide(Guide entity)
        {
            _guideService.TUpdate(entity);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToTrue(int Id)
        {
            _guideService.TChangeToTrueByGuide(Id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        public IActionResult ChangeToFalse(int Id)
        {
            _guideService.TChangeToFalseByGuide(Id);
            return RedirectToAction("Index", "Guide", new {area = "Admin"});
        }
    }
}
