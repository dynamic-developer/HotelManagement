var app = angular.module("BookingListApp", []).controller("BookingListCtrl", ['$scope', function ($scope) {

    $scope.BookingList = [];
    $scope.Tax = 13.5;
    $scope.TotalAmt = 0;

    $scope.FromDate = "";
    $scope.ToDate = "";

    $scope.GetAllBooking = function () {
        $.ajax({
            type: "POST",
            url: "RoomBooking.aspx/GetAllRoomBooking",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.BookingList = items.d;
                $scope.$apply();
            } 
            $('.datatable').DataTable({
                "pageLength": 50,
                destroy: true,
            });
        });
    };

    $scope.GetAllBooking();


    $scope.formatDate = function (date) {
        var dateOut = new Date(parseInt(date.substr(6)));
        return dateOut;
    };

    $scope.priceCalculation = function (PaymentAmount, Price) {
        if (PaymentAmount == null) {
            return 0;
        }
        else {
            var originalPrice = Price * 13.5 / 100;
            $scope.TotalAmt = PaymentAmount - originalPrice;
            PaymentAmount = PaymentAmount - originalPrice;
            if (PaymentAmount >= Price) {
                return true;
            }
            else {
                return false;
            }
        }
    };

    $scope.priceCalculationTrue = function (PaymentAmount, Price) {
        if (PaymentAmount == null) {
            return 0;
        }
        else {
            var originalPrice = Price * 13.5 / 100;
            $scope.TotalAmt = PaymentAmount - originalPrice;
            PaymentAmount = PaymentAmount - originalPrice;
            if (PaymentAmount <= Price) {
                return true;
            }
            else {
                return false;
            }
        }
    };


    $scope.SearchReservationByDateCriteria = function () {
        if ($scope.FromDate == "") {
            alert("Please select FromDate");
            return;
        }
        if ($scope.ToDate == "") {
            alert("Please select from ToDate");
            return;
        }

        var sdSt = "";
        var endSt = "";
        if (typeof $scope.FromDate !== "undefined" && $scope.FromDate !== null) {
            sdSt = $scope.FromDate.toLocaleString();
        }
        if (typeof $scope.ToDate !== "undefined" && $scope.ToDate !== null) {
            endSt = $scope.ToDate.toLocaleString();
        }

        var BookingObj = new Object();
        BookingObj.FromDate = sdSt;
        BookingObj.ToDate = endSt;
        var BookingJson = JSON.stringify(BookingObj);
        $.ajax({
            type: "POST",
            url: "BookingList.aspx/GetAllReservationByFilter",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: BookingJson
        }).done(function (items) {
            
            if (items.d != null && items.d.length > 0) {
                $('.dataTables_empty').hide();

                $scope.BookingList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
                $scope.BookingList = [];
                var table = $('.datatable').DataTable();
                table.clear().draw();
            }
        });
    }

}
]);
