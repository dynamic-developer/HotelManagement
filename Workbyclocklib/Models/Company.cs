
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
    
public partial class Company
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Company()
    {

        this.CompanyLocations = new HashSet<CompanyLocation>();

        this.CompanyUsers = new HashSet<CompanyUser>();

        this.BookingTypes = new HashSet<BookingType>();

        this.RoomBookings = new HashSet<RoomBooking>();

        this.Rooms = new HashSet<Room>();

        this.TaxInfoes = new HashSet<TaxInfo>();

        this.Guests = new HashSet<Guest>();

    }


    public int CompanyId { get; set; }

    public string CompanyName { get; set; }

    public string CompanyDescription { get; set; }

    public string CompanyPhone { get; set; }

    public string CompanyEmail { get; set; }

    public string CompanyWebsite { get; set; }

    public string CompanyAddress1 { get; set; }

    public string CompanyAddress2 { get; set; }

    public string CompanyCity { get; set; }

    public string CompanyState { get; set; }

    public string CompanyZip { get; set; }

    public string CompanyCountry { get; set; }

    public byte[] CompanyLogo { get; set; }

    public string CompanyAdminId { get; set; }

    public int CompanyNumberOfUsers { get; set; }

    public int CompanyNumberOfLocation { get; set; }

    public System.DateTime CreateDate { get; set; }

    public bool Active { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CompanyLocation> CompanyLocations { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CompanyUser> CompanyUsers { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<BookingType> BookingTypes { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<RoomBooking> RoomBookings { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Room> Rooms { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TaxInfo> TaxInfoes { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Guest> Guests { get; set; }

}

}
