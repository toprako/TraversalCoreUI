﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            using (var c = new Context())
            {
                ViewBag.v1 = c.Destinations.Count();
                ViewBag.v2 = c.Guides.Count();
                ViewBag.v3 = "25";
            }
            return View();
        }
    }
}
