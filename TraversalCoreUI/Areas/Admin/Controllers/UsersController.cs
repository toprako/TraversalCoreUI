using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UsersController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var users = _appUserService.TGetList();
            return View(users);
        }
        
        public IActionResult DeleteUser(Guid Id)
        {
            var user = _appUserService.TGetList().Where(x=> x.Id == Id).FirstOrDefault();
            if (user != null)
            {
                _appUserService.TDelete(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditUser(Guid Id)
        {
            var user = _appUserService.TGetList().Where(x => x.Id == Id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser entity)
        {
            _appUserService.TUpdate(entity);
            return RedirectToAction("Index");
        }

        public IActionResult ReservationUser(Guid Id)
        {
            var reservation = _reservationService.GetListWithReservationByAccepted(Id);
            return View(reservation);
        }
    }
}
