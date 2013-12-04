﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mappings
{
    public class UserDetailsMap : EntityTypeConfiguration<UserDetails>
    {
        public UserDetailsMap()
        {
            //Primary key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("user_details");
            this.Property(t => t.Id).HasColumnName("usr_det-id");
            this.Property(t => t.FirstName).HasColumnName("usr_det-Fname");
            this.Property(t => t.SurName).HasColumnName("usr_det-Lname");
            this.Property(t => t.Ssn).HasColumnName("usr_det-soc");
            this.Property(t => t.PhoneNo).HasColumnName("usr_det-phoneno");
            this.Property(t => t.EMail).HasColumnName("usr_det-email");
            this.Property(t => t.Active).HasColumnName("usr_det-active");

            //Relationships
            this.HasRequired(t => t.Credentials);
            this.HasRequired(t => t.Address);
        }
    }
}