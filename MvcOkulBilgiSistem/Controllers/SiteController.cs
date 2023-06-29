using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ogrenciler()
        {
            return View();
        }
        public ActionResult Veliler()
        {
            return View();
        }
        public ActionResult Odevler()
        {
            return View();
        }

    }
}