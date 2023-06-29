using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Models
{
    public class OdevlerModel
    {
        public int OdevNo { get; set; }
        public string OgrenciAdiSoyadi { get; set; }
        public string Ders { get; set; }
        public string VerilisTarihi { get; set; }
        public string TeslimTarihi { get; set; }
        public int Notu { get; set; }
        public string Konu { get; set; }


    }
}