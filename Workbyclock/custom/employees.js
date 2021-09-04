var app = angular.module("EmployeesApp", []).controller("EmployeesCtrl", ['$scope', function ($scope) {

    $scope.EmployeesList = [];


    $scope.GetAllEmployees = function () {
        $.ajax({
            type: "POST",
            url: "Employees.aspx/GetAllEmployees",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.EmployeesList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
                alert("There was some error in loading Employees. Please try again.");
            }

        });
    };

    $scope.GetAllEmployees();
}
]);