using System;
using System.Collections.Generic;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workbyclocklib.Services;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Workbyclocklib.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Workbyclock.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>

        private EmployeeService _employeeService;
        private AndroidEmployeeService _androidEmployeeService;
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
            _androidEmployeeService = new AndroidEmployeeService();
        }

        [HttpGet]
        [Route("api/employee/getallemployee")]
        public HttpResponseMessage GetAllEmployee(int companyId)
        {
            var emp = _employeeService.GetAllEmployeesByCompanyId(companyId);
            if (emp != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Employee Not Found");
            }
        }

        [HttpPost]
        [Route("api/employee/varify")]
        public HttpResponseMessage VarifyApp(DesktopAppModel item)
        {
            var emp = _employeeService.VerifyApp(item);
            if (!string.IsNullOrEmpty(emp))
            {
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NOT VALID");
            }
        }

        [HttpPost]
        [Route("api/employee/setup")]
        public HttpResponseMessage SetupApp(DesktopUserModel item)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(item.UserName, item.Password);
            if (user != null)
            {
                var emp = _employeeService.SetupApp(item);
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NOT VALID");
            }
            
            
        }

        [HttpPost]
        [Route("api/employee/clockin")]
        public HttpResponseMessage ClockIn(DesktopEmployeeModel item)
        {
            if (item != null && item.EmployeeId > 0 && int.Parse(item.EmployeePin) > 0 )
            {
                var emp = _employeeService.SaveClockIn(item.EmployeeId, int.Parse(item.EmployeePin),item.LocationId,item.LocationIp,item.DeviceCode,item.EmployeeStart,item.EmployeeStartString);
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NOT VALID");
            }


        }

        [HttpPost]
        [Route("api/employee/clockout")]
        public HttpResponseMessage ClockOut(DesktopEmployeeModel item)
        {
             if (item != null && item.EmployeeId > 0 && int.Parse(item.EmployeePin) > 0)
            {
                var emp = _employeeService.SaveClockOut(item.EmployeeId, int.Parse(item.EmployeePin), item.LocationId,  item.DeviceCode,item.EmployeeEnd,item.EmployeeEndString);
                return Request.CreateResponse(HttpStatusCode.OK, emp);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NOT VALID");
            }


        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


        //Android calls
        [HttpPost]
        [Route("api/android/verifylogin")]
        public HttpResponseMessage AndroidVerifyLogin(AndroidUserLoginModel item)
        {
            var result = _androidEmployeeService.VerifyUserLogin(item);
            if (result != null && result.EmployeeViewModel != null && result.EmployeeViewModel.EmployeeId == item.UserId)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "failed");
            }


        }
    }
}