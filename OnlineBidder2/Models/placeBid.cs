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
    
    public partial class placeBid
    {
        public int bidId { get; set; }
        public Nullable<System.DateTime> BidDate { get; set; }
        public string HighestBid { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> productId { get; set; }
    
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
