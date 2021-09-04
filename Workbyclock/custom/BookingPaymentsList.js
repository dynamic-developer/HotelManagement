var app = angular.module("BookingPaymentsListApp", []).controller("BookingPaymentsListCtrl", ['$scope', function ($scope) {

    $scope.BookingPaymentsList = [];
    $scope.RoomBookingId = 0;

    $scope.FromDate = "";
    $scope.ToDate = "";

    $scope.GetAllBookingPayments = function (RoomBookingId) {
        var BookingObj = new Object();
        BookingObj.bookingId = RoomBookingId;
        var BookingJson = JSON.stringify(BookingObj);

        $.ajax({
            type: "POST",
            url: "BookingPayment.aspx/GetAllBookingPayments",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: BookingJson
        }).done(function (items) {
            if (items.d != null && items.d.length > 0) {
                $scope.BookingPaymentsList = items.d;
                $scope.$apply();
            }
            $('.datatable').DataTable({
                "pageLength": 50
            });
        });
    };



    const params = new URLSearchParams(window.location.search);
    const RoomBookingId = params.get("RoomBookingId");
    if (RoomBookingId != null && RoomBookingId != undefined && RoomBookingId != "") {
        $scope.RoomBookingId = RoomBookingId;
        $scope.GetAllBookingPayments($scope.RoomBookingId);
    }
    else {
        $scope.GetAllBookingPayments($scope.RoomBookingId);
    }

    $scope.formatDate = function (date) {
        var dateOut = new Date(parseInt(date.substr(6)));
        return dateOut;
    };


    $scope.SearchBookingPaymentByDateCriteria = function () {
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
            url: "BookingPaymentList.aspx/GetAllBookingPaymentByFilter",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: BookingJson
        }).done(function (items) {

            if (items.d != null && items.d.length > 0) {
                $('.dataTables_empty').hide();

                $scope.BookingPaymentsList = items.d;
                $scope.$apply();
                $('.datatable').DataTable();
            } else {
                $scope.BookingPaymentsList = [];
                var table = $('.datatable').DataTable();
                table.clear().draw();
            }
        });
    }

}
]);