using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreUI.Areas.Admin.Models;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingHotelSearchController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?dest_type=city&room_number=1&units=metric&checkout_date=2023-09-28&locale=en-gb&dest_id=-553173&filter_by_currency=AED&checkin_date=2023-09-27&adults_number=2&order_by=popularity&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&children_ages=5%2C0&page_number=0&children_number=2&include_adjacency=true"),
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
                var model = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
                return View(model);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCityDestId(string city)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=tr&name={city}"),
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
                
            }
            return View();
        }
    }
}
