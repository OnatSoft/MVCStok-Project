//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCStok_Project.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satislar_TBL
    {
        public int SatisID { get; set; }
        public int Urun { get; set; }
        public Nullable<byte> Adet { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public int Musteri { get; set; }
        public string Marka { get; set; }
        public string MusteriTel { get; set; }
        public string MusteriMail { get; set; }
    
        public virtual Musteriler_TBL Musteriler_TBL { get; set; }
        public virtual Urunler_TBL Urunler_TBL { get; set; }
    }
}
