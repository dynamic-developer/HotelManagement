﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DB_132062_workbyclockEntities1 : DbContext
{
    public DB_132062_workbyclockEntities1()
        : base("name=DB_132062_workbyclockEntities1")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyLocation> CompanyLocations { get; set; }

    public virtual DbSet<CompanyUser> CompanyUsers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeLocation> EmployeeLocations { get; set; }

    public virtual DbSet<EmployeeTimeCard> EmployeeTimeCards { get; set; }

    public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInRole> UserInRoles { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<EmployeeTimeCardHistory> EmployeeTimeCardHistories { get; set; }

    public virtual DbSet<BookingPayment> BookingPayments { get; set; }

    public virtual DbSet<BookingType> BookingTypes { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<RoomBooking> RoomBookings { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomStatusMaster> RoomStatusMasters { get; set; }

    public virtual DbSet<TaxInfo> TaxInfoes { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<RoomBookingStatusMaster> RoomBookingStatusMasters { get; set; }

}

}

