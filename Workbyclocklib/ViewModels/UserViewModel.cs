using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workbyclocklib.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }

        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserCity { get; set; }
        public string UserState { get; set; }
        public string UserZip { get; set; }
        public string UserCountry { get; set; }
        public System.DateTime CreateDate { get; set; }

        public string UserFullAddress => GetEmployeeFullAddress(this.UserAddress1, this.UserCity, this.UserState, this.UserZip, this.UserCountry);

        public string GetEmployeeFullAddress(string addressString, string cityString, string stateString, string zipString, string countryString)
        {
            var result = "";

            if (!string.IsNullOrWhiteSpace(addressString))
            {
                result = addressString;
            }
            if (!string.IsNullOrWhiteSpace(cityString))
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result + ", " + cityString;
                }
                else
                {
                    result = cityString;
                }
            }
            if (!string.IsNullOrWhiteSpace(stateString))
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result + ", " + stateString;
                }
                else
                {
                    result = stateString;
                }

                if (!string.IsNullOrWhiteSpace(zipString))
                {
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        result = result + " " + zipString;
                    }
                    else
                    {
                        result = zipString;
                    }
                }
            }
            else if (!string.IsNullOrWhiteSpace(zipString))
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result + ", " + zipString;
                }
                else
                {
                    result = zipString;
                }
            }
            if (!string.IsNullOrWhiteSpace(countryString))
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result + ", " + countryString;
                }
                else
                {
                    result = countryString;
                }

            }

            return result;
        }

    }
}
