using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Repository.Models.Mappings
{
    public class SecurityCredentialsMap : EntityTypeConfiguration<SecurityCredentials>
    {
        public SecurityCredentialsMap()
        {
            //Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("security_credentials");
            this.Property(t => t.Password).HasColumnName("sec_cre-passwd");
            this.Property(t => t.Active).HasColumnName("sec_cre-active");

            //Relationships
            this.HasRequired(t => t.Group);
        }
    }
}
