
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Workbyclocklib.Models
{

using System;
    using System.Collections.Generic;
    
public partial class CompanyLocation
{

    public int CompanyLocationId { get; set; }

    public int CompanyId { get; set; }

    public int LocationId { get; set; }

    public System.DateTime CreateDate { get; set; }

    public bool Active { get; set; }



    public virtual Company Company { get; set; }

    public virtual Location Location { get; set; }

}

}
