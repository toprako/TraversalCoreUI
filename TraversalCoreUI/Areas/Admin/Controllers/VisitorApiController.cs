using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreUI.Areas.Admin.Models;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7046/api/Visitor/VisitorList");
            if (responseMessage != null && responseMessage.IsSuccessStatusCode)
            {
                var visitorsJson = await responseMessage.Content.ReadAsStringAsync();
                var visitors = JsonConvert.DeserializeObject<List<VisitorViewModel>>(visitorsJson);
                return View(visitors);
            }
            return View();
        }

        public IActionResult CreateVisitor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7046/api/Visitor/VisitorAdd", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteVisitor(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7046/api/Visitor/VisitorDelete/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7046/api/Visitor/VisitorGet/?Id={Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var visitorsJson = await responseMessage.Content.ReadAsStringAsync();
                var visitor = JsonConvert.DeserializeObject<VisitorViewModel>(visitorsJson);
                return View(visitor);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7046/api/Visitor/UpdateVisitor/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
