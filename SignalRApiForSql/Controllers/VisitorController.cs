using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Models;

namespace SignalRApiForSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult CreateVisitor()
        {
            Random rnd = new();
            Enumerable.Range(0, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    Visitor newVisitor = new()
                    {
                        City = item,
                        CityVisitCount = rnd.Next(100, 2000),
                        VisitDate = DateTime.Now.AddDays(x).ToUniversalTime(),
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçiler Başarılı Bir Şekilde Eklendi");
        }
    }
}
