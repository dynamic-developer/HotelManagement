var app = angular.module("TimesheetApp", []).controller("TimesheetCtrl", ['$scope', function ($scope) {

    $scope.TimesheetList = [];
    $scope.LocationList = [];
    $scope.EmployeeTypes = ["All", "Only Active"];
    $scope.EmployeeType = "";
    $scope.LocationId = 0;
    $scope.SetReportDate = function () {
       
        $scope.EmployeeType = "Only Active";
        var startDate = new Date();
        startDate.setDate(startDate.getDate() - 14);
        $scope.ReportStartDate = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate(), startDate.getHours(), startDate.getMinutes());//.toISOString().slice(0, -1); //new Date(startDate).toISOString().slice(0, -1).toISOString().slice(0, -1);
        var endDate = new Date();
        $scope.ReportEndDate = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate(), endDate.getHours(), endDate.getMinutes());//.toISOString().slice(0, -1);

        $("#dtStart").val($scope.ReportStartDate);
        $("#dtEnd").val($scope.ReportEndDate);
        $scope.GetAllLocations();
    }
    //$scope.SetReportDate();

    $scope.GetAllTimesheet = function () {

        var locId = 0;
        if ($scope.LocationId != 0) {
            locId = $scope.LocationId.LocationId;
        }
        var sdSt = "";
        var endSt = "";
        if (typeof $scope.ReportStartDate !== "undefined" && $scope.ReportStartDate !== null) {
            sdSt = $scope.ReportStartDate.toLocaleString();
        }
        if (typeof $scope.ReportEndDate !== "undefined" && $scope.ReportEndDate !== null) {
            endSt = $scope.ReportEndDate.toLocaleString();
        }
        var TimeSheetObj = new Object();
        TimeSheetObj.startDateString = sdSt;
        TimeSheetObj.endDateString = endSt;
        TimeSheetObj.locationId = locId;
        TimeSheetObj.employeeType = $scope.EmployeeType;
        var TimeSheetJson = JSON.stringify(TimeSheetObj);
        $.ajax({
            type: "POST",
            url: "Timesheet.aspx/GetAllTimesheet",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: TimeSheetJson
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
               
                $scope.TimesheetList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
               // alert("There was some error in loading Timesheet. Please try again.");
            }

        });
    };

    $scope.GetAllLocations = function () {
        $.ajax({
            type: "POST",
            url: "Timesheet.aspx/GetAllLocations",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {

                $scope.LocationList = items.d;
                $scope.$apply();
                let element = document.getElementById("selLocations");
                element.value = $scope.LocationId;
                $scope.GetAllTimesheet();
            } else {
                // alert("There was some error in loading Timesheet. Please try again.");
            }

        });
    };

    //$scope.GetAllLocations();
}
]);