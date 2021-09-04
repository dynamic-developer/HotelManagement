var app = angular.module("AddBookingApp", []);
app.controller("AddBookingCtrl", function ($scope) {
    $scope.RoomBookingId = 0;
    $scope.RoomId = 0;
    $scope.Price = 0;
    $scope.FromDate = "";
    $scope.ToDate = "";
    $scope.PageTitle = "Add Room Booking";
    $scope.BookingTypeId = 0;
    $scope.BookingDate = "";
    $scope.CreateDate = 0;
    $scope.CompanyId = 0;
    $scope.LocationId = 0;
    $scope.GuestId = 0;
    $scope.RoomBookingStatusId = 1; //Confirmed
    $scope.Isdisabled = true;
    $scope.IsSaveButtonDisabled = true;
    $scope.IsDisabledGuestOrRoomAvailabilityButton = true;

    //Payment 
    $scope.IsPaymentSummaryShow = false;
    $scope.PaymentTax = 13.5;
    $scope.Total = 0;


    $scope.SaveBooking = function () {
        var BookingObj = new Object();
        BookingObj.RoomBookingId = $scope.RoomBookingId;
        BookingObj.RoomId = $scope.RoomId;
        BookingObj.GuestId = $scope.GuestId;
        BookingObj.Price = $scope.Price;
        BookingObj.FromDate = $scope.FromDate;
        BookingObj.ToDate = $scope.ToDate;
        BookingObj.BookingTypeId = $scope.BookingTypeId;
        BookingObj.BookingDate = $scope.BookingDate;
        BookingObj.CompanyId = $scope.CompanyId;
        BookingObj.LocationId = $scope.LocationId;
        BookingObj.RoomBookingStatusId = $scope.RoomBookingStatusId;
        var BookingJson = JSON.stringify(BookingObj);

        var result = CheckDateValidation(BookingObj.FromDate, BookingObj.ToDate);
        if (result) {
            $.ajax({
                type: "POST",
                url: "RoomBooking.aspx/SaveRoomBooking",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: BookingJson
            }).done(function (items) {
                if (items.d > 0) {
                    if ($scope.RoomBookingId == 0) {
                        var r = confirm("RoomBooking was saved successfully. Would you like to add another Room Booking? ");
                        if (r == true) {
                            $scope.ClearForm();
                        } else {
                            var url = "/BookingList.aspx";
                            window.open(url, '_self');
                        }
                    } else {
                        alert("RoomBooking was saved successfully.");
                    }
                } else {
                    alert("There was some error in creating RoomBooking. Please try again.");
                }

            });
        }

    };

    $scope.ClearForm = function () {

        $scope.RoomBookingId = 0;
        $scope.RoomId = 0;
        $scope.Price = 0;
        $scope.FromDate = "";
        $scope.PageTitle = "Add Room Booking";
        $scope.BookingTypeId = 0;
        $scope.BookingDate = "";
        $scope.CreateDate = 0;
        $scope.CompanyId = 0;
        $scope.LocationId = 0;
        $scope.RoomBookingStatusId = 1;
        $scope.$apply();
    }

    $scope.RoomBookingStatusList = [];
    $scope.BindRoomBookingStatusList = function () {
        $.ajax({
            type: "POST",
            url: "RoomBooking.aspx/GetAllRoomBookingStatusMaster",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.RoomBookingStatusList = items.d;
                if ($scope.RoomBookingId == 0) {
                    $scope.RoomBookingStatusId = 1;
                }
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    }
    $scope.BindRoomBookingStatusList();

    $scope.RoomList = [];
    $scope.BindRoomList = function () {
        $.ajax({
            type: "POST",
            url: "Room.aspx/GetAllRoom",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.RoomList = items.d;
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    }
    $scope.BindRoomList();

    $scope.GuestList = [];
    $scope.guestName = [];

    $scope.BindGuestList = function () {
        $.ajax({
            type: "POST",
            url: "GuestList.aspx/GetAllGuest",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.GuestList = items.d;
                angular.forEach($scope.GuestList, function (country) {
                    $scope.guestName.push(country.GuestFullName);
                });
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }

        });
    }
    $scope.BindGuestList();

    $scope.complete = function (string) {
        var output = [];
        angular.forEach($scope.GuestList, function (searchTerm) {
            if (searchTerm.GuestFullName.toLowerCase().indexOf(string.toLowerCase()) >= 0 || searchTerm.GuestPhone.toLowerCase().indexOf(string.toLowerCase()) >= 0) {
                output.push(searchTerm);
            }
        });
        $scope.filterGuest = output;
    }
    $scope.fillTextbox = function (obj) {
        $scope.GuestNameWithPhoneNumber = obj.GuestFullName + " - (" + obj.GuestPhone + ")";
        $scope.GuestId = obj.GuestId
        $scope.filterGuest = null;
    }

    $scope.getRoomDetailByID = function () {
        const RoomId = $scope.RoomId
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
                $scope.Price = items.d.RoomPrice;

                $scope.PaymentTax = 13.5;
                $scope.Total = $scope.Price + ($scope.Price * $scope.PaymentTax) / 100;

                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    }

    $scope.BookingTypeList = [];
    $scope.BindBookingTypeList = function () {
        $.ajax({
            type: "POST",
            url: "RoomBooking.aspx/GetAllBookingType",
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        }).done(function (items) {
            if (items.d != null) {
                $scope.BookingTypeList = items.d;
                $scope.$apply();
            } else {
                alert("There was some error in loading Companies. Please try again.");
            }
        });
    }
    $scope.BindBookingTypeList();

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
    $scope.GetAllLocations();

    $scope.GoBack = function () {
        var url = "/BookingList.aspx";
        window.location = url;
    }
    function CheckDateValidation(startDate, endDate) {
        if (new Date(startDate) > new Date(endDate)) {
            alert('To Date should be greater than From date');
            return false;
        }
        else {
            return true;
        }
    };

    $scope.GetRoomBookingById = function () {
        const params = new URLSearchParams(window.location.search);
        const RoomBookingId = params.get("RoomBookingId");
        if (typeof RoomBookingId !== "undefined" && RoomBookingId !== null) {

            $scope.PageTitle = "Edit Room Booking"
            $scope.IsDisabledGuestOrRoomAvailabilityButton = false;
            $scope.IsSaveButtonDisabled = false;
            $scope.IsPaymentSummaryShow = true;

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
                    $scope.GuestId = items.d.GuestId;
                    $scope.RoomId = items.d.RoomId;
                    $scope.Price = items.d.Price;
                    if (items.d.FromDate !== null) {
                        $scope.FromDate = new Date(parseInt(items.d.FromDate.substr(6)));
                    }
                    if (items.d.ToDate !== null) {
                        $scope.ToDate = new Date(parseInt(items.d.ToDate.substr(6)));
                    }
                    
                    $scope.BookingTypeId = items.d.BookingTypeId;
                    if (items.d.BookingDate !== null) {
                        $scope.BookingDate = new Date(parseInt(items.d.BookingDate.substr(6)));
                    }
                    $scope.RoomBookingStatusId = items.d.RoomBookingStatusId;
                    $scope.CompanyId = items.d.CompanyId;
                    $scope.LocationId = items.d.LocationId;
                    $scope.GuestNameWithPhoneNumber = items.d.GuestName + " - (" + items.d.GuestPhone + ")";

                    $scope.RoomName = items.d.RoomName;

                    //7 - Monthly
                    if (items.d.BookingTypeId == 7) { 
                        $scope.PaymentTax = 0;
                    }
                    $scope.Total = $scope.Price + ($scope.Price * $scope.PaymentTax) / 100;

                    $scope.Isdisabled = false;
                    $scope.$apply();

                } else {
                    alert("There was some error in loading Booking. Please try again.");
                }
            });
        }
    };

    const params = new URLSearchParams(window.location.search);
    const RoomBookingId = params.get("RoomBookingId");
    if (RoomBookingId != null && RoomBookingId != undefined && RoomBookingId != "") {
        $scope.GetRoomBookingById();
    }


    $scope.CheckRoomAvailability = function () {
        var BookingObj = new Object();
        BookingObj.FromDate = $scope.FromDate;
        BookingObj.ToDate = $scope.ToDate;
        var BookingJson = JSON.stringify(BookingObj);
        var result = CheckDateValidation(BookingObj.FromDate, BookingObj.ToDate);
        if (result) {
            $.ajax({
                type: "POST",
                url: "RoomBooking.aspx/CheckRoomAvailability",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: BookingJson
            }).done(function (items) {
                if (items.d != null) {
                    $scope.RoomList = items.d;
                    $scope.$apply();
                    $scope.IsSaveButtonDisabled = false;
                } else {
                    alert("There was some error in loading Companies. Please try again.");
                }
            });
        }

    }
    $scope.onBookingTypeChange = function (bookingtypeID) {
        if (bookingtypeID == 7) {
            $scope.PaymentTax = 0;
            $scope.Total = $scope.Price;
        }
        else {
            $scope.PaymentTax = 13.5;
            $scope.Total = $scope.Price + ($scope.Price * $scope.PaymentTax) / 100;
        }
    }
    $scope.TotalPriceChange = function () {
        if ($scope.BookingTypeId == 7) {
            $scope.PaymentTax = 0;
            $scope.Total = $scope.Price;
        }
        else {
            $scope.PaymentTax = 13.5;
            $scope.Total = $scope.Price + ($scope.Price * $scope.PaymentTax) / 100;
        }
    }
    $scope.AddPaymentRedirect = function () {
        var url = "BookingPayment.aspx?BookingId=" + $scope.RoomBookingId;
        window.location = url;
    }
});