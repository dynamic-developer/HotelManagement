using System;

namespace Workbyclocklib.ViewModels
{
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationPhone { get; set; }
        public string LocationEmail { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public string LocationZip { get; set; }
        public string LocationCountry { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public string LocationFullAddress => GetLocationFullAddress(this.LocationAddress1, this.LocationCity, this.LocationState, this.LocationZip, this.LocationCountry);

        public string GetLocationFullAddress(string addressString, string cityString, string stateString, string zipString, string countryString)
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
                    result = result+ ", " + cityString;
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
