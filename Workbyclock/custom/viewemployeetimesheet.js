var app = angular.module("ViewEmployeeTimesheetApp", []);
app.controller("ViewEmployeeTimesheetCtrl", function ($scope) {

    $scope.TimesheetList = [];
    $scope.LocationList = [];
    $scope.LocationId = 0;
    $scope.SetReportDate = function () {
        var startDate = new Date();
        startDate.setDate(-14);
        $scope.ReportStartDate = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate(), startDate.getHours(), startDate.getMinutes()).toISOString().slice(0, -1); //new Date(startDate).toISOString().slice(0, -1).toISOString().slice(0, -1);
        var endDate = new Date();
        endDate.setMinutes(-1);
        $scope.ReportEndDate = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate(), endDate.getHours(), endDate.getMinutes()).toISOString().slice(0, -1);

        $("#dtStart").val($scope.ReportStartDate);
        $("#dtEnd").val($scope.ReportEndDate);
       
    }
    //$scope.SetReportDate();

    $scope.GetEmployeeTimesheet = function () {
        const params = new URLSearchParams(window.location.search);
        const employeeId = params.get("id");
        const sd = params.get("sd");
        const ed = params.get("ed");
        const en = params.get("en");
        if (typeof employeeId !== "undefined" && employeeId !== null) {
            $scope.EmployeeId = employeeId;
        } else {
            window.location.href = "/dashboard";
        }
        if (typeof sd !== "undefined" && sd !== null) {
            $scope.ReportStartDate = new Date(sd);
            $("#dtStart").val($scope.ReportStartDate);
            $scope.$apply();
        }
        if (typeof en !== "undefined" && en !== null) {
            $scope.EmployeeName = en;
            $scope.PageTitle = en + " - " + employeeId;
            $scope.$apply();
        }
        if (typeof ed !== "undefined" && ed !== null) {
            $scope.ReportEndDate = new Date(ed);
            $("#dtEnd").val($scope.ReportEndDate);
            $scope.$apply();
        }
        if (typeof $scope.EmployeeId !== "undefined" && $scope.EmployeeId !== null) {
            var EmployeeObj = new Object();
            EmployeeObj.startDate = $scope.ReportStartDate;
            EmployeeObj.endDate = $scope.ReportEndDate;
            EmployeeObj.EmployeeId = $scope.EmployeeId;
            var EmployeeJson = JSON.stringify(EmployeeObj);
            $.ajax({
                type: "POST",
                url: "ViewEmployeeTimesheet.aspx/GetAllTimesheetForEmployee",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: EmployeeJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.EmployeeTimesheet = items.d;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading Employee. Please try again.");
                }

            });
        }

    };

    $scope.GetEmployeeTimesheet();
   

});