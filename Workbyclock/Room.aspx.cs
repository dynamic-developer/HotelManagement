using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workbyclocklib.Models;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;

namespace Workbyclock
{
    public partial class Room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");
                }
            }
        }

        [WebMethod]
        public static List<RoomViewModel> GetAllRoom()
        {
            var es = new RoomService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetAllRoom();
        }

        [WebMethod]
        public static RoomViewModel GetRoomByRoomId(int RoomId)
        {
            var es = new RoomService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetRoomByRoomId(RoomId);
        }

        [WebMethod]
        public static int SaveRoom(int RoomId,
            string RoomName,
            string RoomDesc,
            int RoomBeds,
            int RoomPrice,
            int RoomStatusId,
            int CompanyId,
             int Locationid)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            int companyId = 0;
            if (HttpContext.Current.Session["companyid"] != null)
            {
                companyId = int.Parse(HttpContext.Current.Session["companyid"].ToString());
            }
            var es = new RoomService();
            var model = new RoomViewModel();
            model.RoomId = RoomId;
            model.RoomName = RoomName;
            model.RoomDesc = RoomDesc;
            model.RoomBeds = RoomBeds;
            model.RoomStatusId = RoomStatusId;
            model.CompanyId = companyId;
            model.Locationid = Locationid;
            model.RoomPrice = RoomPrice;
            return es.SaveRoom(model);
        }

        [WebMethod]
        public static int DeleteRoom(int RoomId)
        {
            var es = new RoomService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            return es.DeleteRoom(RoomId);
        }

        [WebMethod]
        public static List<RoomStatusMasterViewModel> GetAllRoomStatusMaster()
        {
            var es = new RoomService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            return es.GetAllRoomStatusMaster();
        }

        [WebMethod]
        public static List<LocationViewModel> GetAllLocations()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var es = new EmployeeService();
            return es.GetAllLocationsByCompanyId(int.Parse(HttpContext.Current.Session["companyid"].ToString()));
        }

    }
}