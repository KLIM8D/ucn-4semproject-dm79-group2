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
    
    public partial class vault_withdraws
    {
        public int vau_wit_id { get; set; }
        public int usr_det_id { get; set; }
        public decimal vau_wit_amount { get; set; }
        public byte[] vau_wit_timestamp { get; set; }
    
        public virtual user_details user_details { get; set; }
    }
}