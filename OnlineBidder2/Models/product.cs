//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineBidder2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            this.placeBids = new HashSet<placeBid>();
        }
    
        public int productId { get; set; }
        public string productName { get; set; }
        public string StartingPrice { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> EndBidTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<placeBid> placeBids { get; set; }
    }
}
