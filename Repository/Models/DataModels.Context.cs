﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RKConn : DbContext
    {
        public RKConn()
            : base("name=RKConn")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<card_issued> card_issued { get; set; }
        public DbSet<card_retracted> card_retracted { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<geo_zipcodes> geo_zipcodes { get; set; }
        public DbSet<security_credentials> security_credentials { get; set; }
        public DbSet<security_groups> security_groups { get; set; }
        public DbSet<user_address> user_address { get; set; }
        public DbSet<user_details> user_details { get; set; }
    }
}
