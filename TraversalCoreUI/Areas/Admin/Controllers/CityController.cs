using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreUI.Models.CityVM;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public JsonResult AddCityDestination(Destination entity)
        {
            entity.Status = true;
            _destinationService.TAdd(entity); 
            return Json(JsonConvert.SerializeObject(entity));
        }

        
        public static List<CityClass> Cities = new List<CityClass>()
        {
            new CityClass
            {
                CityID = 1,
                CityName = "Üsküp",
                CityCountry = "Makedonya",
            },
            new CityClass
            {
                CityID = 2,
                CityName = "Roma",
                CityCountry = "İtalya",
            },
            new CityClass
            {
                CityID = 3,
                CityName = "Londra",
                CityCountry = "İngiltere",
            },
        };
    }
}
