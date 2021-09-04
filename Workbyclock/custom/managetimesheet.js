var app = angular.module("ManageTimesheetApp", []);
app.controller("ManageTimesheetCtrl", function ($scope) {

    $scope.PageTitle = "Add Timesheet";
    $scope.LocationList = [];
    $scope.EmployeeTimeCardId = 0;
    $scope.EmployeeId = 0;
    $scope.EmployeeName = "";
    $scope.DeviceId = "";
    $scope.LocationId = 0;
    $scope.LocationIp = "Application";
    $scope.TimeIn = null;
    $scope.TimeOut = null;
    $scope.Reason = "";
    $scope.ReportStartDate = null;
    $scope.ReportEndDate = null;

    $scope.SaveEmployeeTimeSheet = function () {
        var locId = 0;
        if (typeof $scope.LocationId != "undefined" && typeof $scope.LocationId.LocationId == "undefined" && $scope.LocationId > 0) {
            locId = $scope.LocationId;
        } else if (typeof $scope.LocationId != "undefined" && typeof $scope.LocationId.LocationId != "undefined" && $scope.LocationId.LocationId > 0) {
            locId = $scope.LocationId.LocationId;
        }
        if ($scope.TimeIn == null) {
            alert("Time in is required.");
            return;
        } else {
            if ($scope.TimeOut != null && $scope.TimeIn > $scope.TimeOut) {
                alert("Time in can not be later than Time out.");
                return;
            }
        }
        if (locId == 0) {
            alert("Location is required.");
            return;
        }
        if ($scope.Reason == "") {
            alert("Reason is required.");
            return;
        }
        var TimecardObj = new Object();
        TimecardObj.EmployeeTimeCardId = $scope.EmployeeTimeCardId;
        TimecardObj.EmployeeId = $scope.EmployeeId;
        TimecardObj.LocationId = locId;
        TimecardObj.LocationIp = "Application";
        TimecardObj.TimeIn = $scope.TimeIn;
        TimecardObj.TimeOut = $scope.TimeOut;
        TimecardObj.TimeInString = $scope.TimeIn.toLocaleString();
        if ($scope.TimeOut != null) {
            TimecardObj.TimeOutString = $scope.TimeOut.toLocaleString();
        } else {
            TimecardObj.TimeOutString = "";
        }
        
        TimecardObj.Reason = $scope.Reason;
        var TimecardJson = JSON.stringify(TimecardObj);
        $.ajax({
            type: "POST",
            url: "ManageTimeSheet.aspx/SaveTimesheetByEmployeeId",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: TimecardJson
        }).done(function (items) {
            if (items.d != null && items.d != "") {
                if (items.d == "Success") {
                    var url = "/Timesheet.aspx";
                    window.open(url, '_self');
                } else {
                    alert(items.d);
                }
            }  else {
                alert("There was some error in saving timecard. Please try again.");
            }

        });
    };
    
    $scope.DeleteEmployeeTimeSheet = function () {
        if ($scope.Reason == "") {
            alert("Reason is required.");
            return;
        }
        var locId = 0;
        if (typeof $scope.LocationId != "undefined" && typeof $scope.LocationId.LocationId == "undefined" && $scope.LocationId > 0) {
            locId = $scope.LocationId;
        } else if (typeof $scope.LocationId != "undefined" && typeof $scope.LocationId.LocationId != "undefined" && $scope.LocationId.LocationId > 0) {
            locId = $scope.LocationId.LocationId;
        }
        if (locId == 0) {
            alert("Location is required.");
        }
        var TimecardObj = new Object();
        TimecardObj.EmployeeTimeCardId = $scope.EmployeeTimeCardId;
        TimecardObj.Reason = $scope.Reason;
        var TimecardJson = JSON.stringify(TimecardObj);
        $.ajax({
            type: "POST",
            url: "ManageTimeSheet.aspx/DeleteTimesheetByEmployeeId",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: TimecardJson
        }).done(function (items) {
            if (items.d != null && items.d != "") {
                if (items.d == "Success") {
                    var url = "/Timesheet.aspx";
                    window.open(url, '_self');
                } else {
                    alert(items.d);
                }
            } else {
                alert("There was some error in deleting timecard. Please try again.");
            }

        });
    };

    //$scope.GetEmploymentType();

    $scope.GetEmployeeTimeSheet = function () {
        const params = new URLSearchParams(window.location.search);
        const employeeId = params.get("id");
        const employeeName = params.get("en");
        const timeCardId = params.get("tid");
        const sd = params.get("sd");
        const ed = params.get("ed");
        if (typeof employeeId !== "undefined" && employeeId !== null) {
            $scope.EmployeeId = employeeId;
        } else {
            window.location.href = "/dashboard";
        }
        if (typeof sd !== "undefined" && sd !== null) {
            $scope.ReportStartDate = new Date(sd);
        }
        if (typeof ed !== "undefined" && ed !== null) {
            $scope.ReportEndDate = new Date(ed);
           
        }
        if (typeof timeCardId !== "undefined" && timeCardId !== null) {
            $scope.EmployeeTimeCardId = timeCardId;
        }
        if (typeof employeeName !== "undefined" && employeeName !== null) {
            $scope.EmployeeName = employeeName;
        }
        $scope.PageTitle = "Timecard ID#" + $scope.EmployeeTimeCardId + " For " + $scope.EmployeeName + " - " + $scope.EmployeeId;
        if (typeof employeeId !== "undefined" && employeeId !== null) {
            var EmployeeObj = new Object();
            EmployeeObj.EmployeeId = $scope.EmployeeId;
            EmployeeObj.TimeCardId = $scope.EmployeeTimeCardId;
            var EmployeeJson = JSON.stringify(EmployeeObj);
            $.ajax({
                type: "POST",
                url: "ManageTimeSheet.aspx/GetTimesheetByEmployeeId",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: EmployeeJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.PageTitle = "Timecard ID#" + $scope.EmployeeTimeCardId + " For " + $scope.EmployeeName + " - " + $scope.EmployeeId ;
                    $scope.EmployeeTimeCardId = items.d.EmployeeTimeCardId;
                    $scope.EmployeeId = items.d.EmployeeId;
                    $scope.DeviceId = items.d.DeviceId;
                    $scope.LocationId = items.d.LocationId;
                    $scope.LocationIp = items.d.LocationIp;
                    if (items.d.TimeIn !== null) {
                        //$scope.TimeIn = new Date(parseInt(items.d.TimeIn.substr(6)));
                        $scope.TimeIn = new Date(items.d.TimeInSt);
                    }
                    if (items.d.TimeOut !== null) {
                        //$scope.TimeOut = new Date(parseInt(items.d.TimeOut.substr(6)));
                        $scope.TimeOut = new Date(items.d.TimeOutSt);
                    }
                    $scope.$apply();
                    let element = document.getElementById("selLocations");
                    element.value = $scope.LocationId;

                } else {
                    //alert("There was some error in loading Employee. Please try again.");
                }

            });
        }

    };

    $scope.GetEmployeeTimeSheet();

    $scope.GetAllLocations = function () {
        $.ajax({
            type: "POST",
            url: "ManageTimesheet.aspx/GetAllLocations",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {

                $scope.LocationList = items.d;
                $scope.$apply();
                let element = document.getElementById("selLocations");
                element.value = $scope.LocationId;
                
            } else {
                // alert("There was some error in loading Timesheet. Please try again.");
            }

        });
    };

    $scope.GetAllLocations();
});