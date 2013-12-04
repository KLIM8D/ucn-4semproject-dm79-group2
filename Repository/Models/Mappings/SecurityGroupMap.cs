﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mappings
{
    public class SecurityGroupMap : EntityTypeConfiguration<SecurityGroup>
    {
        public SecurityGroupMap()
        {
            //Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.Property(t => t.Title).HasColumnName("sec_gro-title");
            this.Property(t => t.Active).HasColumnName("sec_gro-active");
        }
    }
}
