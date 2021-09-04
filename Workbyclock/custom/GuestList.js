var app = angular.module("GuestListApp", []).controller("GuestListCtrl", ['$scope', function ($scope) {

    $scope.GuestList = [];
    $scope.GetAllGuest = function () {
        $.ajax({
            type: "POST",
            url: "GuestList.aspx/GetAllGuest",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.GuestList = items.d;
                $scope.$apply();
                $('.datatable').DataTable({
                    "pageLength": 50
                });
            } else {
                alert("There was some error in loading Guest. Please try again.");
            }
        });
    };
    $scope.GetAllGuest();


   

    $scope.DeleteGuest = function (guestId) {
        var GuestObj = new Object();
        GuestObj.guestId = guestId;
        var GuestJson = JSON.stringify(GuestObj);
        var r = confirm("are you sure want to delete guest?");
        if (r == true) {
            $.ajax({
                type: "POST",
                url: "Guest.aspx/DeleteGuest",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: GuestJson
            }).done(function (items) {
                if (items.d != null && items.d > 0) {
                    alert("Guest deleted successfully!");
                    window.location.reload();
                } 
            });
        };
    }
}
]);