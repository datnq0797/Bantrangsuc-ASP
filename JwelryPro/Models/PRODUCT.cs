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
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.DETAIL_CARDS = new HashSet<DETAIL_CARDS>();
        }
    
        public int ID_PRO { get; set; }
        public int ID_CATE { get; set; }
        public string NAME { get; set; }
        public float PRICE { get; set; }
        public string TITLE { get; set; }
        public string PATH { get; set; }
        public int SALES { get; set; }
        public Nullable<int> FAVOR { get; set; }
    
        public virtual CATEGORy CATEGORy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_CARDS> DETAIL_CARDS { get; set; }
    }
}
