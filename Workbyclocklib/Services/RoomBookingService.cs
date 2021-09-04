using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbyclocklib.Models;
using Workbyclocklib.ViewModels;

namespace Workbyclocklib.Services
{
    public class RoomBookingService
    {
        public List<RoomBookingViewModel> GetAllRoomBooking()
        {
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    return (from e in ctx.RoomBookings
                            join l in ctx.Companies on e.CompanyId equals l.CompanyId
                            join lo in ctx.Locations on e.LocationId equals lo.LocationId
                            join r in ctx.Rooms on e.RoomId equals r.RoomId
                            join g in ctx.Guests on e.GuestId equals g.GuestId
                            join b in ctx.BookingTypes on e.BookingTypeId equals b.BookingTypeId
                            join rm in ctx.RoomBookingStatusMasters on e.RoomBookingStatusId equals rm.RoomBookingStatusId into gj
                            join BP in ctx.BookingPayments on e.RoomBookingId equals BP.BookingId into Pdata
                            from x in gj.DefaultIfEmpty()
                            from PdataList in Pdata.DefaultIfEmpty()
                            select new RoomBookingViewModel()
                            {
                                RoomBookingId = e.RoomBookingId,
                                RoomId = e.RoomId,
                                GuestId = e.GuestId,
                                Price = e.Price,
                                FromDate = e.FromDate,
                                ToDate = e.ToDate,
                                BookingTypeId = e.BookingTypeId,
                                BookingDate = e.BookingDate,
                                CreateDate = e.CreateDate,
                                CompanyId = e.CompanyId,
                                LocationId = e.LocationId,
                                RoomName = r.RoomName,
                                GuestName = g.GuestFullName,
                                BookingTypeName = b.BookingTypeName,
                                CompanyName = l.CompanyName,
                                LocationName = lo.LocationName,
                                RoomBookingStatusId = e.RoomBookingStatusId,
                                RoomBookingStatusName = x.RoomBookingStatusName == null ? "" : x.RoomBookingStatusName,
                                BookingPaymentId = PdataList.BookingPaymentId,
                                PaymentAmount = PdataList.PaymentAmount
                            }).OrderByDescending(x => x.BookingDate).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public RoomBookingViewModel GetRoomBookingByRoomBookingId(int RoomBookingId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var model = (from e in ctx.RoomBookings
                        join g in ctx.Guests on e.GuestId equals g.GuestId
                        where e.RoomBookingId == RoomBookingId
                        select new RoomBookingViewModel()
                        {
                            RoomBookingId = e.RoomBookingId,
                            RoomId = e.RoomId,
                            GuestId = e.GuestId,
                            Price = e.Price,
                            FromDate = e.FromDate,
                            ToDate = e.ToDate,
                            BookingTypeId = e.BookingTypeId,
                            BookingDate = e.BookingDate,
                            CreateDate = e.CreateDate,
                            CompanyId = e.CompanyId,
                            LocationId = e.LocationId,
                            GuestName = g.GuestFullName,
                            GuestPhone = g.GuestPhone,
                            RoomBookingStatusId = e.RoomBookingStatusId,
                            RoomBookingStatusName = e.RoomBookingStatusMaster.RoomBookingStatusName,
                            RoomName = e.Room.RoomName
                        }).FirstOrDefault();
                return model;
            }
        }

        public int SaveRoomBooking(RoomBookingViewModel model)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var currentRoomBooking = ctx.RoomBookings.Where(c => c.RoomBookingId == model.RoomBookingId).FirstOrDefault();
                var roomBooking = new RoomBooking();
                var isNewRoomBooking = false;
                if (currentRoomBooking != null)
                {
                    roomBooking = currentRoomBooking;
                    isNewRoomBooking = false;
                }
                else
                {
                    isNewRoomBooking = true;
                }
                roomBooking.RoomBookingId = model.RoomBookingId;
                roomBooking.RoomId = model.RoomId;
                roomBooking.GuestId = model.GuestId;
                roomBooking.Price = model.Price;
                roomBooking.FromDate = model.FromDate;
                roomBooking.ToDate = model.ToDate;
                roomBooking.BookingTypeId = model.BookingTypeId;
                roomBooking.BookingDate = model.BookingDate;
                roomBooking.CreateDate = DateTime.UtcNow;
                roomBooking.CompanyId = model.CompanyId;
                roomBooking.LocationId = model.LocationId;
                roomBooking.RoomBookingStatusId = model.RoomBookingStatusId;
                if (isNewRoomBooking)
                    ctx.RoomBookings.Add(roomBooking);
                ctx.SaveChanges();

                //Update Room Status

                var currentRoom = ctx.Rooms.Where(c => c.RoomId == model.RoomId).FirstOrDefault();
                if (currentRoom != null)
                {
                    if (model.RoomBookingStatusId == 4)//In-House
                    {
                        currentRoom.RoomStatusId = 3; //Occupied
                    }
                    //Cancelled                                         // No Show
                    else if (model.RoomBookingStatusId == 3 || model.RoomBookingStatusId == 6)
                    {
                        currentRoom.RoomStatusId = 1; //Available
                    }
                    else if (model.RoomBookingStatusId == 5) //Checked Out
                    {
                        currentRoom.RoomStatusId = 2; //Dirty
                    }
                    ctx.SaveChanges();
                }


                return roomBooking.RoomBookingId;
            }
        }

        public int DeleteRoomBooking(int RoomBookingId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = ctx.RoomBookings.Where(c => c.RoomBookingId == RoomBookingId).FirstOrDefault();
                if (e != null)
                {
                    ctx.RoomBookings.Remove(e);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        public List<BookingTypeViewModel> GetAllBookingType()
        {

            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.BookingTypes
                        select new BookingTypeViewModel()
                        {
                            BookingTypeId = e.BookingTypeId,
                            BookingTypeName = e.BookingTypeName,
                            BookingTypeDesc = e.BookingTypeDesc,
                            IsTaxable = e.IsTaxable,
                            TaxInfoId = e.TaxInfoId,
                            CompanyId = e.CompanyId,
                            LocationId = e.LocationId,
                        }).ToList();
            }
        }

        public List<RoomBookingStatusMasterViewModel> GetAllRoomBookingStatusMaster()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.RoomBookingStatusMasters
                        select new RoomBookingStatusMasterViewModel()
                        {
                            RoomBookingStatusId = e.RoomBookingStatusId,
                            RoomBookingStatusName = e.RoomBookingStatusName,
                            RoomBookingStatusDesc = e.RoomBookingStatusDesc
                        }).ToList();
            }
        }

        public List<RoomViewModel> CheckRoomAvailability(DateTime fromDate, DateTime toDate)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {

                var matchingRooms = (from m in ctx.Rooms
                                     join rb in ctx.RoomBookings on m.RoomId equals rb.RoomId into groom
                                     from x in groom.DefaultIfEmpty()
                                     select new RoomViewModel
                                     {
                                         RoomId = m.RoomId,
                                         RoomName = m.RoomName,
                                         FromDate = x.FromDate,
                                         Todate = x.ToDate,
                                         RoomStatusId = m.RoomStatusId,
                                         RoomBookingStatusId = x.RoomBookingStatusId
                                     }).Where(x => x.RoomStatusId == 1 || x.RoomBookingStatusId == 3 || x.RoomBookingStatusId == 5 || x.RoomBookingStatusId == 6).ToList();

                matchingRooms = matchingRooms.GroupBy(x => x.RoomId).Select(g => g.First()).ToList();

                foreach (var item in matchingRooms.ToList())
                {
                    if (Convert.ToDateTime(item.FromDate).Date == fromDate.Date && Convert.ToDateTime(item.Todate).Date == toDate.Date)
                    {
                        matchingRooms.Remove(item);
                    }
                }


                return matchingRooms;
            }
        }
    }
}
