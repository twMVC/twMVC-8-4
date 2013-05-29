using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace cacheSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = DateTime.Now;

            return View();
        }

        [OutputCache(Duration = 3, VaryByParam = "*")]
        public ActionResult cache1()
        {
            ViewBag.Message = DateTime.Now;
            return View();
        }

        public ActionResult cache2()
        {
            ViewBag.Message = DateTime.Now;
            return View();
        }

        [OutputCache(Duration = 6, VaryByParam = "*")]
        public ActionResult cache3()
        {
            return Content(DateTime.Now.ToString());
        }

        public ActionResult WebCacheSample(string c)
        {
            var time = WebCache.Get("TW MVC");
            if (time == null || c == "1")
            {
                time = DateTime.Now;
                WebCache.Set("TW MVC", time);
            }
            return View(time);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
