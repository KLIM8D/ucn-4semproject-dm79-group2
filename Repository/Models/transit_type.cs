//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class transit_type
    {
        public transit_type()
        {
            this.transit_locations = new HashSet<transit_locations>();
        }
    
        public int tra_typ_id { get; set; }
        public string tra_typ_title { get; set; }
        public bool tra_typ_active { get; set; }
    
        public virtual ICollection<transit_locations> transit_locations { get; set; }
    }
}
