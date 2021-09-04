using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbyclocklib.Models;
using Workbyclocklib.ViewModels;

namespace Workbyclocklib.Services
{
    public class AndroidEmployeeService
    {
        public AndroidLoginResponseModel VerifyUserLogin(AndroidUserLoginModel item)
        {
            AndroidLoginResponseModel result = null;
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {

                    var employeeInfo = (from e in ctx.Employees
                                        join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                                        join cl in ctx.CompanyLocations on el.LocationId equals cl.LocationId
                                        join c in ctx.Companies on cl.CompanyId equals c.CompanyId
                                        where e.EmployeeId == item.UserId &&
                                        e.EmployeePin == item.UserPin &&
                                        e.EmployeePhone == item.UserPhone &&
                                        e.Active == true &&
                                        c.Active == true
                                        select new EmployeeViewModel()
                                        {
                                            EmployeeId = e.EmployeeId,
                                            EmployeeAddress1 = e.EmployeeAddress1,
                                            EmployeeCity = e.EmployeeCity,
                                            EmployeeEmail = e.EmployeeEmail,
                                            EmployeeName = e.EmployeeName,
                                            EmployeePhone = e.EmployeePhone,
                                            EmployeePin = e.EmployeePin
                                        }).FirstOrDefault();
                    if (employeeInfo != null)
                    {
                        EmployeeService es = new EmployeeService();
                        result = new AndroidLoginResponseModel();
                        result.EmployeeViewModel = employeeInfo;
                        DateTime startDate = DateTime.Now;
                        DateTime endDate = DateTime.Now;
                        if (!string.IsNullOrEmpty(item.startDateString) && !string.IsNullOrEmpty(item.endDateString))
                        {
                            startDate = DateTime.Parse(item.startDateString);
                            endDate = DateTime.Parse(item.endDateString);
                        }
                        else if (string.IsNullOrEmpty(item.startDateString) && !string.IsNullOrEmpty(item.endDateString))
                        {

                            endDate = DateTime.Parse(item.endDateString);
                            startDate = endDate.AddDays(-14);
                        }
                        else if (!string.IsNullOrEmpty(item.startDateString) && string.IsNullOrEmpty(item.endDateString))
                        {
                            startDate = DateTime.Parse(item.startDateString);
                            endDate = startDate.AddDays(14);

                        }
                        else
                        {

                        }
                        result.TimeCards = es.GetEmployeeTime(employeeInfo.EmployeeId, startDate, endDate); 
                    }

                }
            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }
    }
}
