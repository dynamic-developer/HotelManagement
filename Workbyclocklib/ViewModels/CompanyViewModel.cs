using System;

namespace Workbyclocklib.ViewModels
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZip { get; set; }
        public string CompanyCountry { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string CompanyAdminId { get; set; }
        public string CompanyAdminName { get; set; }
        public int CompanyNumberOfUsers { get; set; }
        public int CompanyNumberOfLocation { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public string CompanyFullAddress => GetCompanyFullAddress(this.CompanyAddress1, this.CompanyCity, this.CompanyState, this.CompanyZip, this.CompanyCountry);

        public string GetCompanyFullAddress(string addressString, string cityString, string stateString, string zipString, string countryString)
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
                    result =  cityString;
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
