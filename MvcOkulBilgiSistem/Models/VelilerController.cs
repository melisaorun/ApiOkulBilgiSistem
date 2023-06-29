using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulBilgiSistem.Models
{
    public class VelilerModel
    {
        public int VeliNo { get; set; }
        public string VeliAdSoyad { get; set; }
        public string OgrenciAdSoyadi { get; set; }
        public string Yakinlik { get; set; }
        public string EgitimDurumu { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        

    }
}