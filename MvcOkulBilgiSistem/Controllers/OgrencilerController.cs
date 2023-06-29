using MvcOkulBilgiSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        public ActionResult Index()
        {
            IEnumerable<OgrencilerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Ogrencilers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<OgrencilerModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new OgrencilerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Ogrencilers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<OgrencilerModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult EY(OgrencilerModel ogrenciler)
        {
            if (ogrenciler.OgrenciNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Ogrencilers", ogrenciler).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Ogrencilers/" + ogrenciler.OgrenciNo, ogrenciler).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Ogrencilers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}