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
    
    public partial class KiralamaDurumu
    {
        public int kiralama_durumu_no { get; set; }
        public int arac_id { get; set; }
        public byte kiralik { get; set; }
        public Nullable<System.DateTime> baslangic_tarihi { get; set; }
        public Nullable<System.DateTime> bitis_tarihi { get; set; }
    
        public virtual Araclar Araclar { get; set; }
    }
}
