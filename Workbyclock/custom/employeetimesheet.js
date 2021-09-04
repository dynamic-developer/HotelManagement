var app = angular.module("EmployeeTimesheetApp", []);
app.controller("EmployeeTimesheetCtrl", function ($scope) {
  
    $scope.PageTitle = "Timesheet";
    $scope.EmployeeId = null;
    $scope.EmployeeName = "";
    $scope.EmployeeTimesheet = [];
    $scope.SetReportDate = function () {
        var startDate = new Date();
        startDate.setDate(startDate.getDate() - 14);
        $scope.ReportStartDate = startDate;// new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate(), startDate.getHours(), startDate.getMinutes()).toISOString().slice(0, -1); //new Date(startDate).toISOString().slice(0, -1).toISOString().slice(0, -1);
        var endDate = new Date();
        $scope.ReportEndDate = endDate;//new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate(), endDate.getHours(), endDate.getMinutes()).toISOString().slice(0, -1);

        $("#dtStart").val($scope.ReportStartDate);
        $("#dtEnd").val($scope.ReportEndDate);
       
    };

    $scope.SetReportDate();

    $scope.GetReportEmployeeTimesheet = function () {
        const params = new URLSearchParams(window.location.search);
        const employeeId = params.get("id");
       
        if (typeof employeeId !== "undefined" && employeeId !== null) {
            $scope.EmployeeId = employeeId;
        } else {
            window.location.href = "/dashboard";
        }
        var sdSt = "";
        var endSt = "";
        if (typeof $scope.ReportStartDate !== "undefined" && $scope.ReportStartDate !== null) {
            sdSt = $scope.ReportStartDate.toLocaleString();
        }
        if (typeof $scope.ReportEndDate !== "undefined" && $scope.ReportEndDate !== null) {
            endSt = $scope.ReportEndDate.toLocaleString();
        }
        if (typeof $scope.EmployeeId !== "undefined" && $scope.EmployeeId !== null) {
            var EmployeeObj = new Object();
            EmployeeObj.startDateString = sdSt;
            EmployeeObj.endDateString = endSt;
            EmployeeObj.employeeId = $scope.EmployeeId;
            var EmployeeJson = JSON.stringify(EmployeeObj);
            $.ajax({
                type: "POST",
                url: "EmployeeTimesheet.aspx/GetAllTimesheetForEmployee",
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

    $scope.GetEmployeeTimesheet = function () {
        const params = new URLSearchParams(window.location.search);
        const employeeId = params.get("id");
        var sd = params.get("sd");
        var ed = params.get("ed");
        const en = params.get("en");
        if (typeof employeeId !== "undefined" && employeeId !== null) {
            $scope.EmployeeId = employeeId;
        } else {
            window.location.href = "/dashboard";
        }
        if (typeof sd !== "undefined" && sd !== null) {
            var b = sd.split(/\D+/);
            var sdDt = new Date(Date.UTC(b[1], --b[2], b[3], b[4], b[5], b[6], b[7]));
             $scope.ReportStartDate = sdDt;// new Date(sd);
            $("#dtStart").val($scope.ReportStartDate);
            
        }
        if (typeof en !== "undefined" && en !== null) {
            $scope.EmployeeName = en;
            $scope.PageTitle = en + " - " + employeeId;
            //$scope.$apply();
        }
        if (typeof ed !== "undefined" && ed !== null) {
            var b = ed.split(/\D+/);
            var edDt = new Date(Date.UTC(b[1], --b[2], b[3], b[4], b[5], b[6], b[7]));
            $scope.ReportEndDate = new Date(edDt);
            $("#dtEnd").val($scope.ReportEndDate);
            //$scope.$apply();
        } 

        var sdSt = "";
        var endSt = "";
        if (typeof $scope.ReportStartDate !== "undefined" && $scope.ReportStartDate !== null) {
            sdSt = $scope.ReportStartDate.toLocaleString();
        }
        if (typeof $scope.ReportEndDate !== "undefined" && $scope.ReportEndDate !== null) {
            endSt = $scope.ReportEndDate.toLocaleString();
        }
       // $scope.$apply();
        if (typeof $scope.EmployeeId !== "undefined" && $scope.EmployeeId !== null) {
            var EmployeeObj = new Object();
            EmployeeObj.startDateString = sdSt;
            EmployeeObj.endDateString = endSt;
            EmployeeObj.employeeId = $scope.EmployeeId;
            var EmployeeJson = JSON.stringify(EmployeeObj);
            $.ajax({
                type: "POST",
                url: "EmployeeTimesheet.aspx/GetAllTimesheetForEmployee",
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

    $scope.ManageTimesheet = function () {
        var url = "/ManageTimesheet.aspx?id=" + $scope.EmployeeId + "&en=" + $scope.EmployeeName;
        window.open(url, '_self');
    }

    $scope.EmailTimesheet = function () {
        
        const params = new URLSearchParams(window.location.search);
        const employeeId = params.get("id");
        var sd = params.get("sd");
        var ed = params.get("ed");
        const en = params.get("en");
        if (typeof employeeId !== "undefined" && employeeId !== null) {
            $scope.EmployeeId = employeeId;
        } else {
            window.location.href = "/dashboard";
        }
        if (typeof sd !== "undefined" && sd !== null) {
            var b = sd.split(/\D+/);
            var sdDt = new Date(Date.UTC(b[1], --b[2], b[3], b[4], b[5], b[6], b[7]));
            $scope.ReportStartDate = sdDt;// new Date(sd);
            $("#dtStart").val($scope.ReportStartDate);

        }
        if (typeof en !== "undefined" && en !== null) {
            $scope.EmployeeName = en;
            $scope.PageTitle = en + " - " + employeeId;
            //$scope.$apply();
        }
        if (typeof ed !== "undefined" && ed !== null) {
            var b = ed.split(/\D+/);
            var edDt = new Date(Date.UTC(b[1], --b[2], b[3], b[4], b[5], b[6], b[7]));
            $scope.ReportEndDate = new Date(edDt);
            $("#dtEnd").val($scope.ReportEndDate);
            //$scope.$apply();
        }

        var sdSt = "";
        var endSt = "";
        if (typeof $scope.ReportStartDate !== "undefined" && $scope.ReportStartDate !== null) {
            sdSt = $scope.ReportStartDate.toLocaleString();
        }
        if (typeof $scope.ReportEndDate !== "undefined" && $scope.ReportEndDate !== null) {
            endSt = $scope.ReportEndDate.toLocaleString();
        }
        // $scope.$apply();
        if (typeof $scope.EmployeeId !== "undefined" && $scope.EmployeeId !== null) {
            var EmployeeObj = new Object();
            EmployeeObj.startDateString = sdSt;
            EmployeeObj.endDateString = endSt;
            EmployeeObj.employeeId = $scope.EmployeeId;
            var EmployeeJson = JSON.stringify(EmployeeObj);
            $.ajax({
                type: "POST",
                url: "EmployeeTimesheet.aspx/EmailAllTimesheetForEmployee",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: EmployeeJson,
                processData: false
            }).done(function (items) {
                if (items.d != null && items.d) {
                    alert("Email was sent successfully");

                } else {
                    alert("There was some error while sending email.");
                }

            });
        }
    }

});