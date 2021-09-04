using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Workbyclocklib.Models;
using Workbyclocklib.ViewModels;


namespace Workbyclocklib.Services
{
    public class EmployeeService
    {
        public string VerifyApp(DesktopAppModel item)
        {
            var result = string.Empty;

            using (var ctx = new DB_132062_workbyclockEntities1())
            {

                var companyInfo = (from c in ctx.Companies
                                   join cu in ctx.CompanyUsers on c.CompanyId equals cu.CompanyId
                                   where c.CompanyId == item.CompanyId &&
                                   c.Active == true
                                   select new CompanyViewModel()
                                   {
                                       CompanyId = c.CompanyId,
                                       CompanyName = c.CompanyName
                                   }).FirstOrDefault();
                if (companyInfo == null)
                {
                    return "Not Valid Company";
                }
                var locInfo = (from l in ctx.Locations
                               join lc in ctx.CompanyLocations on l.LocationId equals lc.LocationId
                               where lc.CompanyId == item.CompanyId && l.LocationId == item.LocationId
                               && l.Active == true
                               select new LocationViewModel()
                               {
                                   LocationId = l.LocationId,
                                   LocationName = l.LocationName
                               }).FirstOrDefault();
                if (locInfo == null)
                {
                    return "Not Valid Location";
                }
                var devInfo = (from d in ctx.Devices
                               join l in ctx.Locations on d.LocationId equals l.LocationId
                               where l.LocationId == locInfo.LocationId && d.DeviceCode == item.DeviceCode
                               && d.DeviceId == item.DeviceId
                               && d.Active == true
                               select new DeviceViewModel()
                               {
                                   DeviceId = d.DeviceId,
                                   DeviceCode = d.DeviceCode,
                                   DeviceDescription = d.DeviceDescription
                               }).FirstOrDefault();
                if (devInfo == null)
                {
                    return "Not Valid Device";
                }
            }

            return "success";
        }
        public DesktopAppModel SetupApp(DesktopUserModel item)
        {
            DesktopAppModel result = null;
            var currentUserInfo = GetUserInfoByUsername(item.UserName);
            if (!currentUserInfo.Active)
            {
                return null;
            }
            using (var ctx = new DB_132062_workbyclockEntities1())
            {

                var companyInfo = (from c in ctx.Companies
                                   join cu in ctx.CompanyUsers on c.CompanyId equals cu.CompanyId
                                   where c.CompanyId == item.CompanyId &&
                                   cu.UserId == currentUserInfo.Id && c.Active == true
                                   select new CompanyViewModel()
                                   {
                                       CompanyId = c.CompanyId,
                                       CompanyName = c.CompanyName
                                   }).FirstOrDefault();
                if (companyInfo == null)
                {
                    return null;
                }
                var locInfo = (from l in ctx.Locations
                               join lc in ctx.CompanyLocations on l.LocationId equals lc.LocationId
                               where lc.CompanyId == item.CompanyId && l.LocationId == item.LocationId
                               && l.Active == true
                               select new LocationViewModel()
                               {
                                   LocationId = l.LocationId,
                                   LocationName = l.LocationName
                               }).FirstOrDefault();
                if (locInfo == null)
                {
                    return null;
                }
                var devInfo = (from d in ctx.Devices
                               join l in ctx.Locations on d.LocationId equals l.LocationId
                               where l.LocationId == locInfo.LocationId
                               && d.Active == true && d.IsUsed == false
                               select new DeviceViewModel()
                               {
                                   DeviceId = d.DeviceId,
                                   DeviceCode = d.DeviceCode,
                                   DeviceDescription = d.DeviceDescription
                               }).FirstOrDefault();
                if (devInfo == null)
                {
                    return null;
                }
                result = new DesktopAppModel();
                result.CompanyId = companyInfo.CompanyId;
                result.CompanyName = companyInfo.CompanyName;
                result.LocationId = locInfo.LocationId;
                result.LocationName = locInfo.LocationName;
                result.DeviceCode = devInfo.DeviceCode;
                result.DeviceId = devInfo.DeviceId;
                result.DeviceDescription = devInfo.DeviceDescription;

                var di = ctx.Devices.Where(c => c.DeviceId == devInfo.DeviceId).FirstOrDefault();
                if(di != null)
                {
                    di.IsUsed = true;
                    ctx.SaveChanges();
                }

            }
            return result;
        }
        public List<EmployeeViewModel> GetAllEmployeesByCompanyId(int companyId, string employeeType = "")
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var isOnlyActive = false;
                if (employeeType == "Only Active")
                {
                    isOnlyActive = true;
                }
                if (companyId > 0)
                {


                    return (from e in ctx.Employees
                            join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                            join l in ctx.Locations on el.LocationId equals l.LocationId
                            join cl in ctx.CompanyLocations on l.LocationId equals cl.LocationId
                            where cl.CompanyId == companyId &&
                            (isOnlyActive == false || e.Active == true)
                            select new EmployeeViewModel()
                            {
                                EmployeeId = e.EmployeeId,
                                EmployeePin = e.EmployeePin,
                                EmployeeName = e.EmployeeName,
                                EmployeeEmail = e.EmployeeEmail,
                                EmployeePhone = e.EmployeePhone,
                                EmployeeLastFour = e.EmployeeLastFour,
                                EmployeeEmploymentTypeId = e.EmployeeEmploymentTypeId,
                                //EmployeeEmploymentTypeName = et.EmploymentTypeName,
                                EmployeeIsHourly = e.EmployeeIsHourly,
                                EmployeeRate = e.EmployeeRate,
                                EmployeeBirthDate = e.EmployeeBirthDate,
                                EmployeeHireDate = e.EmployeeHireDate,
                                EmployeeLeftDate = e.EmployeeLeftDate,
                                EmployeeAddress1 = e.EmployeeAddress1,
                                EmployeeAddress2 = e.EmployeeAddress2,
                                EmployeeCity = e.EmployeeCity,
                                EmployeeState = e.EmployeeState,
                                EmployeeZip = e.EmployeeZip,
                                EmployeeCountry = e.EmployeeCountry,
                                LocationId = el.LocationId,
                                CompanyId = cl.CompanyId,
                                CreateDate = DateTime.Now,
                                Active = e.Active
                            }).ToList();
                }
                else
                {
                    return (from e in ctx.Employees
                            join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                            join l in ctx.Locations on el.LocationId equals l.LocationId
                            join cl in ctx.CompanyLocations on l.LocationId equals cl.LocationId
                            where isOnlyActive == false || e.Active == true
                            select new EmployeeViewModel()
                            {
                                EmployeeId = e.EmployeeId,
                                EmployeePin = e.EmployeePin,
                                EmployeeName = e.EmployeeName,
                                EmployeeEmail = e.EmployeeEmail,
                                EmployeePhone = e.EmployeePhone,
                                EmployeeLastFour = e.EmployeeLastFour,
                                EmployeeEmploymentTypeId = e.EmployeeEmploymentTypeId,
                                //EmployeeEmploymentTypeName = et.EmploymentTypeName,
                                EmployeeIsHourly = e.EmployeeIsHourly,
                                EmployeeRate = e.EmployeeRate,
                                EmployeeBirthDate = e.EmployeeBirthDate,
                                EmployeeHireDate = e.EmployeeHireDate,
                                EmployeeLeftDate = e.EmployeeLeftDate,
                                EmployeeAddress1 = e.EmployeeAddress1,
                                EmployeeAddress2 = e.EmployeeAddress2,
                                EmployeeCity = e.EmployeeCity,
                                EmployeeState = e.EmployeeState,
                                EmployeeZip = e.EmployeeZip,
                                EmployeeCountry = e.EmployeeCountry,
                                LocationId = el.LocationId,
                                CompanyId = cl.CompanyId,
                                CreateDate = DateTime.Now,
                                Active = e.Active
                            }).ToList();
                }

            }
            return null;
        }
        public List<EmployeeViewModel> GetAllEmployees()
        {
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    return (from e in ctx.Employees
                            join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                            join l in ctx.Locations on el.LocationId equals l.LocationId
                            join cl in ctx.CompanyLocations on l.LocationId equals cl.LocationId
                            select new EmployeeViewModel()
                            {
                                EmployeeId = e.EmployeeId,
                                LocationId = l.LocationId,
                                LocationName = l.LocationName,
                                EmployeePin = e.EmployeePin,
                                EmployeeName = e.EmployeeName,
                                EmployeeEmail = e.EmployeeEmail,
                                EmployeePhone = e.EmployeePhone,
                                EmployeeLastFour = e.EmployeeLastFour,
                                EmployeeEmploymentTypeId = e.EmployeeEmploymentTypeId,
                                //EmployeeEmploymentTypeName = et.EmploymentTypeName,
                                EmployeeIsHourly = e.EmployeeIsHourly,
                                EmployeeRate = e.EmployeeRate,
                                EmployeeBirthDate = e.EmployeeBirthDate,
                                EmployeeHireDate = e.EmployeeHireDate,
                                EmployeeLeftDate = e.EmployeeLeftDate,
                                EmployeeAddress1 = e.EmployeeAddress1,
                                EmployeeAddress2 = e.EmployeeAddress2,
                                EmployeeCity = e.EmployeeCity,
                                EmployeeState = e.EmployeeState,
                                EmployeeZip = e.EmployeeZip,
                                EmployeeCountry = e.EmployeeCountry,
                                CreateDate = DateTime.Now,
                                Active = e.Active
                            }).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        public List<EmployeeViewModel> GetAllEmployeesByLocationId(int locationId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Employees
                        join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                        join l in ctx.Locations on el.LocationId equals l.LocationId
                        where l.LocationId == locationId
                        select new EmployeeViewModel()
                        {
                            EmployeeId = e.EmployeeId,
                            EmployeePin = e.EmployeePin,
                            EmployeeName = e.EmployeeName,
                            EmployeeEmail = e.EmployeeEmail,
                            EmployeePhone = e.EmployeePhone,
                            EmployeeLastFour = e.EmployeeLastFour,
                            EmployeeEmploymentTypeId = e.EmployeeEmploymentTypeId,
                            //EmployeeEmploymentTypeName = et.EmploymentTypeName,
                            EmployeeIsHourly = e.EmployeeIsHourly,
                            EmployeeRate = e.EmployeeRate,
                            EmployeeBirthDate = e.EmployeeBirthDate,
                            EmployeeHireDate = e.EmployeeHireDate,
                            EmployeeLeftDate = e.EmployeeLeftDate,
                            EmployeeAddress1 = e.EmployeeAddress1,
                            EmployeeAddress2 = e.EmployeeAddress2,
                            EmployeeCity = e.EmployeeCity,
                            EmployeeState = e.EmployeeState,
                            EmployeeZip = e.EmployeeZip,
                            EmployeeCountry = e.EmployeeCountry,
                            CreateDate = DateTime.Now,
                            Active = e.Active
                        }).ToList();
            }
            return null;
        }
        public EmployeeViewModel GetEmployeesByEmployeeId(int employeeId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Employees
                        join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                        join l in ctx.Locations on el.LocationId equals l.LocationId
                        join cl in ctx.CompanyLocations on l.LocationId equals cl.LocationId
                        join c in ctx.Companies on cl.CompanyId equals c.CompanyId
                        where e.EmployeeId == employeeId
                        select new EmployeeViewModel()
                        {
                            EmployeeId = e.EmployeeId,
                            EmployeePin = e.EmployeePin,
                            CompanyId = c.CompanyId,
                            CompanyName = c.CompanyName,
                            LocationId = l.LocationId,
                            LocationName = l.LocationName,
                            EmployeeName = e.EmployeeName,
                            EmployeeEmail = e.EmployeeEmail,
                            EmployeePhone = e.EmployeePhone,
                            EmployeeLastFour = e.EmployeeLastFour,
                            EmployeeEmploymentTypeId = e.EmployeeEmploymentTypeId,
                            //EmployeeEmploymentTypeName = et.EmploymentTypeName,
                            EmployeeIsHourly = e.EmployeeIsHourly,
                            EmployeeRate = e.EmployeeRate,
                            EmployeeBirthDate = e.EmployeeBirthDate,
                            EmployeeHireDate = e.EmployeeHireDate,
                            EmployeeLeftDate = e.EmployeeLeftDate,
                            EmployeeAddress1 = e.EmployeeAddress1,
                            EmployeeAddress2 = e.EmployeeAddress2,
                            EmployeeCity = e.EmployeeCity,
                            EmployeeState = e.EmployeeState,
                            EmployeeZip = e.EmployeeZip,
                            EmployeeCountry = e.EmployeeCountry,
                            CreateDate = DateTime.Now,
                            Active = e.Active
                        }).FirstOrDefault();
            }
            return null;
        }
        public List<LocationViewModel> GetAllLocationsByCompanyId(int companyId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Locations
                        join c in ctx.CompanyLocations on e.LocationId equals c.LocationId
                        join cn in ctx.Companies on c.CompanyId equals cn.CompanyId
                        where c.CompanyId == companyId
                        select new LocationViewModel()
                        {
                            LocationId = e.LocationId,
                            LocationName = e.LocationName,
                            LocationDescription = e.LocationDescription,
                            LocationPhone = e.LocationPhone,
                            LocationEmail = e.LocationEmail,
                            LocationAddress1 = e.LocationAddress1,
                            LocationAddress2 = e.LocationAddress2,
                            LocationCity = e.LocationCity,
                            LocationState = e.LocationState,
                            LocationZip = e.LocationZip,
                            LocationCountry = e.LocationCountry,
                            CreateDate = DateTime.Now,
                            CompanyId = c.CompanyId,
                            CompanyName = cn.CompanyName,
                            Active = e.Active,
                        }).ToList();
            }
            return null;
        }
        public LocationViewModel GetLocationsByLocationId(int locationId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Locations
                        join cl in ctx.CompanyLocations on e.LocationId equals cl.LocationId
                        join c in ctx.Companies on cl.CompanyId equals c.CompanyId
                        where e.LocationId == locationId
                        select new LocationViewModel()
                        {
                            LocationId = e.LocationId,
                            LocationName = e.LocationName,
                            CompanyId = c.CompanyId,
                            CompanyName = c.CompanyName,
                            LocationDescription = e.LocationDescription,
                            LocationPhone = e.LocationPhone,
                            LocationEmail = e.LocationEmail,
                            LocationAddress1 = e.LocationAddress1,
                            LocationAddress2 = e.LocationAddress2,
                            LocationCity = e.LocationCity,
                            LocationState = e.LocationState,
                            LocationZip = e.LocationZip,
                            LocationCountry = e.LocationCountry,
                            CreateDate = DateTime.Now,
                            Active = e.Active,
                        }).FirstOrDefault();
            }
            return null;
        }
        public List<LocationViewModel> GetAllLocations()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Locations
                        join cl in ctx.CompanyLocations on e.LocationId equals cl.LocationId
                        join c in ctx.Companies on cl.CompanyId equals c.CompanyId
                        select new LocationViewModel()
                        {
                            LocationId = e.LocationId,
                            LocationName = e.LocationName,
                            CompanyId = c.CompanyId,
                            CompanyName = c.CompanyName,
                            LocationDescription = e.LocationDescription,
                            LocationPhone = e.LocationPhone,
                            LocationEmail = e.LocationEmail,
                            LocationAddress1 = e.LocationAddress1,
                            LocationAddress2 = e.LocationAddress2,
                            LocationCity = e.LocationCity,
                            LocationState = e.LocationState,
                            LocationZip = e.LocationZip,
                            LocationCountry = e.LocationCountry,
                            CreateDate = DateTime.Now,
                            Active = e.Active,
                        }).ToList();
            }
            return null;
        }
        public List<RoleViewModel> GetAllRoles()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Roles
                        where e.Active == true && e.RoleDescription != "System Admin"
                        select new RoleViewModel()
                        {
                            RoleId = e.RoleId,
                            RoleDescription = e.RoleDescription,
                            CreateDate = DateTime.Now,
                            Active = e.Active,
                        }).ToList();
            }
            return null;
        }

        public bool GetValidEmail(string Email)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = ctx.AspNetUsers.Where(c => c.Email == Email).FirstOrDefault();
                if (item == null)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetEmail(string UserId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = ctx.AspNetUsers.Where(c => c.Id == UserId).FirstOrDefault();
                if (item != null)
                {
                    return item.Email;
                }
            }
            return string.Empty;
        }
        public UserViewModel GetUserInfo(string UserId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = (from a in ctx.AspNetUsers
                            join u in ctx.Users on a.Id equals u.UserAspNetId
                            join ur in ctx.UserInRoles on a.Id equals ur.UserId
                            join r in ctx.Roles on ur.RoleId equals r.RoleId
                            where a.Id == UserId
                            select new UserViewModel()
                            {
                                Id = a.Id,
                                RoleId = r.RoleId,
                                RoleName = r.RoleDescription,
                                UserName = a.UserName,
                                UserFullName = u.UserFullName,
                                Email = a.Email,
                                UserPhone = a.PhoneNumber,
                                UserAddress1 = u.UserAddress1,
                                UserCity = u.UserCity,
                                UserState = u.UserState,
                                UserZip = u.UserZip,
                                UserCountry = u.UserCountry,
                                Active = u.Active
                            }).FirstOrDefault();
                return item;

            }
            return null;
        }
        public List<UserViewModel> GetUserInfoForCompany(int CompanyId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = (from a in ctx.AspNetUsers
                            join u in ctx.Users on a.Id equals u.UserAspNetId
                            join c in ctx.CompanyUsers on a.Id equals c.UserId
                            join ur in ctx.UserInRoles on a.Id equals ur.UserId
                            join r in ctx.Roles on ur.RoleId equals r.RoleId
                            where c.CompanyId == CompanyId
                            select new UserViewModel()
                            {
                                Id = a.Id,
                                RoleId = r.RoleId,
                                RoleName = r.RoleDescription,
                                UserName = a.UserName,
                                UserFullName = u.UserFullName,
                                Email = a.Email,
                                UserPhone = a.PhoneNumber,
                                UserAddress1 = u.UserAddress1,
                                UserCity = u.UserCity,
                                UserState = u.UserState,
                                UserZip = u.UserZip,
                                UserCountry = u.UserCountry,
                                Active = u.Active
                            }).ToList();
                return item;

            }
            return null;
        }
        public string GetUserId(string UserEmail)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = ctx.AspNetUsers.Where(c => c.Email == UserEmail).FirstOrDefault();
                if (item != null)
                {
                    return item.Id;
                }
            }
            return string.Empty;
        }
        public List<CompanyViewModel> GetAllCompanies()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Companies
                        select new CompanyViewModel()
                        {
                            CompanyId = e.CompanyId,
                            CompanyName = e.CompanyName,
                            CompanyDescription = e.CompanyDescription,
                            CompanyPhone = e.CompanyPhone,
                            CompanyEmail = e.CompanyEmail,
                            CompanyWebsite = e.CompanyWebsite,
                            CompanyAddress1 = e.CompanyAddress1,
                            CompanyAddress2 = e.CompanyAddress2,
                            CompanyCity = e.CompanyCity,
                            CompanyState = e.CompanyState,
                            CompanyZip = e.CompanyZip,
                            CompanyCountry = e.CompanyCountry,
                            CompanyLogo = e.CompanyLogo,
                            CompanyAdminId = e.CompanyAdminId,
                            CompanyNumberOfUsers = e.CompanyNumberOfUsers,
                            CompanyNumberOfLocation = e.CompanyNumberOfLocation,
                            CreateDate = DateTime.Now,
                            Active = e.Active
                        }).ToList();
            }
            return null;
        }
        public CompanyViewModel GetCompanyByUserId(string userId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Companies
                        join cu in ctx.CompanyUsers on e.CompanyId equals cu.CompanyId
                        join ur in ctx.UserInRoles on cu.UserId equals ur.UserId
                        where ur.UserId == userId
                        select new CompanyViewModel()
                        {
                            CompanyId = e.CompanyId,
                            CompanyName = e.CompanyName,
                            CompanyDescription = e.CompanyDescription,
                            CompanyPhone = e.CompanyPhone,
                            CompanyEmail = e.CompanyEmail,
                            CompanyWebsite = e.CompanyWebsite,
                            CompanyAddress1 = e.CompanyAddress1,
                            CompanyAddress2 = e.CompanyAddress2,
                            CompanyCity = e.CompanyCity,
                            CompanyState = e.CompanyState,
                            CompanyZip = e.CompanyZip,
                            CompanyCountry = e.CompanyCountry,
                            CompanyLogo = e.CompanyLogo,
                            CompanyAdminId = e.CompanyAdminId,
                            CompanyNumberOfUsers = e.CompanyNumberOfUsers,
                            CompanyNumberOfLocation = e.CompanyNumberOfLocation,
                            CreateDate = DateTime.Now,
                            Active = e.Active
                        }).FirstOrDefault();
            }
            return null;
        }
        public bool IsValidCompanyForUser(string userId, int companyId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = (from e in ctx.Companies
                            join cu in ctx.CompanyUsers on e.CompanyId equals cu.CompanyId
                            join ur in ctx.UserInRoles on cu.UserId equals ur.UserId
                            where ur.UserId == userId && e.CompanyId == companyId
                            select new CompanyViewModel()
                            {
                                CompanyId = e.CompanyId,
                                Active = e.Active
                            }).FirstOrDefault();
                if (item != null && item.Active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false; ;
        }

        public bool IsValidCompanyForEmployee(int employeeId, int companyId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
               var item = (from e in ctx.Employees
                            join el in ctx.EmployeeLocations on e.EmployeeId equals el.EmployeeId
                            join l in ctx.Locations on el.LocationId equals l.LocationId
                            join cl in ctx.CompanyLocations on l.LocationId equals cl.LocationId
                            join c in ctx.Companies on cl.CompanyId equals c.CompanyId
                            where e.EmployeeId == employeeId && c.CompanyId == companyId
                            //&& e.Active == true && c.Active == true
                            select new EmployeeViewModel()
                            {
                                EmployeeId = e.EmployeeId,
                                Active = e.Active
                            }).FirstOrDefault();
                if (item != null && item.Active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false; ;
        }
        public bool IsValidLocationForUser(string userId, int companyId, int locationId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = (from l in ctx.Locations
                            join c in ctx.CompanyLocations on l.LocationId equals c.LocationId
                            join cu in ctx.CompanyUsers on c.CompanyId equals cu.CompanyId
                            join ur in ctx.UserInRoles on cu.UserId equals ur.UserId
                            where ur.UserId == userId && c.CompanyId == companyId
                            && l.LocationId == locationId
                            select new LocationViewModel()
                            {
                                CompanyId = c.CompanyId,
                                Active = l.Active
                            }).FirstOrDefault();
                if (item != null && item.Active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false; ;
        }
        public CompanyViewModel GetCompanyByCompanyId(int companyId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Companies
                        where e.CompanyId == companyId
                        select new CompanyViewModel()
                        {
                            CompanyId = e.CompanyId,
                            CompanyName = e.CompanyName,
                            CompanyDescription = e.CompanyDescription,
                            CompanyPhone = e.CompanyPhone,
                            CompanyEmail = e.CompanyEmail,
                            CompanyWebsite = e.CompanyWebsite,
                            CompanyAddress1 = e.CompanyAddress1,
                            CompanyAddress2 = e.CompanyAddress2,
                            CompanyCity = e.CompanyCity,
                            CompanyState = e.CompanyState,
                            CompanyZip = e.CompanyZip,
                            CompanyCountry = e.CompanyCountry,
                            CompanyLogo = e.CompanyLogo,
                            CompanyAdminId = e.CompanyAdminId,
                            CompanyNumberOfUsers = e.CompanyNumberOfUsers,
                            CompanyNumberOfLocation = e.CompanyNumberOfLocation,
                            CreateDate = DateTime.Now,
                            Active = e.Active
                        }).FirstOrDefault();
            }
            return null;
        }
        public List<EmploymentTypeViewModel> GetEmploymentTypeViewModels()
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.EmploymentTypes
                        select new EmploymentTypeViewModel()
                        {
                            EmploymentTypeId = e.EmploymentTypeId,
                            EmploymentTypeName = e.EmploymentTypeName,
                            CreateDate = DateTime.Now,
                            Active = e.Active
                        }).ToList();
            }
            return null;
        }
        public UserViewModel GetUserInfoByUserId(string userId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.AspNetUsers
                        join u in ctx.Users on e.Id equals u.UserAspNetId
                        join ur in ctx.UserInRoles on e.Id equals ur.UserId
                        join r in ctx.Roles on ur.RoleId equals r.RoleId
                        where ur.UserId == userId
                        select new UserViewModel()
                        {
                            Id = e.Id,
                            Email = e.Email,
                            PhoneNumber = e.PhoneNumber,
                            LockoutEndDateUtc = e.LockoutEndDateUtc,
                            UserName = e.UserName,
                            RoleName = r.RoleDescription,
                            RoleId = ur.RoleId,
                            UserId = u.UserId,
                            UserFullName = u.UserFullName,
                            UserPhone = u.UserPhone,
                            UserAddress1 = u.UserAddress1,
                            UserAddress2 = u.UserAddress2,
                            UserCity = u.UserCity,
                            UserState = u.UserState,
                            UserZip = u.UserZip,
                            UserCountry = u.UserCountry,
                            CreateDate = u.CreateDate

                        }).FirstOrDefault();
            }
            return null;
        }
        public UserViewModel GetUserInfoByUsername(string userName)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.AspNetUsers
                        join u in ctx.Users on e.Id equals u.UserAspNetId
                        join ur in ctx.UserInRoles on e.Id equals ur.UserId
                        join r in ctx.Roles on ur.RoleId equals r.RoleId
                        where e.UserName == userName
                        select new UserViewModel()
                        {
                            Id = e.Id,
                            Email = e.Email,
                            PhoneNumber = e.PhoneNumber,
                            LockoutEndDateUtc = e.LockoutEndDateUtc,
                            UserName = e.UserName,
                            RoleName = r.RoleDescription,
                            RoleId = ur.RoleId,
                            UserId = u.UserId,
                            UserFullName = u.UserFullName,
                            UserPhone = u.UserPhone,
                            UserAddress1 = u.UserAddress1,
                            UserAddress2 = u.UserAddress2,
                            UserCity = u.UserCity,
                            UserState = u.UserState,
                            UserZip = u.UserZip,
                            UserCountry = u.UserCountry,
                            CreateDate = u.CreateDate,
                            Active = u.Active
                        }).FirstOrDefault();
            }
            return null;
        }
        public int SaveCompany(CompanyViewModel value)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = value;
                var currentCompany = ctx.Companies.Where(c => c.CompanyId == e.CompanyId).FirstOrDefault();
                var company = new Company();
                var isNewCompany = false;
                if (currentCompany != null)
                {
                    company = currentCompany;
                    isNewCompany = false;
                }
                else
                {
                    isNewCompany = true;
                }
                company.CompanyName = e.CompanyName;
                company.CompanyDescription = e.CompanyDescription;
                company.CompanyPhone = e.CompanyPhone;
                company.CompanyEmail = e.CompanyEmail;
                company.CompanyWebsite = e.CompanyWebsite;
                company.CompanyAddress1 = e.CompanyAddress1;
                company.CompanyAddress2 = e.CompanyAddress2;
                company.CompanyCity = e.CompanyCity;
                company.CompanyState = e.CompanyState;
                company.CompanyZip = e.CompanyZip;
                company.CompanyCountry = e.CompanyCountry;
                company.CompanyLogo = e.CompanyLogo;
                company.CompanyAdminId = e.CompanyAdminId;
                company.CompanyNumberOfUsers = e.CompanyNumberOfUsers;
                company.CompanyNumberOfLocation = e.CompanyNumberOfLocation;
                company.CreateDate = DateTime.Now;
                company.Active = e.Active;
                if (isNewCompany)
                    ctx.Companies.Add(company);
                ctx.SaveChanges();
                return company.CompanyId;
            }
            return 0;
        }
        public int SaveLocation(LocationViewModel value)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = value;
                var currentLocation = ctx.Locations.Where(c => c.LocationId == e.LocationId).FirstOrDefault();
                var location = new Location();
                var isNewLocation = false;
                if (currentLocation != null)
                {
                    location = currentLocation;
                    isNewLocation = false;
                }
                else
                {
                    isNewLocation = true;
                    location.LocationNumberOfDevice = 1;
                }
                location.LocationId = e.LocationId;
                location.LocationName = e.LocationName;
                location.LocationDescription = e.LocationDescription;
                location.LocationPhone = e.LocationPhone;
                location.LocationEmail = e.LocationEmail;
                location.LocationAddress1 = e.LocationAddress1;
                location.LocationAddress2 = e.LocationAddress2;
                location.LocationCity = e.LocationCity;
                location.LocationState = e.LocationState;
                location.LocationZip = e.LocationZip;
                location.LocationCountry = e.LocationCountry;
                location.CreateDate = DateTime.Now;
                location.Active = e.Active;
                if (isNewLocation)
                    ctx.Locations.Add(location);
                ctx.SaveChanges();

                if (isNewLocation)
                {
                    var companyLocation = new CompanyLocation();
                    companyLocation.LocationId = location.LocationId;
                    companyLocation.CompanyId = value.CompanyId;
                    companyLocation.CreateDate = DateTime.Now;
                    companyLocation.Active = true;
                    ctx.CompanyLocations.Add(companyLocation);
                    ctx.SaveChanges();

                    SaveDevice(location.LocationId, "System Generated");
                }
                return location.LocationId;
            }
            return 0;
        }
        public int SaveEmployee(EmployeeViewModel value)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var e = value;
                var currentEmployee = ctx.Employees.Where(c => c.EmployeeId == e.EmployeeId).FirstOrDefault();
                var employee = new Employee();
                var isNewEmployee = false;
                if (currentEmployee != null)
                {
                    employee = currentEmployee;
                    isNewEmployee = false;
                }
                else
                {
                    isNewEmployee = true;
                }
                employee.EmployeeId = e.EmployeeId;
                employee.EmployeePin = e.EmployeePin;
                employee.EmployeeName = e.EmployeeName;
                employee.EmployeeEmail = e.EmployeeEmail;
                employee.EmployeePhone = e.EmployeePhone;
                employee.EmployeeLastFour = e.EmployeeLastFour;
                employee.EmployeeEmploymentTypeId = e.EmployeeEmploymentTypeId;
                employee.EmployeeIsHourly = e.EmployeeIsHourly;
                employee.EmployeeRate = e.EmployeeRate;
                employee.EmployeeBirthDate = e.EmployeeBirthDate;
                employee.EmployeeHireDate = e.EmployeeHireDate;
                employee.EmployeeLeftDate = e.EmployeeLeftDate;
                employee.EmployeeAddress1 = e.EmployeeAddress1;
                employee.EmployeeAddress2 = e.EmployeeAddress2;
                employee.EmployeeCity = e.EmployeeCity;
                employee.EmployeeState = e.EmployeeState;
                employee.EmployeeZip = e.EmployeeZip;
                employee.EmployeeCountry = e.EmployeeCountry;
                employee.CreateDate = DateTime.Now;
                employee.Active = e.Active;
                if (isNewEmployee)
                    ctx.Employees.Add(employee);
                ctx.SaveChanges();

                if (isNewEmployee)
                {
                    var employeeLocation = new EmployeeLocation();
                    employeeLocation.EmployeeId = employee.EmployeeId;
                    employeeLocation.LocationId = value.LocationId;
                    employeeLocation.CreateDate = DateTime.Now;
                    employeeLocation.Active = true;
                    ctx.EmployeeLocations.Add(employeeLocation);
                    ctx.SaveChanges();
                }
                return employee.EmployeeId;
            }
            return 0;
        }
        public bool IsEmployeeExist(int employeeId, int employeePin)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var employee = ctx.Employees.Where(c => c.EmployeeId == employeeId && c.EmployeePin == employeePin && c.Active == true).FirstOrDefault();
                if (employee != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public string GenerateDeviceCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[30];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public string SaveEmployeeTimeCard(EmployeeTimeCardViewModel value, string userId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {

                var deviceCode = "";
                var dev = GetAllDevice(value.LocationId);
                if (dev == null || dev.Count == 0)
                {
                    var device = new Device();
                    device.LocationId = value.LocationId;
                    device.DeviceDescription = "System Generated";
                    device.DeviceCode = GenerateDeviceCode();
                    device.Active = true;
                    device.IsUsed = false;
                    device.CreateDate = DateTime.Now;
                    ctx.Devices.Add(device);
                    ctx.SaveChanges();
                    deviceCode = device.DeviceCode;
                }
                else
                {
                    deviceCode = dev[0].DeviceCode;
                }

                var e = value;
                var currentCard = ctx.EmployeeTimeCards.Where(c => c.EmployeeTimeCardId == e.EmployeeTimeCardId).FirstOrDefault();
                var card = new EmployeeTimeCard();
                var isNewCard = false;
                if (currentCard != null)
                {
                    card = currentCard;
                    isNewCard = false;
                    //save history
                    var hcard = new EmployeeTimeCardHistory();
                    hcard.EmployeeTimeCardId = card.EmployeeTimeCardId;
                    hcard.EmployeeId = card.EmployeeId;
                    hcard.LocationId = card.LocationId;
                    hcard.LocationIp = card.LocationIp;
                    hcard.TimeIn = card.TimeIn;
                    hcard.TimeInUtc = card.TimeInUtc;
                    hcard.TimeOutUtc = card.TimeOutUtc;
                    hcard.TimeCardCreateDate = card.CreateDate;
                    hcard.TimeOut = card.TimeOut;
                    hcard.DeviceCode = deviceCode;
                    hcard.DeviceCodeOut = deviceCode;
                    hcard.CreateDate = DateTime.Now;
                    hcard.Reason = e.Reason;
                    hcard.Action = "U";
                    hcard.UpdateUser = userId;
                    ctx.EmployeeTimeCardHistories.Add(hcard);
                    ctx.SaveChanges();
                }
                else
                {
                    isNewCard = true;

                }
                card.EmployeeId = e.EmployeeId;
                card.LocationId = e.LocationId;
                card.LocationIp = e.LocationIp;
                card.TimeIn = DateTime.Parse(e.TimeInUIString);
                if (e.TimeIn != null)
                    card.TimeInUtc = e.TimeIn.Value.ToUniversalTime();
                if (e.TimeOut != null)
                    card.TimeOutUtc = e.TimeOut.Value.ToUniversalTime();
                card.TimeOut = DateTime.Parse(e.TimeOutUIString);
                card.DeviceCode = deviceCode;
                card.DeviceCodeOut = deviceCode;
                card.CreateDate = DateTime.Now;

                if (isNewCard)
                    ctx.EmployeeTimeCards.Add(card);
                ctx.SaveChanges();
                if (card.EmployeeTimeCardId > 0)
                {
                    if (isNewCard)
                    {
                        var hcard = new EmployeeTimeCardHistory();
                        hcard.EmployeeTimeCardId = card.EmployeeTimeCardId;
                        hcard.EmployeeId = card.EmployeeId;
                        hcard.LocationId = card.LocationId;
                        hcard.LocationIp = card.LocationIp;
                        hcard.TimeIn = card.TimeIn;
                        hcard.TimeInUtc = card.TimeInUtc;
                        hcard.TimeOutUtc = card.TimeOutUtc;
                        hcard.TimeOut = card.TimeOut;
                        hcard.DeviceCode = card.DeviceCode;
                        hcard.DeviceCodeOut = card.DeviceCodeOut;
                        hcard.TimeCardCreateDate = card.CreateDate;
                        hcard.CreateDate = DateTime.Now;
                        hcard.Reason = e.Reason;
                        hcard.Action = "I";
                        hcard.UpdateUser = userId;
                        ctx.EmployeeTimeCardHistories.Add(hcard);
                        ctx.SaveChanges();
                    }
                    return "Success";
                }
            }
            return "There was an error while processing your request.";
        }
        public string SaveDevice(int LocationId, string DeviceDescription)
        {
            var result = string.Empty;
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    var device = new Device();
                    device.LocationId = LocationId;
                    device.DeviceDescription = DeviceDescription;
                    device.DeviceCode = GenerateDeviceCode();
                    device.Active = true;
                    device.IsUsed = false;
                    device.CreateDate = DateTime.Now;
                    ctx.Devices.Add(device);
                    ctx.SaveChanges();
                    if (device.DeviceId > 0)
                    {
                        return "Device was added successfully";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<DeviceViewModel> GetDevices(int companyId)
        {
            var result = new List<DeviceViewModel>();
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    result = (from c in ctx.Companies
                              join cl in ctx.CompanyLocations on c.CompanyId equals cl.CompanyId
                              join d in ctx.Devices on cl.LocationId equals d.LocationId
                              where c.CompanyId == companyId
                              select new DeviceViewModel()
                              {
                                  DeviceCode = d.DeviceCode,
                                  DeviceDescription = d.DeviceDescription,
                                  DeviceId = d.DeviceId,
                                  CreateDate = d.CreateDate,
                                  LocationId = d.LocationId,
                                  Active = d.Active
                              }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public List<EmployeeViewModel> GetEmployeesTime(DateTime startTime, DateTime endDate, int companyId, int locationId, string employeeType)
        {
            var result = new List<EmployeeViewModel>();
            try
            {

                result = GetAllEmployeesByCompanyId(companyId, employeeType);

                //if (locationId > 0)
                //{
                //    result = result.Where(c => c.LocationId == locationId).ToList();
                //}

                if (result.Count > 0)
                {
                    for (var i = 0; i < result.Count; i++)
                    {
                        var item = result[i];
                        var empTimeForPeriod = GetEmployeeTime(item.EmployeeId, startTime, endDate);
                        if (locationId > 0)
                        {
                            empTimeForPeriod = empTimeForPeriod.Where(c => c.LocationId == locationId).ToList();
                        }
                        if (empTimeForPeriod != null && empTimeForPeriod.Count > 0)
                        {
                            result[i].Hours = empTimeForPeriod.Select(c => c.Hours).Sum();
                            if (result[i].Hours > 0)
                            {
                                result[i].Hours =  Math.Round(result[i].Hours, 2);
                            }
                        }
                    }
                    
                    if(result != null && result.Count > 0)
                    {
                        if (locationId > 0)
                        {
                            result = result.Where(c => c.Hours > 0).ToList();
                        }
                        result = result.OrderBy(c => c.EmployeeName).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }
        public List<EmployeeTimeCardViewModel> GetEmployeeTime(int employeeId, DateTime startTime, DateTime endDate)
        {
            var result = new List<EmployeeTimeCardViewModel>();
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    var readers = (from e in ctx.EmployeeTimeCards
                                   join l in ctx.Locations on e.LocationId equals l.LocationId
                                   join d in ctx.Devices on e.DeviceCode equals d.DeviceCode into edd
                                   from ed in edd.DefaultIfEmpty()
                                   join o in ctx.Devices on e.DeviceCodeOut equals o.DeviceCode into eoo
                                   from eo in eoo.DefaultIfEmpty()
                                   where e.EmployeeId == employeeId
                                   && e.TimeIn > startTime
                                   && e.TimeIn < endDate
                                   && (e.TimeOut == null || e.TimeOut < endDate)
                                   select new EmployeeTimeCardViewModel()
                                   {

                                       CreateDate = e.CreateDate,
                                       EmployeeTimeCardId = e.EmployeeTimeCardId,
                                       EmployeeId = e.EmployeeId,
                                       TimeIn = e.TimeIn,
                                       TimeOut = e.TimeOut,
                                       LocationId = l.LocationId,
                                       DeviceId = ed.DeviceId,
                                       DeviceIdOut = eo.DeviceId,
                                       TimeInUtc = e.TimeInUtc,
                                       TimeOutUtc = e.TimeOutUtc
                                   }).ToList();

                    return readers;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }
        public string DeleteTimeCard(int timeCardId, string userId, string reason)
        {
            var result = string.Empty;
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    var e = ctx.EmployeeTimeCards.Where(c => c.EmployeeTimeCardId == timeCardId).FirstOrDefault();
                    if (e != null)
                    {
                        var card = new EmployeeTimeCardHistory();
                        card.EmployeeTimeCardId = e.EmployeeTimeCardId;
                        card.EmployeeId = e.EmployeeId;
                        card.LocationId = e.LocationId;
                        card.LocationIp = e.LocationIp;
                        card.TimeIn = e.TimeIn;
                        card.TimeInUtc = e.TimeInUtc;
                        card.TimeOutUtc = e.TimeOutUtc;
                        card.TimeOut = e.TimeOut;
                        card.DeviceCode = e.DeviceCode;
                        card.DeviceCodeOut = e.DeviceCode;
                        card.CreateDate = DateTime.Now;
                        card.TimeCardCreateDate = e.CreateDate;
                        card.Reason = reason;
                        card.Action = "D";
                        card.UpdateUser = userId;
                        ctx.EmployeeTimeCardHistories.Add(card);
                        ctx.SaveChanges();

                        ctx.EmployeeTimeCards.Remove(e);
                        ctx.SaveChanges();
                        return "Success";

                    }
                }
            }
            catch (Exception ex)
            {
                return "Error :" + ex.Message;
            }
            return "";
        }


        public EmployeeTimeCardViewModel GetEmployeeTimeCard(int employeeCardId)
        {
            var result = new List<EmployeeTimeCardViewModel>();
            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    var readers = (from e in ctx.EmployeeTimeCards
                                   join l in ctx.Locations on e.LocationId equals l.LocationId
                                   join d in ctx.Devices on e.DeviceCode equals d.DeviceCode
                                   where e.EmployeeTimeCardId == employeeCardId
                                   select new EmployeeTimeCardViewModel()
                                   {

                                       CreateDate = e.CreateDate,
                                       EmployeeTimeCardId = e.EmployeeTimeCardId,
                                       EmployeeId = e.EmployeeId,
                                       TimeIn = e.TimeIn,
                                       TimeOut = e.TimeOut,
                                       LocationId = l.LocationId,
                                       DeviceId = d.DeviceId
                                   }).FirstOrDefault();

                    return readers;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return null;
        }
        public string IslastTimeOut(int employeeId, int employeePin)
        {
            var result = string.Empty;
            try
            {
                if (IsEmployeeExist(employeeId, employeePin))
                {
                    using (var ctx = new DB_132062_workbyclockEntities1())
                    {
                        var item = ctx.EmployeeTimeCards.Where(c => c.EmployeeId == employeeId).OrderByDescending(c => c.CreateDate).FirstOrDefault();
                        if (item != null && item.TimeOut == null && item.TimeIn != null)
                        {
                            result = "You have not Clocked Out from last time. \n Please Clock Out first to Clock In.";
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }
        public string IslastTimeIn(int employeeId, int employeePin)
        {
            var result = string.Empty;
            try
            {

                if (IsEmployeeExist(employeeId, employeePin))
                {
                    using (var ctx = new DB_132062_workbyclockEntities1())
                    {
                        var item = ctx.EmployeeTimeCards.Where(c => c.EmployeeId == employeeId).OrderByDescending(c => c.CreateDate).FirstOrDefault();
                        if (item != null && item.TimeOut != null && item.TimeIn != null)
                        {
                            result = "You never Clocked In. \n Please Clock In first to Clock Out.";
                        }
                    }
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }
        public int GetlastTimeInId(int employeeId, int employeePin)
        {
            var result = 0;
            try
            {

                if (IsEmployeeExist(employeeId, employeePin))
                {
                    using (var ctx = new DB_132062_workbyclockEntities1())
                    {
                        var item = ctx.EmployeeTimeCards.Where(c => c.EmployeeId == employeeId).OrderByDescending(c => c.CreateDate).FirstOrDefault();
                        if (item != null && item.TimeOut == null && item.TimeIn != null)
                        {
                            result = item.EmployeeTimeCardId;
                        }
                    }
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }

        public int GetlastTimeOutId(int employeeId, int employeePin)
        {
            var result = 0;
            try
            {

                if (IsEmployeeExist(employeeId, employeePin))
                {
                    using (var ctx = new DB_132062_workbyclockEntities1())
                    {
                        var item = ctx.EmployeeTimeCards.Where(c => c.EmployeeId == employeeId).OrderByDescending(c => c.CreateDate).FirstOrDefault();
                        if (item != null && item.TimeOut == null && item.TimeIn != null)
                        {
                            result = item.EmployeeTimeCardId;
                        }
                    }
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }
        public string SaveClockIn(int employeeId, int employeePin, int locationId, string locationIp, string deviceCode, DateTime? inTime, string inTimeString)
        {
            var result = "SUCCESS";
            try
            {
                if (IsEmployeeExist(employeeId, employeePin))
                {
                    var loc = GetLocationsByLocationId(locationId);
                    if (!loc.Active)
                    {
                        return "Your location is not active.";
                    }
                    if (string.IsNullOrEmpty(deviceCode))
                    {
                        var dev = GetAllDevice(locationId);
                        if (dev == null || dev.Count == 0)
                        {
                            return "Not a valid device.";
                        }
                        else
                        {
                            deviceCode = dev[0].DeviceCode;
                        }
                    }
                    var lastInCardId = GetlastTimeOutId(employeeId, employeePin);
                    if (lastInCardId == 0)
                    {
                        using (var ctx = new DB_132062_workbyclockEntities1())
                        {
                            DateTime nInDate = DateTime.Parse(inTimeString);
                            var card = new EmployeeTimeCard();
                            card.EmployeeId = employeeId;
                            card.LocationId = locationId;
                            if(!string.IsNullOrEmpty(locationIp) && locationIp.Length > 19)
                            {
                                locationIp = locationIp.Substring(0, 19);

                            }
                            card.LocationIp = locationIp;
                            card.TimeIn = nInDate;//DateTime.Parse(inTime.Value.ToString());
                            card.TimeInUtc = DateTime.Now.ToUniversalTime();
                            card.CreateDate = nInDate;// inTime.Value;
                            card.DeviceCode = deviceCode;
                            ctx.EmployeeTimeCards.Add(card);
                            //ctx.SaveChanges();
                            try
                            {
                                ctx.SaveChanges();
                            }
                            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                            {
                                Exception raise = dbEx;
                                foreach (var validationErrors in dbEx.EntityValidationErrors)
                                {
                                    foreach (var validationError in validationErrors.ValidationErrors)
                                    {
                                        string message = string.Format("{0}:{1}",
                                            validationErrors.Entry.Entity.ToString(),
                                            validationError.ErrorMessage);
                                        // raise a new exception nesting
                                        // the current instance as InnerException
                                        raise = new InvalidOperationException(message, raise);
                                    }
                                }
                                throw raise;
                            }
                            if (card.EmployeeTimeCardId > 0)
                            {
                                var employee = ctx.Employees.Where(c => c.EmployeeId == employeeId).FirstOrDefault();
                                return employee.EmployeeName + " have clocked-in successfully at " + nInDate.ToString("MM/dd/yyyy hh:mm tt");
                            }
                        }
                    }
                    else
                    {
                        return "You did not clock out from last time. You need to clock out first to clock in.";
                    }
                }
                else
                {
                    return "Not a valid employee.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }
        public string SaveClockOut(int employeeId, int employeePin, int locationId, string deviceCode, DateTime? outTime, string outTimeString)
        {
            var result = "SUCCESS";
            try
            {
                if (IsEmployeeExist(employeeId, employeePin))
                {
                    var loc = GetLocationsByLocationId(locationId);
                    if (!loc.Active)
                    {
                        return "Your location is not active.";
                    }
                    if (string.IsNullOrEmpty(deviceCode))
                    {
                        var dev = GetAllDevice(locationId);
                        if (dev == null || dev.Count == 0)
                        {
                            return "Not a valid device.";
                        }
                        else
                        {
                            deviceCode = dev[0].DeviceCode;
                        }
                    }
                    using (var ctx = new DB_132062_workbyclockEntities1())
                    {
                        var lastInCardId = GetlastTimeInId(employeeId, employeePin);
                        if (lastInCardId > 0)
                        {
                            DateTime nOutDate = DateTime.Parse(outTimeString);
                            var card = ctx.EmployeeTimeCards.Where(c => c.EmployeeTimeCardId == lastInCardId).FirstOrDefault();
                            card.TimeOut = nOutDate;// DateTime.Parse(outTime.Value.ToString()); 
                            card.TimeOutUtc = DateTime.Now.ToUniversalTime();
                            card.DeviceCodeOut = deviceCode;
                            ctx.SaveChanges();
                            if (card.EmployeeTimeCardId > 0)
                            {
                                var employee = ctx.Employees.Where(c => c.EmployeeId == employeeId).FirstOrDefault();
                                return employee.EmployeeName + " have clocked-out successfully at " + nOutDate.ToString("MM/dd/yyyy hh:mm tt");
                            }
                        }
                        else
                        {
                            return "You have never clocked in. Please clock in first in order to clock out.";
                        }
                    }
                }
                else
                {
                    return "Not a valid employee.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            return result;
        }
        public int DeleteClockInOut(int timeCardId)
        {

            var result = 0;

            try
            {
                using (var ctx = new DB_132062_workbyclockEntities1())
                {
                    var item = ctx.EmployeeTimeCards.Where(c => c.EmployeeTimeCardId == timeCardId).FirstOrDefault();
                    ctx.EmployeeTimeCards.Remove(item);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }

        public List<DeviceViewModel> GetAllDevice(int locationId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                return (from e in ctx.Devices
                        where e.LocationId == locationId
                        select new DeviceViewModel()
                        {
                            DeviceId = e.DeviceId,
                            DeviceCode = e.DeviceCode,
                            DeviceDescription = e.DeviceDescription,
                            LocationId = e.LocationId,
                            CreateDate = DateTime.Now,
                            Active = e.Active,
                        }).ToList();
            }
            return null;
        }
    }
}
