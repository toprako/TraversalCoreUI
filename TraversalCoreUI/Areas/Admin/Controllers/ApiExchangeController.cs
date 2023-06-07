using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreUI.Areas.Admin.Models;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
                {
                    { "X-RapidAPI-Key", "512fc9b7b8mshbf52ae8fbb0e180p119c79jsna281d41270f2" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiExchangeViewModel>(body);
                return View(values.exchange_rates);
            }
            return View();
        }
    }
}
