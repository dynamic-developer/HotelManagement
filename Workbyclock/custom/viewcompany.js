var app = angular.module("viewcompanyApp", []);
app.controller("viewcompanyCtrl", function ($scope) {
    $scope.CompanyId = 0;
    $scope.CompanyName = "";
    $scope.CompanyDescription = "";
    $scope.CompanyPhone = "";
    $scope.CompanyEmail = "";
    $scope.CompanyWebsite = "";
    $scope.CompanyAddress1 = "";
    $scope.CompanyAddress2 = "";
    $scope.CompanyCity = "";
    $scope.CompanyState = "";
    $scope.CompanyZip = "";
    $scope.CompanyCountry = "";
    $scope.CompanyLogo = null;
    $scope.CompanyAdminId = null;
    $scope.CompanyNumberOfUsers = 0;
    $scope.CompanyNumberOfLocation = 0;
    $scope.Active = true;

   
    $scope.GetCompany = function () {
             $.ajax({
                type: "POST",
                url: "ViewCompany.aspx/GetCompanyByCompanyId",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (items) {
                if (items.d != null) {
                    $scope.CompanyId = items.d.CompanyId;
                    $scope.CompanyName = items.d.CompanyName;
                    $scope.CompanyDescription = items.d.CompanyDescription;
                    $scope.CompanyPhone = items.d.CompanyPhone;
                    $scope.CompanyEmail = items.d.CompanyEmail;
                    $scope.CompanyWebsite = items.d.CompanyWebsite;
                    $scope.CompanyAddress1 = items.d.CompanyAddress1;
                    $scope.CompanyAddress2 = items.d.CompanyAddress2;
                    $scope.CompanyCity = items.d.CompanyCity;
                    $scope.CompanyState = items.d.CompanyState;
                    $scope.CompanyZip = items.d.CompanyZip;
                    $scope.CompanyCountry = items.d.CompanyCountry;
                    $scope.CompanyLogo = items.d.CompanyLogo;
                    $scope.CompanyAdminId = items.d.CompanyAdminId;
                    $scope.CompanyNumberOfUsers = items.d.CompanyNumberOfUsers;
                    $scope.CompanyNumberOfLocation = items.d.CompanyNumberOfLocation;
                    $scope.Active = items.d.Active;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading company. Please try again.");
                }

            });
        

    };

    $scope.GetCompany();
});