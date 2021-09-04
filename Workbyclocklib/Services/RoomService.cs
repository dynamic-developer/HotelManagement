using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbyclocklib.Models;
using Workbyclocklib.ViewModels;

namespace Workbyclocklib.Services
{
    public class RoomService
    {
        public List<RoomViewModel> GetAllRoom()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Rooms
                        join l in ctx.Companies on e.CompanyId equals l.CompanyId
                        join rs in ctx.RoomStatusMasters on e.RoomStatusId equals rs.StatusId
                        join lo in ctx.Locations on e.Locationid equals lo.LocationId
                        select new RoomViewModel()
                        {
                            RoomId = e.RoomId,
                            RoomName = e.RoomName ,
                            RoomDesc = e.RoomDesc,
                            RoomBeds = e.RoomBeds,
                            RoomStatusId = e.RoomStatusId,
                            CompanyId = e.CompanyId,
                            Locationid = e.Locationid,
                            RoomStatusName = rs.StatusName,
                            CompanyName = l.CompanyName,
                            LocationName = lo.LocationName,
                            RoomPrice = e.RoomPrice
                        }).ToList();
            }
        }

        public RoomViewModel GetRoomByRoomId(int RoomId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Rooms
                        where e.RoomId == RoomId
                        select new RoomViewModel()
                        {
                            RoomId = e.RoomId,
                            RoomName = e.RoomName,
                            RoomDesc = e.RoomDesc,
                            RoomBeds = e.RoomBeds,
                            RoomStatusId = e.RoomStatusId,
                            CompanyId = e.CompanyId,
                            Locationid = e.Locationid,
                            RoomPrice = e.RoomPrice
                        }).FirstOrDefault();
            }
        }

        public int SaveRoom(RoomViewModel model)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var currentRoom = ctx.Rooms.Where(c => c.RoomId == model.RoomId).FirstOrDefault();
                var Room = new Room();
                var isNewRoom = false;
                if (currentRoom != null)
                {
                    Room = currentRoom;
                    isNewRoom = false;
                }
                else
                {
                    isNewRoom = true;
                }
                Room.RoomId = model.RoomId;
                Room.RoomName = model.RoomName;
                Room.RoomDesc = model.RoomDesc;
                Room.RoomBeds = model.RoomBeds;
                Room.RoomStatusId = model.RoomStatusId;
                Room.CompanyId = model.CompanyId;
                Room.Locationid = model.Locationid;
                Room.RoomPrice = model.RoomPrice;
                if (isNewRoom)
                    ctx.Rooms.Add(Room);
                ctx.SaveChanges();
                return Room.RoomId;
            }
        }

        public int DeleteRoom(int RoomId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = ctx.Rooms.Where(c => c.RoomId == RoomId).FirstOrDefault();
                if (e != null)
                {

                    ctx.Rooms.Remove(e);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }


        public List<RoomStatusMasterViewModel> GetAllRoomStatusMaster()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from m in ctx.RoomStatusMasters
                        select new RoomStatusMasterViewModel() { 
                            StatusId = m.StatusId,
                            StatusName = m.StatusName,
                            StatusDesc = m.StatusDesc
                        }).ToList();
            }
        }


    }
}
