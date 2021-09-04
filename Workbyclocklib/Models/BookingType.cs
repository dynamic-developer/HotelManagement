
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
    
public partial class BookingType
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public BookingType()
    {

        this.RoomBookings = new HashSet<RoomBooking>();

    }


    public int BookingTypeId { get; set; }

    public string BookingTypeName { get; set; }

    public string BookingTypeDesc { get; set; }

    public bool IsTaxable { get; set; }

    public Nullable<int> TaxInfoId { get; set; }

    public int CompanyId { get; set; }

    public int LocationId { get; set; }



    public virtual Company Company { get; set; }

    public virtual Location Location { get; set; }

    public virtual TaxInfo TaxInfo { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<RoomBooking> RoomBookings { get; set; }

}

}