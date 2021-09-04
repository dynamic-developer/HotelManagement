using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workbyclocklib.ViewModels;
using Workbyclocklib.Services;
namespace Workbyclock.custom
{
    public partial class EmployeeTimesheet : System.Web.UI.Page
    {
        public bool IsAllowedRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Account/Login");
                }
                if (HttpContext.Current.Session["rolename"] != null && (HttpContext.Current.Session["rolename"].ToString() == "System Admin" || HttpContext.Current.Session["rolename"].ToString() == "Company Admin"))
                {
                    IsAllowedRole = true;

                }
                else
                {
                    IsAllowedRole = false;
                }
            }
        }

        [WebMethod]
        public static List<EmployeeTimeCardViewModel> GetAllTimesheetForEmployee(string startDateString, string endDateString, int employeeId)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (!string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
            {
                startDate = DateTime.Parse(startDateString);
                endDate = DateTime.Parse(endDateString);
            }
            else if (string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
            {

                endDate = DateTime.Parse(endDateString);
                startDate = endDate.AddDays(-14);
            }
            else if (!string.IsNullOrEmpty(startDateString) && string.IsNullOrEmpty(endDateString))
            {
                startDate = DateTime.Parse(startDateString);
                endDate = startDate.AddDays(14);

            }
            else
            {

            }
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            if (employeeId == 0)
            {
                return null;
            }
            var es = new EmployeeService();
            return es.GetEmployeeTime(employeeId, startDate, endDate);
        }

        [WebMethod]
        public static bool EmailAllTimesheetForEmployee(string startDateString, string endDateString, int employeeId)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            if (!string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
            {
                startDate = DateTime.Parse(startDateString);
                endDate = DateTime.Parse(endDateString);
            }
            else if (string.IsNullOrEmpty(startDateString) && !string.IsNullOrEmpty(endDateString))
            {

                endDate = DateTime.Parse(endDateString);
                startDate = endDate.AddDays(-14);
            }
            else if (!string.IsNullOrEmpty(startDateString) && string.IsNullOrEmpty(endDateString))
            {
                startDate = DateTime.Parse(startDateString);
                endDate = startDate.AddDays(14);

            }
            else
            {

            }
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return false;
            }
            if (employeeId == 0)
            {
                return false;
            }
            var es = new EmployeeService();
            var timeSheetList = es.GetEmployeeTime(employeeId, startDate, endDate);
            if (timeSheetList != null && timeSheetList.Count > 0)
            {
                var employee = es.GetEmployeesByEmployeeId(timeSheetList[0].EmployeeId);

                var bodyHeader = @"<center><table width='920' border='0' cellspacing='0' cellpadding='0' ><tr>
<td bgcolor='#D0372F' height='8' colspan='3'></td></tr><tr><td bgcolor='#ffffff' colspan='3'><table width='860' border='0' cellspacing='0' cellpadding='0' >
<tr><td width='400' bgcolor='#ffffff'></td><td width='400' valign='bottom'><a href='http://www.workbyclock.com' target='_blank'>
<img src='http://www.workbyclock.com/images/logo-1-1.png' width='120' height='120'></a><br/>
<span style='font-family:Tahoma,Arial;font-size:14px;color:#D0372F;line-height:19px;padding-left:0px;' >Work By Clock</span></td>
<td></td><td valign='middle'><span style='font-family:Tahoma,Arial;line-height:19px' ></span></td></tr></table></td>
</tr><tr><td width='20' bgcolor='#ffffff' ></td><td><table width='720' border='0' cellspacing='0' cellpadding='0' style='padding-left:15px;'><tr>
<td width='20' bgcolor='#FFFFFF'> </td><td valign='top' bgcolor='#FFFFFF'><table width='100%' border='0' cellspacing='0' cellpadding='0'>
<tr><td height='10'></td></tr><tr><td><span style='font-family:Tahoma,Arial;color:#333333;line-height:26px' >";
                bodyHeader = bodyHeader + "TimeSheet for " + employee.EmployeeName + "</span><br></td></tr>";
                bodyHeader = bodyHeader + "<tr><td height='6'></td></tr><tr><td height='10'><p style='font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px'>Below is your timesheet for " + startDateString + " to " + endDateString + " </p>";
                string bodyMain = "<p>";
                double hourTotal = 0;
                for (var i = 0; i < timeSheetList.Count; i++)
                {
                    string st = @"<br>" + timeSheetList[i].TimeInSt + " - " + timeSheetList[i].TimeOutSt + " = " + timeSheetList[i].Hours;
                    bodyMain = bodyMain + st;
                    hourTotal = hourTotal + timeSheetList[i].Hours;
                }
                bodyMain = bodyMain + "</p><p> Your Total Hours : <b>" + hourTotal + "</b></p>";

                string bodyFooter = @"<p style = 'font-family:Tahoma,Arial;font-size:13px;
color:#666666;line-height:16px' > Thank you and hope you have a wonderful day ahead! </p >
<p style = 'font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px' ></p >
<p style = 'font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px' ></p >
<p style = 'font-family:Tahoma,Arial;font-size:13px;color:#666666;line-height:16px' > Work By Clock Team
<br /><a href = 'http://www.workbyclock.com' target = '_blank' > www.workbyclock.com </a ></p ></td ></tr >
</table ></td ><td width = '20' bgcolor = '#FFFFFF' ></td ><td width = '20' bgcolor = '#ffffff' ></td ></tr >
</table ></td ><td width = '20' bgcolor = '#ffffff' ></td ></tr ><tr ><td width = '20' bgcolor = '#ffffff' ></td >
<td bgcolor = '#FFFFFF' ><br ><br ><table width = '720' border = '0' cellspacing = '0' cellpadding = '0' >
<tr ><td width = '20' bgcolor = '#ffffff' ></td ><td ><br ><div align = 'center' ><span style = 'font-family:Tahoma,Verdana,Helvetica,sans-serif;font-size:11px;color:#666666;line-height:13px' >
©Copyright WorkByClock. All Rights Reserved.<br ></span ></div ></td ><td width = '20' bgcolor = '#ffffff' ></td ></tr >
</table ><br ><br ></td ><td width = '20' bgcolor = '#ffffff' ></td ></tr ></table ></center >";

                string emailMain = bodyHeader + bodyMain + bodyFooter;
                WbcEmailService dal = new WbcEmailService();
                dal.SendHtmlEmail("alkeshpatel53227@gmail.com", "Work By Clock | Timesheet for " + employee.EmployeeName + " Hours between " + startDateString + " - " + endDateString, emailMain);
                if (!string.IsNullOrEmpty(employee.EmployeeEmail))
                {
                    dal.SendHtmlEmail(employee.EmployeeEmail, "Work By Clock | Timesheet for " + employee.EmployeeName + " Hours between " + startDateString + " - " + endDateString, emailMain);
                }
            }

            return true;

        }

    }
}