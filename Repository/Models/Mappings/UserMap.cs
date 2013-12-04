using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mappings
{
    [Table("UserDetails", Schema = "public")]
    public class UserMap : EntityTypeConfiguration<UserDetails>
    {
        public UserMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("public.user_details");
            this.Property(t => t.Id).HasColumnName("usr_det-id");
            this.Property(t => t.FirstName).HasColumnName("usr_det-fname");
            this.Property(t => t.SurName).HasColumnName("usr_det-lname");
            this.Property(t => t.Ssn).HasColumnName("usr_det-soc");
            this.Property(t => t.PhoneNo).HasColumnName("usr_det-phoneno");
            this.Property(t => t.EMail).HasColumnName("usr_det-email");
            //this.Property(t => t.Active).HasColumnName("usr_det-active");
        }
    }
}
