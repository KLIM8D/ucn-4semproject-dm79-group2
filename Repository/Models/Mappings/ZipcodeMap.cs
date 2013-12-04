using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mappings
{
    public class ZipcodeMap : EntityTypeConfiguration<Zipcode>
    {
        public ZipcodeMap()
        {
            //Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.Property(t => t.Code).HasColumnName("geo_zip-code");
            this.Property(t => t.City).HasColumnName("geo_zip-city");
        }
    }
}
