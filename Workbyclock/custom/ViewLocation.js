var app = angular.module("locationApp", []);
app.controller("locationCtrl", function ($scope) {
    $scope.LocationId = 0;
    $scope.PageTitle = "View Location";
    $scope.CompanyId = 0;
    $scope.LocationName = "";
    $scope.LocationDescription = "";
    $scope.LocationPhone = "";
    $scope.LocationEmail = "";
    $scope.LocationWebsite = "";
    $scope.LocationAddress1 = "";
    $scope.LocationAddress2 = "";
    $scope.LocationCity = "";
    $scope.LocationState = "";
    $scope.LocationZip = "";
    $scope.LocationCountry = "";
    $scope.Active = true;
   
    $scope.GetLocation = function () {
        const params = new URLSearchParams(window.location.search);
        const LocationId = params.get("id");

        if (typeof LocationId !== "undefined" && LocationId !== null) {
            var LocationObj = new Object();
            LocationObj.LocationId = LocationId;
            var LocationJson = JSON.stringify(LocationObj);
            $.ajax({
                type: "POST",
                url: "Location.aspx/GetLocationByLocationId",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: LocationJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.LocationId = items.d.LocationId;
                    $scope.CompanyId = items.d.CompanyId;
                    $scope.PageTitle = items.d.LocationName;
                    $scope.LocationName = items.d.LocationName;
                    $scope.LocationDescription = items.d.LocationDescription;
                    $scope.LocationPhone = items.d.LocationPhone;
                    $scope.LocationEmail = items.d.LocationEmail;
                    $scope.LocationWebsite = items.d.LocationWebsite;
                    $scope.LocationAddress1 = items.d.LocationAddress1;
                    $scope.LocationAddress2 = items.d.LocationAddress2;
                    $scope.LocationCity = items.d.LocationCity;
                    $scope.LocationState = items.d.LocationState;
                    $scope.LocationZip = items.d.LocationZip;
                    $scope.LocationCountry = items.d.LocationCountry;
                    $scope.Active = items.d.Active;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading Location. Please try again.");
                }

            });
        }

    };

    $scope.GetLocation();

    $scope.AddEmployee = function () {
        var urlString = "/Employee.aspx?locationid=" + $scope.LocationId;
        window.open(urlString, '_self')
    }

    $scope.AddEmployee = function () {
        var urlString = "/Employee.aspx?locationid=" + $scope.LocationId;
        window.open(urlString, '_self')
    }
});