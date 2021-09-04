var app = angular.module("AddRoomApp", []);
app.controller("AddRoomCtrl", function ($scope) {
    $scope.RoomId = 0;
    $scope.CompanyId = 0;
    $scope.RoomStatusId = 0;
    $scope.Locationid = 0;
    $scope.PageTitle = "Add Room";
    $scope.RoomName = "";
    $scope.RoomDesc = "";
    $scope.RoomBeds = 0;
    $scope.RoomPrice = 0;
 

    $scope.SaveRoom = function() {
        var RoomObj = new Object();
        RoomObj.RoomId = $scope.RoomId;
        RoomObj.RoomName = $scope.RoomName;
        RoomObj.RoomDesc = $scope.RoomDesc;
        RoomObj.RoomBeds = $scope.RoomBeds;
        RoomObj.RoomPrice = $scope.RoomPrice;
        RoomObj.RoomStatusId = $scope.RoomStatusId;
        RoomObj.CompanyId = $scope.CompanyId;
        RoomObj.Locationid = $scope.Locationid;

        var RoomJson = JSON.stringify(RoomObj);
        $.ajax({
            type: "POST",
            url: "Room.aspx/SaveRoom",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: RoomJson
        }).done(function (items) {
            if (items.d > 0) {
                if ($scope.RoomId == 0) {
                    var r = confirm("Room  was saved successfully. Would you like to add another Room? ");
                    if (r == true) {
                        $scope.ClearForm();
                    } else {
                        var url = "/RoomList.aspx";
                        window.open(url, '_self');
                    }
                } else {
                    alert("Room was saved successfully.");
                }
            } else {
                alert("There was some error in creating Room. Please try again.");
            }
        });
    };
    $scope.RoomTypeList = [];
    $scope.ClearForm = function () {
        $scope.RoomId= 0;
        $scope.CompanyId = 0;
        $scope.PageTitle = "Add Room";
        $scope.RoomName = "";
        $scope.RoomDesc = "";
        $scope.RoomBeds = 0;
        $scope.RoomPrice = 0;
        $scope.RoomStatusId = 0;
        $scope.Locationid = 0;
        $scope.$apply();
    }

    $scope.GetRoom = function () {
        const params = new URLSearchParams(window.location.search);
        const RoomId = params.get("RoomId");
        $scope.PageTitle = "Edit Room";
        if (typeof RoomId !== "undefined" && RoomId !== null) {
            var RoomObj = new Object();
            RoomObj.RoomId = RoomId;
            var RoomJson = JSON.stringify(RoomObj);
            $.ajax({
                type: "POST",
                url: "Room.aspx/GetRoomByRoomId",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: RoomJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.RoomId = items.d.RoomId;
                    $scope.Locationid = items.d.Locationid;
                    $scope.PageTitle = items.d.RoomId + " - " + items.d.RoomName;
                    $scope.RoomName = items.d.RoomName;
                    $scope.EmployeeName = items.d.EmployeeName;
                    $scope.RoomDesc = items.d.RoomDesc;
                    $scope.RoomBeds = items.d.RoomBeds;
                    $scope.RoomPrice = items.d.RoomPrice;
                    $scope.RoomStatusId = items.d.RoomStatusId;
                    $scope.CompanyId = items.d.CompanyId;
                    $scope.$apply();
                } else {
                    alert("There was some error in loading Room. Please try again.");
                }
            });
        }
    };

    $scope.CompanyList = [];
    $scope.GetAllCompanies = function () {
        $.ajax({
            type: "POST",
            url: "Guest.aspx/GetAllCompanies",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.CompanyList = items.d;
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    };

    $scope.RoomStatusList = [];
    $scope.GetRoomStatusMaster = function () {
        $.ajax({
            type: "POST",
            url: "Room.aspx/GetAllRoomStatusMaster",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.RoomStatusList = items.d;
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    };
    $scope.LocationsList = [];
    $scope.GetAllLocations = function () {
        $.ajax({
            type: "POST",
            url: "Room.aspx/GetAllLocations",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.LocationsList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
                alert("There was some error in loading locations. Please try again.");
            }

        });
    };
    //$scope.GetAllCompanies();
    $scope.GetRoomStatusMaster();
    $scope.GetAllLocations();
    const params = new URLSearchParams(window.location.search);
    const RoomId = params.get("RoomId");
    if (RoomId != null) {
        $scope.GetRoom();
    }
    $scope.GoBack = function () {
        var url = "/RoomList.aspx";
        window.location = url;
    }
});