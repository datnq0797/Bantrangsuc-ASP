//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JwelryPro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETAIL_CARDS
    {
        public int ID_DETAIL_CARDS { get; set; }
        public int ID_PRO { get; set; }
        public int ID_CARDS { get; set; }
        public int QUANTITY { get; set; }
        public Nullable<float> TOTAL_PRICE { get; set; }
    
        public virtual CARD CARD { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}