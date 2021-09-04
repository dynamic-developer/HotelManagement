using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbyclocklib.Models;
using Workbyclocklib.ViewModels;

namespace Workbyclocklib.Services
{
    public class BookingPaymentService
    {
        public List<BookingPaymentViewModel> GetAllBookingPayments()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var model = (from e in ctx.BookingPayments
                             join j in ctx.PaymentTypes on e.PaymentTypeId equals j.PaymentTypeId
                             join rb in ctx.RoomBookings on e.BookingId equals rb.RoomBookingId
                             join rm in ctx.Rooms on rb.RoomId equals rm.RoomId
                             join gu in ctx.Guests on rb.GuestId equals gu.GuestId
                             select new BookingPaymentViewModel()
                             {
                                 BookingPaymentId = e.BookingPaymentId,
                                 BookingId = e.BookingId,
                                 PaymentTypeId = e.PaymentTypeId,
                                 PaymentAmount = e.PaymentAmount,
                                 PaymentDate = e.PaymentDate,
                                 PaymentAcceptedBy = e.PaymentAcceptedBy,
                                 PaymentTypeName = j.PaymentTypeName,
                                 RoomName = rm.RoomName,
                                 RoomPrice = rm.RoomPrice,
                                 GuestName = gu.GuestFullName,
                                 GuestPhone = gu.GuestPhone,
                                 BookingTypeId = rb.BookingTypeId
                             }).OrderBy(x => x.BookingPaymentId).ToList();
                return model;
            }
        }
        public BookingPaymentViewModel GetBookingPaymentsById(int bookingPaymentId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var model = (from e in ctx.BookingPayments
                        where e.BookingPaymentId == bookingPaymentId
                        select new BookingPaymentViewModel()
                        {
                            BookingPaymentId = e.BookingPaymentId,
                            BookingId = e.BookingId,
                            PaymentTypeId = e.PaymentTypeId,
                            PaymentAmount = e.PaymentAmount,
                            PaymentDate = e.PaymentDate,
                            PaymentAcceptedBy = e.PaymentAcceptedBy
                        }).FirstOrDefault();
                return model;
            }
        }
        public int SaveBookingPayments(BookingPaymentViewModel model)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                //var currentBookingPayment = ctx.BookingPayments.Where(c => c.BookingPaymentId == model.BookingPaymentId).FirstOrDefault();
                var currentBookingPayment = ctx.BookingPayments.Where(x => x.BookingId == model.BookingId).FirstOrDefault();
                var bookingPayment = new BookingPayment();
                var isNewBookingPayment = false;
                if (currentBookingPayment != null)
                {
                    model.BookingPaymentId = currentBookingPayment.BookingPaymentId;
                    bookingPayment = currentBookingPayment;
                    isNewBookingPayment = false;
                }
                else
                {
                    isNewBookingPayment = true;
                }

                bookingPayment.BookingPaymentId = model.BookingPaymentId;
                bookingPayment.BookingId = model.BookingId;
                bookingPayment.PaymentTypeId = model.PaymentTypeId;
                bookingPayment.PaymentAmount = model.PaymentAmount;
                bookingPayment.PaymentDate = model.PaymentDate;
                bookingPayment.PaymentAcceptedBy = model.PaymentAcceptedBy;

                if (isNewBookingPayment)
                    ctx.BookingPayments.Add(bookingPayment);
                ctx.SaveChanges();
                return bookingPayment.BookingPaymentId;
            }
        }
        public int DeleteBookingPayment(int bookingPaymentId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = ctx.BookingPayments.Where(c => c.BookingPaymentId == bookingPaymentId).FirstOrDefault();
                if (e != null)
                {

                    ctx.BookingPayments.Remove(e);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }



        #region PaymentTypes
        public List<PaymentTypesViewModel> GetAllPaymentTypes()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var model = (from e in ctx.PaymentTypes
                             select new PaymentTypesViewModel()
                             {
                                 PaymentTypeId = e.PaymentTypeId,
                                 PaymentTypeName = e.PaymentTypeName,
                                 PaymentTypeDesc = e.PaymentTypeDesc
                             }).OrderBy(x => x.PaymentTypeName).ToList();
                return model;
            }
        }
        #endregion

    }
}
