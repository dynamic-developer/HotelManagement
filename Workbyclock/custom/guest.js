var app = angular.module("GuestApp", []);
app.controller("GuestCtrl", function ($scope) {
    $scope.GuestId= 0;
    $scope.CompanyId = 0;
    $scope.PageTitle = "Add Guest";
    $scope.GuestFullName = "";
    $scope.GuestPhone = "";
    $scope.GuestEmail = "";
    $scope.IsDNR = false;
    $scope.GuestAddress = "";
    $scope.GuestDriverLicenseId = "";

    $scope.SaveGuest = function () {
        if ($scope.GuestFullName == "" || $scope.GuestFullName == undefined || $scope.GuestFullName == null) {
            alert("Please enter guest name")
            return;
        }
        var GuestObj = new Object();
        GuestObj.GuestId = $scope.GuestId;
        GuestObj.CompanyId = $scope.CompanyId;
        GuestObj.GuestFullName = $scope.GuestFullName;
        GuestObj.GuestPhone = $scope.GuestPhone;
        GuestObj.GuestEmail = $scope.GuestEmail;
        GuestObj.IsDNR = $scope.IsDNR;
        GuestObj.GuestAddress = $scope.GuestAddress;
        GuestObj.GuestDriverLicenseId = $scope.GuestDriverLicenseId;
        var GuestJson = JSON.stringify(GuestObj);
        $.ajax({
            type: "POST",
            url: "Guest.aspx/SaveGuest",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: GuestJson
        }).done(function (items) {
            if (items.d > 0) {
                if ($scope.GuestId == 0) {
                    var r = confirm("Guest was saved successfully. Would you like to add another Guest? ");
                    if (r == true) {
                        $scope.ClearForm();
                    } else {
                        var url = "/Guest.aspx";
                        window.open(url, '_self');
                    }
                } else {
                    alert("Guest was saved successfully.");
                }
            } else {
                alert("There was some error in creating Guest. Please try again.");
            }
        });
    };
    $scope.CompaniesList = [];

    $scope.ClearForm = function () {
        $scope.GuestId = 0;
        $scope.CompanyId = 0;
        $scope.PageTitle = "Add Guest";
        $scope.GuestFullName = "";
        $scope.GuestPhone = "";
        $scope.GuestEmail = "";
        $scope.IsDNR = true;
        $scope.GuestAddress = "";
        $scope.GuestDriverLicenseId = "";
        $scope.$apply();
    }

    $scope.GetAllCompanies = function () {
        $.ajax({
            type: "POST",
            url: "Guest.aspx/GetAllCompanies",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.CompaniesList = items.d;
                $scope.$apply();

            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    };

    $scope.GetGuest= function () {
        const params = new URLSearchParams(window.location.search);
        const GuestId = params.get("GuestId");
        if (typeof GuestId !== "undefined" && GuestId !== null) {
            var GuestObj = new Object();
            GuestObj.GuestId = GuestId;
            var GuestJson = JSON.stringify(GuestObj);
            $.ajax({
                type: "POST",
                url: "Guest.aspx/GetGuestByGuestId",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: GuestJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.GuestId = items.d.GuestId;
                    $scope.CompanyId = items.d.CompanyId;
                    $scope.PageTitle = items.d.GuestId + " - " + items.d.GuestFullName;
                    $scope.GuestPhone = items.d.GuestPhone;
                    $scope.GuestFullName = items.d.GuestFullName;
                    $scope.GuestEmail = items.d.GuestEmail;
                    $scope.IsDNR = items.d.IsDNR;
                    $scope.GuestAddress = items.d.GuestAddress;
                    $scope.GuestDriverLicenseId = items.d.GuestDriverLicenseId;
                    $scope.$apply();
                } else {
                    alert("There was some error in loading Guest. Please try again.");
                }
            });
        }
    };
    $scope.GetGuest();
    $scope.GoBack = function(){
        var url = "/GuestList.aspx";
        window.location = url;
    }
});