
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
    
public partial class security_credentials
{

    public security_credentials()
    {

        this.user_details = new HashSet<user_details>();

    }


    public int sec_cre_id { get; set; }

    public int sec_gro_id { get; set; }

    public string sec_cre_uname { get; set; }

    public string sec_cre_passwd { get; set; }

    public System.DateTime sec_cre_timestamp { get; set; }

    public bool sec_cre_active { get; set; }



    public virtual ICollection<user_details> user_details { get; set; }

    public virtual security_groups security_groups { get; set; }

}

}
