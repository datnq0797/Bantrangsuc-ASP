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
    
    public partial class CARD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARD()
        {
            this.DETAIL_CARDS = new HashSet<DETAIL_CARDS>();
        }
    
        public int ID_CARDS { get; set; }
        public string NAMES_CUS { get; set; }
        public string SDT { get; set; }
        public string DIACHI { get; set; }
        public string EMAIL { get; set; }
        public float TOTAL { get; set; }
        public int TRANGTHAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_CARDS> DETAIL_CARDS { get; set; }
    }
}
