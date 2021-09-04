var app = angular.module("locationsApp", []).controller("locationsCtrl", ['$scope', function ($scope) {

    $scope.LocationsList = [];


    $scope.GetAllLocations = function () {
        $.ajax({
            type: "POST",
            url: "Locations.aspx/GetAllLocations",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
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

    $scope.GetAllLocations();
}
]);