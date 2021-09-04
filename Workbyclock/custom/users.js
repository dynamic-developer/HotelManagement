var app = angular.module("UsersApp", []).controller("UsersCtrl", ['$scope', function ($scope) {

    $scope.UsersList = [];


    $scope.GetAllUsers = function () {
        $.ajax({
            type: "POST",
            url: "Users.aspx/GetAllUsers",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.UsersList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
                alert("There was some error in loading Users. Please try again.");
            }

        });
    };

    $scope.GetAllUsers();
}
]);