var app = angular.module("EmployeeApp", []);
app.controller("EmployeeCtrl", function ($scope) {
    $scope.EmployeeId = 0;
    $scope.CompanyId = 0;
    $scope.PageTitle = "Add Employee";
    $scope.EmployeeName = "";
    $scope.EmployeePin = "";
    $scope.EmployeePhone = "";
    $scope.EmployeeEmail = "";
    $scope.EmployeeLastFour = "";
    $scope.EmployeeAddress1 = "";
    $scope.EmployeeAddress2 = "";
    $scope.EmployeeCity = "";
    $scope.EmployeeState = "";
    $scope.EmployeeZip = "";
    $scope.EmployeeCountry = "USA";
    $scope.EmployeeIsHourly = "";
    $scope.EmployeeRate = "";
    $scope.EmployeeBirthDate = "";
    $scope.EmployeeHireDate = "";
    $scope.EmployeeLeftDate = "";
    $scope.Active = true;
    $scope.EmployeeEmploymentTypeId = null;

    $scope.SaveEmployee = function () {
        var EmployeeObj = new Object();
        EmployeeObj.EmployeeId = $scope.EmployeeId;
        EmployeeObj.LocationId = $scope.LocationId;
        EmployeeObj.EmployeePin = $scope.EmployeePin;
        EmployeeObj.EmployeeName = $scope.EmployeeName;
        EmployeeObj.EmployeeEmail = $scope.EmployeeEmail;
        EmployeeObj.EmployeePhone = $scope.EmployeePhone;
        EmployeeObj.EmployeeLastFour = $scope.EmployeeLastFour;
        EmployeeObj.EmployeeEmploymentTypeId = $scope.EmployeeEmploymentTypeId;
        EmployeeObj.EmployeeIsHourly = $scope.EmployeeIsHourly;
        EmployeeObj.EmployeeRate = $scope.EmployeeRate;
        EmployeeObj.EmployeeBirthDate = $scope.EmployeeBirthDate;
        EmployeeObj.EmployeeHireDate = $scope.EmployeeHireDate;
        EmployeeObj.EmployeeLeftDate = $scope.EmployeeLeftDate;
        EmployeeObj.EmployeeAddress1 = $scope.EmployeeAddress1;
        EmployeeObj.EmployeeCity = $scope.EmployeeCity;
        EmployeeObj.EmployeeState = $scope.EmployeeState;
        EmployeeObj.EmployeeZip = $scope.EmployeeZip;
        EmployeeObj.EmployeeCountry = $scope.EmployeeCountry;
        EmployeeObj.Active = $scope.Active;
       

        var EmployeeJson = JSON.stringify(EmployeeObj);
        $.ajax({
            type: "POST",
            url: "Employee.aspx/SaveEmployee",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: EmployeeJson
        }).done(function (items) {
            if (items.d > 0) {
                if ($scope.EmployeeId == 0) {
                    var r = confirm("Employee was saved successfully. Would you like to add another employee? ");
                    if (r == true) {
                       $scope.ClearForm();
                    } else {
                        var url = "/Employees.aspx";
                        window.open(url, '_self');
                    }
                } else {
                    alert("Employee was saved successfully.");
                }
            } else {
                alert("There was some error in creating Employee. Please try again.");
            }

        });
    };
    $scope.EmploymentTypeList = [];

    $scope.ClearForm = function () {
        $scope.EmployeeId = 0;
        $scope.CompanyId = 0;
        $scope.PageTitle = "Add Employee";
        $scope.EmployeeName = "";
        $scope.EmployeePin = "";
        $scope.EmployeePhone = "";
        $scope.EmployeeEmail = "";
        $scope.EmployeeLastFour = "";
        $scope.EmployeeAddress1 = "";
        $scope.EmployeeAddress2 = "";
        $scope.EmployeeCity = "";
        $scope.EmployeeState = "";
        $scope.EmployeeZip = "";
        $scope.EmployeeCountry = "USA";
        $scope.EmployeeIsHourly = "";
        $scope.EmployeeRate = "";
        $scope.EmployeeBirthDate = "";
        $scope.EmployeeHireDate = "";
        $scope.EmployeeLeftDate = "";
        $scope.Active = true;
        $scope.EmployeeEmploymentTypeId = null;
        $scope.$apply();
    }

    $scope.GetEmploymentType = function () {
            $.ajax({
                type: "POST",
                url: "Employee.aspx/GetAllEmployementType",
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (items) {
                if (items.d != null) {
                    $scope.EmploymentTypeList = items.d;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading Employee. Please try again.");
                }

            });
   };

    //$scope.GetEmploymentType();

    $scope.GetEmployee = function () {
        const params = new URLSearchParams(window.location.search);
        const EmployeeId = params.get("id");
        const locationId = params.get("locationid");
        if (typeof locationId !== "undefined" && locationId !== null) {
            $scope.LocationId = locationId;
        } else {
            window.location.href = "/dashboard";
        }
        if (typeof EmployeeId !== "undefined" && EmployeeId !== null) {
            var EmployeeObj = new Object();
            EmployeeObj.EmployeeId = EmployeeId;
            var EmployeeJson = JSON.stringify(EmployeeObj);
            $.ajax({
                type: "POST",
                url: "Employee.aspx/GetEmployeeById",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: EmployeeJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.EmployeeId = items.d.EmployeeId;
                    $scope.LocationId = items.d.LocationId;
                    $scope.PageTitle = items.d.EmployeeId + " - " + items.d.EmployeeName;
                    $scope.EmployeePin = items.d.EmployeePin;
                    $scope.EmployeeName = items.d.EmployeeName;
                    $scope.EmployeeEmail = items.d.EmployeeEmail;
                    $scope.EmployeePhone = items.d.EmployeePhone;
                    $scope.EmployeeLastFour = items.d.EmployeeLastFour;
                    $scope.EmployeeEmploymentTypeId = items.d.EmployeeEmploymentTypeId;
                    $scope.EmployeeIsHourly = items.d.EmployeeIsHourly;
                    $scope.EmployeeRate = items.d.EmployeeRate;
                    if (items.d.EmployeeBirthDate !== null) {
                        $scope.EmployeeBirthDate = new Date(parseInt(items.d.EmployeeBirthDate.substr(6)));
                    }
                    if (items.d.EmployeeHireDate !== null) {
                        $scope.EmployeeHireDate = new Date(parseInt(items.d.EmployeeHireDate.substr(6)));
                    }
                    if (items.d.EmployeeLeftDate !== null) {
                        $scope.EmployeeLeftDate = new Date(parseInt(items.d.EmployeeLeftDate.substr(6)));
                    }
                    
                   
                    $scope.EmployeeAddress1 = items.d.EmployeeAddress1;
                    $scope.EmployeeCity = items.d.EmployeeCity;
                    $scope.EmployeeState = items.d.EmployeeState;
                    $scope.EmployeeZip = items.d.EmployeeZip;
                    $scope.EmployeeCountry = items.d.EmployeeCountry;
                    $scope.Active = items.d.Active;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading Employee. Please try again.");
                }

            });
        }

    };

    $scope.GetEmployee();
});