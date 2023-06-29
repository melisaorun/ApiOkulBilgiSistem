using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Models
{
    public class OgrencilerModel
    {
        public int OgrenciNo { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public string Sinifi { get; set; }
        public string Bolumu { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }


    }
}