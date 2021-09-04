var app = angular.module("RoomListApp", []).controller("RoomListCtrl", ['$scope', function ($scope) {

    $scope.RoomList = [];


    $scope.GetAllRoom = function () {
        $.ajax({
            type: "POST",
            url: "Room.aspx/GetAllRoom",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.RoomList = items.d;
                $scope.$apply();
                $('.datatable').DataTable({
                    "pageLength": 50
                });
            }
            else if (items.d.length == 0) {
            }
            else {
                alert("There was some error in loading Room. Please try again.");
            }
        });
    };

    $scope.GetAllRoom();
}
]);