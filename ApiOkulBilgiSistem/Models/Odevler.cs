//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiOkulBilgiSistem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odevler
    {
        public int OdevNo { get; set; }
        public string OgrenciAdiSoyadi { get; set; }
        public string Ders { get; set; }
        public string VerilisTarihi { get; set; }
        public string TeslimTarihi { get; set; }
        public Nullable<int> Notu { get; set; }
        public string Konu { get; set; }
    }
}
