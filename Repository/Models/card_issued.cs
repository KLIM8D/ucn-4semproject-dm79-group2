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
    
    public partial class card_issued
    {
        public int car_iss_id { get; set; }
        public int usr_det_id { get; set; }
        public int car_iss_no { get; set; }
        public System.DateTime car_iss_timestamp { get; set; }
        public bool car_iss_active { get; set; }
    
        public virtual user_details user_details { get; set; }
    }
}
