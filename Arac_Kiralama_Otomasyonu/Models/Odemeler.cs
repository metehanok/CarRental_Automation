//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Arac_Kiralama_Otomasyonu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odemeler
    {
        public int odeme_no { get; set; }
        public int rezervasyon_id { get; set; }
        public System.DateTime odeme_tarihi { get; set; }
        public string odeme_turu { get; set; }
        public decimal tutar { get; set; }
    
        public virtual Rezervasyonlar Rezervasyonlar { get; set; }
    }
}