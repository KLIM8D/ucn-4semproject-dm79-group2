
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
    
public partial class register_travel
{

    public int reg_tra_id { get; set; }

    public int tra_loc_id { get; set; }

    public int usr_det_id { get; set; }

    public int reg_dat_typ_id { get; set; }

    public System.DateTime reg_tra_timestamp { get; set; }



    public virtual register_date_type register_date_type { get; set; }

    public virtual transit_locations transit_locations { get; set; }

    public virtual user_details user_details { get; set; }

}

}
