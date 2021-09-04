var app = angular.module("companiesApp", []).controller("companiesCtrl", ['$scope',function ($scope) {

    $scope.CompaniesList = [];
    

    $scope.GetAllCompanies = function () {
        $.ajax({
            type: "POST",
            url: "Companies.aspx/GetAllCompanies",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.CompaniesList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
                alert("There was some error in creating company. Please try again.");
            }

        });
    };

    $scope.GetAllCompanies();

    $scope.ViewCompany = function (companyId) {
        var CompanyObj = new Object();
        CompanyObj.CompanyId = companyId;
        var CompanyJson = JSON.stringify(CompanyObj);
        $.ajax({
            type: "POST",
            url: "Companies.aspx/SetCurrentCompany",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data:CompanyJson
        }).done(function (items) {
            if (items.d) {
                var urlString = "/ViewCompany.aspx";
                window.open(urlString, '_self')
            } else {
                alert("There was some error in creating company. Please try again.");
            }

        });
    }
  
}
]);