var app = angular.module("AddBookingPaymentApp", []);
app.controller("AddBookingPaymentCtrl", function ($scope) {

    $scope.BookingPaymentId = 0;
    $scope.BookingId = 0;
    $scope.PaymentTypeId = 0;
    $scope.PaymentAmount = 0;
    $scope.PaymentAcceptedBy = "";
    $scope.PageTitle = "Add Booking Payment";

    $scope.IsPaymentSummaryShow = true;
    $scope.PaymentTax = 13.5;
    $scope.Total = 0;

    $scope.AmountPaid = 0;

    $scope.BookingTypeId = 0;


    $scope.SaveBookingPayments = function () {
        
        if ($scope.PaymentTypeId == undefined || $scope.PaymentTypeId == 0) {
            alert("Please select payment type")
            return;
        }
        var BookingPaymentsObj = new Object();
        BookingPaymentsObj.BookingPaymentId = $scope.BookingPaymentId;
        BookingPaymentsObj.BookingId = $scope.BookingId;
        BookingPaymentsObj.PaymentTypeId = $scope.PaymentTypeId;
        BookingPaymentsObj.PaymentAmount = $scope.PaymentAmount + $scope.AmountPaid;
        BookingPaymentsObj.PaymentAcceptedBy = $scope.PaymentAcceptedBy;

        var BookingPaymentsJson = JSON.stringify(BookingPaymentsObj);
        $.ajax({
            type: "POST",
            url: "BookingPayment.aspx/SaveBookingPayments",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: BookingPaymentsJson
        }).done(function (items) {
            if (items.d > 0) {
                if ($scope.RoomId == 0) {
                    var r = confirm("Booking Payment was saved successfully. Would you like to add another Booking Payment? ");
                    if (r == true) {
                        $scope.ClearForm();
                    } else {
                        var url = "/BookingPayment.aspx";
                        window.open(url, '_self');
                    }
                } else {
                    alert("Booking Payment was saved successfully.");
                    var url = "/BookingPaymentList.aspx";
                    window.open(url, '_self');
                }
            } else {
                alert("There was some error in creating Room. Please try again.");
            }
        });
    };

    $scope.ClearForm = function () {
        $scope.BookingPaymentId = 0;
        $scope.BookingId = 0;
        $scope.PaymentTypeId = 0;
        $scope.PaymentAmount = 0;
        $scope.PaymentAcceptedBy = "";
        $scope.PageTitle = "Add Booking Payment";
        $scope.$apply();
    }

    $scope.GetBookingPayments = function () {
        
        const params = new URLSearchParams(window.location.search);
        const BookingPaymentId = params.get("BookingId");
        $scope.PageTitle = "Edit Booking Payment";
        if (typeof BookingPaymentId !== "undefined" && BookingPaymentId !== null) {
            var BookingPaymentsObj = new Object();
            BookingPaymentsObj.bookingId = BookingPaymentId;
            var BookingPaymentsJson = JSON.stringify(BookingPaymentsObj);
            $.ajax({
                type: "POST",
                url: "BookingPayment.aspx/GetAllBookingPayments",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: BookingPaymentsJson
            }).done(function (items) {
                if (items.d != null) {
                    
                    //$scope.BookingPaymentId = items.d.BookingPaymentId;
                    //$scope.BookingId = items.d.BookingId;
                    //$scope.PageTitle = items.d.BookingPaymentId;
                    //$scope.PaymentTypeId = items.d.PaymentTypeId;
                    //$scope.PaymentAmount = items.d.PaymentAmount;
                    $scope.AmountPaid = items.d[0].PaymentAmount;
                    $scope.PaymentAcceptedBy = items.d[0].PaymentAcceptedBy;
                    $scope.$apply();
                } else {
                    alert("There was some error in loading Room. Please try again.");
                }
            });
        }
    };

    $scope.PaymentTypesList = [];
    $scope.GetAllPaymentTypes = function () {
        $.ajax({
            type: "POST",
            url: "BookingPayment.aspx/GetAllPaymentTypes",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.PaymentTypesList = items.d;
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    };

    $scope.GetAllPaymentTypes();

    const params = new URLSearchParams(window.location.search);
    const BookingPaymentId = params.get("BookingId");
    if (BookingPaymentId != null) {
        $scope.GetBookingPayments();
    }




    $scope.GetRoomBookingById = function () {
        const params = new URLSearchParams(window.location.search);
        const RoomBookingId = params.get("BookingId");
        if (typeof RoomBookingId !== "undefined" && RoomBookingId !== null) {
            var BookingObj = new Object();
            BookingObj.RoomBookingId = RoomBookingId;
            var BookingJson = JSON.stringify(BookingObj);
            $.ajax({
                type: "POST",
                url: "RoomBooking.aspx/GetRoomBookingByRoomBookingId",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: BookingJson
            }).done(function (items) {
                if (items.d != null) {
                    
                    $scope.RoomBookingId = items.d.RoomBookingId;
                    $scope.BookingTypeId = items.d.BookingTypeId;
                    if (items.d.BookingTypeId == 7) {
                        $scope.PaymentTax = 0;
                    }

                    $scope.Price = items.d.Price;
                    $scope.Total = $scope.Price + ($scope.Price * $scope.PaymentTax) / 100;
                    $scope.RoomName = items.d.RoomName;

                    $scope.PaymentAmount = $scope.Total - $scope.AmountPaid;

                    $scope.$apply();

                } else {
                    alert("There was some error in loading Booking. Please try again.");
                }
            });
        }
    };



    const paramsByBookingId = new URLSearchParams(window.location.search);
    const BookingId = paramsByBookingId.get("BookingId");
    if (BookingId != null) {
        $scope.BookingId = BookingId;
        $scope.GetRoomBookingById();
    }

    $scope.GoBack = function () {
        var url = "/BookingPaymentList.aspx";
        window.location = url;
    }
});