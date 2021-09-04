using System;
using System.Globalization;

namespace Workbyclocklib.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int LocationId { get; set; }
        public string DeviceCode { get; set; }
        public string LocationName { get; set; }
        public int EmployeePin { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public Nullable<int> EmployeeLastFour { get; set; }
        public Nullable<int> EmployeeEmploymentTypeId { get; set; }
        public string EmployeeEmploymentTypeName { get; set; }
        public Nullable<bool> EmployeeIsHourly { get; set; }
        public Nullable<float> EmployeeRate { get; set; }
        public Nullable<System.DateTime> EmployeeBirthDate { get; set; }
        public Nullable<System.DateTime> EmployeeHireDate { get; set; }
        public Nullable<System.DateTime> EmployeeLeftDate { get; set; }
        public string EmployeeAddress1 { get; set; }
        public string EmployeeAddress2 { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeeZip { get; set; }
        public string EmployeeCountry { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public double Hours { get; set; }
        public string grossRate => GetGross(this.EmployeeRate, this.Hours);

        public string GetGross(double? rateValue, double? hourValue)
        {
            double? result = 0;

            if (rateValue != null && hourValue != null)
            {
                result = rateValue.Value * hourValue.Value;
            }
            if (result == 0) return "$0.00";

            return Math.Round(result.Value, 2).ToString("C", CultureInfo.CurrentCulture); 
        }

        public string EmployeeFullAddress => GetEmployeeFullAddress(this.EmployeeAddress1, this.EmployeeCity, this.EmployeeState, this.EmployeeZip, this.EmployeeCountry);

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
