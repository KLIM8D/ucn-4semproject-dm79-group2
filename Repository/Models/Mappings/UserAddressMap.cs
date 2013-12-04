using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mappings
{
    public class UserAddressMap : EntityTypeConfiguration<UserAddress>
    {
        public UserAddressMap()
        {
            //Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("user_address");
            this.Property(t => t.Id).HasColumnName("usr_det-id");
            this.Property(t => t.Street).HasColumnName("usr_adr-street");

            //Relationships
            this.HasRequired(t => t.Zipcode);
        }
    }
}
