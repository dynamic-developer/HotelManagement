using System;
using System.Collections.Generic;
using System.Web.Services;
using Workbyclocklib.Services;
using Workbyclocklib.ViewModels;
using System.Web;
namespace Workbyclock
{
    public partial class Employee : System.Web.UI.Page
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
        public static EmployeeViewModel GetEmployeeById(int EmployeeId)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var es = new EmployeeService();
            return es.GetEmployeesByEmployeeId(EmployeeId);

        }


        [WebMethod]
        public static List<EmploymentTypeViewModel> GetAllEmployementType()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var es = new EmployeeService();
            return es.GetEmploymentTypeViewModels();

        }

        [WebMethod]
        public static int SaveEmployee(int EmployeeId,
        int LocationId,
        int EmployeePin,
        string EmployeeName,
        string EmployeeEmail,
        string EmployeePhone,
        Nullable<int> EmployeeLastFour,
        Nullable<int> EmployeeEmploymentTypeId,
        Nullable<bool> EmployeeIsHourly,
        Nullable<float> EmployeeRate,
        Nullable<System.DateTime> EmployeeBirthDate,
        Nullable<System.DateTime> EmployeeHireDate,
        Nullable<System.DateTime> EmployeeLeftDate,
        string EmployeeAddress1,
        string EmployeeCity,
        string EmployeeState,
        string EmployeeZip,
        string EmployeeCountry,
        bool Active)
        {
            var es = new EmployeeService();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return 0;
            }
            bool isValidLocation = false;
            if(HttpContext.Current.Session["rolename"] != null && HttpContext.Current.Session["rolename"].ToString() == "System Admin")
            {
                isValidLocation = true;
               
            }
            else
            {
                if(HttpContext.Current.Session["rolename"] != null)
                {
                    if (HttpContext.Current.Session["id"] != null && HttpContext.Current.Session["companyid"] != null)
                    {
                        isValidLocation = es.IsValidLocationForUser(HttpContext.Current.Session["id"].ToString(), int.Parse(HttpContext.Current.Session["companyid"].ToString()), LocationId);

                    }
                }
            }
            
            if (!isValidLocation)
            {
                return 0;
            }
            var EmployeeObj = new EmployeeViewModel();
            EmployeeObj.EmployeeId = EmployeeId;
            EmployeeObj.LocationId = LocationId;
            EmployeeObj.EmployeePin = EmployeePin;
            EmployeeObj.EmployeeName = EmployeeName;
            EmployeeObj.EmployeeEmail = EmployeeEmail;
            if (!string.IsNullOrEmpty(EmployeePhone))
            {
                EmployeePhone = EmployeePhone.Replace("-", string.Empty);
                EmployeePhone = EmployeePhone.Replace("(", string.Empty);
                EmployeePhone = EmployeePhone.Replace(")", string.Empty);
                EmployeePhone = EmployeePhone.Replace(" ", string.Empty);
            }
            EmployeeObj.EmployeePhone = EmployeePhone;
            EmployeeObj.EmployeeLastFour = EmployeeLastFour;
            EmployeeObj.EmployeeEmploymentTypeId = EmployeeEmploymentTypeId;
            EmployeeObj.EmployeeIsHourly = EmployeeIsHourly;
            EmployeeObj.EmployeeRate = EmployeeRate;
            EmployeeObj.EmployeeBirthDate = EmployeeBirthDate;
            EmployeeObj.EmployeeHireDate = EmployeeHireDate;
            EmployeeObj.EmployeeLeftDate = EmployeeLeftDate;
            EmployeeObj.EmployeeAddress1 = EmployeeAddress1;
            EmployeeObj.EmployeeCity = EmployeeCity;
            EmployeeObj.EmployeeState = EmployeeState;
            EmployeeObj.EmployeeZip = EmployeeZip;
            EmployeeObj.EmployeeCountry = EmployeeCountry;
            EmployeeObj.Active = Active;
            return es.SaveEmployee(EmployeeObj);
            
        }
    }
}