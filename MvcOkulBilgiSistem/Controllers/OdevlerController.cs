using MvcOkulBilgiSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Controllers
{
    public class OdevlerController : Controller
    {
        // GET: Odevler
        public ActionResult Index()

        {
            IEnumerable<OdevlerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Odevlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<OdevlerModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new OdevlerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Odevlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<OdevlerModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(OdevlerModel odevler)
        {
            if (odevler.OdevNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Odevlers", odevler).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Odevlers/" + odevler.OdevNo, odevler).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Odevlers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}