using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workbyclocklib.Models;

namespace Workbyclocklib.Services
{
    public class SignupService
    {

        public string SaveUser(string Id,
       string UserName,
       string Email,
       int RoleId,
       string UserFullName,
       string UserAddress1,
       string UserCity,
       string UserState,
       string UserZip,
       string UserCountry,
       bool Active,
       string UserPhone,
       bool IsEmailModified,
       int CompanyId)
        {
            using (var ctx = new DB_132062_workbyclockEntities1())
            {
                var item = ctx.AspNetUsers.Where(c => c.Id == Id).FirstOrDefault();
                if (item != null)
                {
                    item.PhoneNumber = UserPhone;
                    if (IsEmailModified)
                    {
                        item.Email = Email;
                        item.UserName = Email;
                        
                    }
                    ctx.SaveChanges();
                    var userInfo = ctx.Users.Where(c => c.UserAspNetId == item.Id).FirstOrDefault();
                    var UserObj = new User();
                    var isNewUser = false;
                    if (userInfo != null)
                    {
                        UserObj = userInfo;
                        isNewUser = false;
                    }
                    else
                    {
                        UserObj.CreateDate = DateTime.Now;
                        UserObj.UserAspNetId = item.Id;
                        isNewUser = true;
                    }
                    UserObj.UserFullName = UserFullName;
                    UserObj.UserAddress1 = UserAddress1;
                    UserObj.UserCity = UserCity;
                    UserObj.UserState = UserState;
                    UserObj.UserZip = UserZip;
                    UserObj.UserCountry = UserCountry;
                    UserObj.Active = Active;
                    UserObj.UserPhone = UserPhone;
                    
                    if (isNewUser)
                    {
                        ctx.Users.Add(UserObj);
                    }
                        

                    ctx.SaveChanges();

                    if (isNewUser)
                    {
                        var userInRole = new UserInRole();
                        userInRole.Active = true;
                        userInRole.UserId = item.Id;
                        userInRole.RoleId = RoleId;
                        userInRole.CreateDate = DateTime.Now;
                        ctx.UserInRoles.Add(userInRole);
                        ctx.SaveChanges();

                        var companyUser = new CompanyUser();
                        companyUser.Active = true;
                        companyUser.CompanyId = CompanyId;
                        companyUser.UserId = item.Id;
                        companyUser.CreateDate = DateTime.Now;
                        ctx.CompanyUsers.Add(companyUser);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        var userInRole = ctx.UserInRoles.Where(c => c. UserId == item.Id).FirstOrDefault();
                        userInRole.Active = true;
                        userInRole.UserId = item.Id;
                        userInRole.RoleId = RoleId;
                        userInRole.CreateDate = DateTime.Now;
                        ctx.SaveChanges();
                    }
                    return item.Id;
                }
            }
            return string.Empty;
        }
    }
}
