﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class REINMARTEntities : DbContext
    {
        internal object product;

        public REINMARTEntities()
            : base("name=REINMARTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bag> Bags { get; set; }
        public virtual DbSet<placeBid> placeBids { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}