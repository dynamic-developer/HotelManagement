using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbyclocklib.Models;
using Workbyclocklib.ViewModels;

namespace Workbyclocklib.Services
{
    public class GuestService
    {
        public List<GuestViewModel> GetAllGuest()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Guests
                        join l in ctx.Companies on e.CompanyId equals l.CompanyId
                        select new GuestViewModel()
                        {
                            GuestId = e.GuestId,
                            GuestFullName = e.GuestFullName,
                            GuestPhone = e.GuestPhone,
                            GuestEmail = e.GuestEmail,
                            IsDNR = e.IsDNR,
                            GuestAddress = e.GuestAddress,
                            GuestDriverLicenseId = e.GuestDriverLicenseId,
                            CompanyId = e.CompanyId,
                            CompanyName = l.CompanyName
                        }).ToList();
            }
        }

        public GuestViewModel GetGuestByGuestId(int guestId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Guests
                        where e.GuestId == guestId
                        select new GuestViewModel()
                        {
                            GuestId = e.GuestId,
                            GuestFullName = e.GuestFullName,
                            GuestPhone = e.GuestPhone,
                            GuestEmail = e.GuestEmail,
                            IsDNR = e.IsDNR,
                            GuestAddress = e.GuestAddress,
                            GuestDriverLicenseId = e.GuestDriverLicenseId,
                            CompanyId = e.CompanyId
                        }).FirstOrDefault();
            }
        }

        public int SaveGuest(GuestViewModel model)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var currentGuest = ctx.Guests.Where(c => c.GuestId == model.GuestId).FirstOrDefault();
                var guest = new Guest();
                var isNewguest = false;
                if (currentGuest != null)
                {
                    guest = currentGuest;
                    isNewguest = false;
                }
                else
                {
                    isNewguest = true;
                }
                guest.GuestId = model.GuestId;
                guest.GuestFullName = model.GuestFullName;
                guest.GuestPhone = model.GuestPhone;
                guest.GuestEmail = model.GuestEmail;
                guest.IsDNR = model.IsDNR;
                guest.GuestAddress = model.GuestAddress;
                guest.GuestDriverLicenseId = model.GuestDriverLicenseId;
                guest.CompanyId = model.CompanyId;
                if (isNewguest)
                    ctx.Guests.Add(guest);
                ctx.SaveChanges();
                return guest.GuestId;
            }
        }

        public int DeleteGuest(int guestId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = ctx.Guests.Where(c => c.GuestId == guestId).FirstOrDefault();
                if (e != null)
                {

                    ctx.Guests.Remove(e);
                    ctx.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
