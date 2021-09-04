var app = angular.module("companyApp", []);
app.controller("companyCtrl", function($scope) {
    $scope.CompanyId = 0;
    $scope.PageTitle = "Add Company";
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

    $scope.SaveCompany = function () {
        var companyObj = new Object();
        companyObj.CompanyId = $scope.CompanyId;
        companyObj.CompanyName = $scope.CompanyName;
        companyObj.CompanyDescription = $scope.CompanyDescription;
        companyObj.CompanyPhone = $scope.CompanyPhone;
        companyObj.CompanyEmail = $scope.CompanyEmail;
        companyObj.CompanyWebsite = $scope.CompanyWebsite;
        companyObj.CompanyAddress1 = $scope.CompanyAddress1;
        companyObj.CompanyAddress2 = $scope.CompanyAddress2;
        companyObj.CompanyCity = $scope.CompanyCity;
        companyObj.CompanyState = $scope.CompanyState;
        companyObj.CompanyZip = $scope.CompanyZip;
        companyObj.CompanyCountry = $scope.CompanyCountry;
        companyObj.CompanyLogo = $scope.CompanyLogo;
        //companyObj.CompanyAdminId = $scope.CompanyAdminId;
        companyObj.Active = $scope.Active;
        companyObj.CompanyNumberOfUsers = $scope.CompanyNumberOfUsers;
        companyObj.CompanyNumberOfLocation = $scope.CompanyNumberOfLocation;
        
        var companyJson = JSON.stringify(companyObj); 
        $.ajax({
            type: "POST",
            url: "Company.aspx/SaveCompany",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: companyJson
        }).done(function (items) {
            if (items.d > 0) {
                alert("Company was created successfully.");
            } else {
                alert("There was some error in creating company. Please try again.");
            }
            
        });
    };


    $scope.GetCompany = function () {
        const params = new URLSearchParams(window.location.search);
        const companyId = params.get("id");
        if (typeof companyId !== "undefined" && companyId !== null) {
            var companyObj = new Object();
            companyObj.CompanyId = companyId;
            var companyJson = JSON.stringify(companyObj); 
            $.ajax({
                type: "POST",
                url: "Company.aspx/GetCompanyByCompanyId",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: companyJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.CompanyId = items.d.CompanyId;
                    $scope.PageTitle = items.d.CompanyName;
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
        }
        
    };

    $scope.GetCompany();
});