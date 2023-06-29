using MvcOkulBilgiSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Controllers
{
    public class VelilerController : Controller
    {
        // GET: Veliler
        public ActionResult Index()
        {
            IEnumerable<VelilerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Velilers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<VelilerModel>>().Result;
            return View(listele);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new VelilerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Velilers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<VelilerModel>().Result);

            }
        }
        [HttpPost]
        public ActionResult EY(VelilerModel veliler)
        {
            if (veliler.VeliNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Velilers", veliler).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Velilers/" + veliler.VeliNo, veliler).Result;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Velilers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

    }
}