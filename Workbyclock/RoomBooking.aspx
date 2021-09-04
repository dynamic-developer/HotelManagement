<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="RoomBooking.aspx.cs" Inherits="Workbyclock.RoomBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
    <style type="text/css">
        .list-group-item:hover {
            /*color: #337ab7;*/
            text-shadow: 0 0 1em #337ab7;
            cursor: pointer;
            background: #333;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="AddBookingApp" ng-controller="AddBookingCtrl">
        <div class="col-md-12">
            <div class="panel panel-defaut">
                <div class="panel-heading">
                    <h3 class="panel-title">{{PageTitle}}</h3>
                </div>
                <div class="panel-body">
                    <form action="#" name="RoomBooking" novalidate>
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Check-In</label>
                                        <input type="date" class="form-control"
                                            ng-model="FromDate" value="FromDate"
                                            placeholder="FromDate" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Check-Out</label>
                                        <input type="date" class="form-control"
                                            ng-model="ToDate" value="ToDate"
                                            placeholder="ToDate" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <div class="col-lg-12" ng-show="IsDisabledGuestOrRoomAvailabilityButton">
                                            <button type="button" ng-click="CheckRoomAvailability()" class="btn btn-success"><i class="fa fa-user"></i>Check Room Availability</button>
                                        </div>
                                        <label class="control-label">Room</label>
                                        <select class="form-control" ng-model="RoomId" ng-change="getRoomDetailByID()">
                                            <option ng-value="0">-- Select Room --</option>
                                            <option ng-repeat="option in RoomList" ng-value="{{option.RoomId}}">{{option.RoomName}}</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <div class="col-lg-12" style="text-align: right;" ng-show="IsDisabledGuestOrRoomAvailabilityButton">
                                            <button type="button" class="btn btn-success" onclick=" window.open('/Guest.aspx','_blank')"><i class="fa fa-user"></i>Add New Guest</button>
                                        </div>
                                        <label class="control-label">Guest Name</label>
                                        <input type="text" name="country" id="country" ng-model="GuestNameWithPhoneNumber"
                                            ng-keyup="complete(GuestNameWithPhoneNumber)" class="form-control" placeholder="Enter Guest Name or Phone No." />
                                        <ul class="list-group" style="position: ; z-index: 999; position: absolute; width: 95%;">
                                            <li class="list-group-item" ng-repeat="guestData in filterGuest"
                                                ng-click="fillTextbox(guestData)">{{guestData.GuestFullName}} - ({{guestData.GuestPhone}})</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Price</label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                            <input type="number" class="form-control" ng-change="TotalPriceChange()" ng-model="Price"
                                                placeholder="Price" />
                                        </div>
                                    </div>
                                </div>


                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Booking Type</label>
                                        <select class="form-control" ng-model="BookingTypeId" ng-change="onBookingTypeChange(BookingTypeId)">
                                            <option ng-value="0">-- Select Booking Type --</option>
                                            <option ng-repeat="option in BookingTypeList" ng-value="{{option.BookingTypeId}}">{{option.BookingTypeName}}</option>
                                        </select>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <%--<div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Company</label>
                                    <select class="form-control" ng-model="CompanyId">
                                        <option ng-value="">-- Select Company --</option>
                                        <option ng-repeat="option in CompanyList" value="{{option.CompanyId}}">{{option.CompanyName}}</option>
                                    </select>

                                </div>
                            </div>--%>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Reservation Status</label>
                                        <select class="form-control" ng-model="RoomBookingStatusId" ng-disabled="Isdisabled">
                                            <option ng-value="0">-- Select Reservation Status --</option>
                                            <option ng-repeat="option in RoomBookingStatusList" ng-value="{{option.RoomBookingStatusId}}">{{option.RoomBookingStatusName}}</option>
                                        </select>

                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Location</label>
                                        <select class="form-control" ng-model="LocationId">
                                            <option ng-value="0">-- Select Location --</option>
                                            <option ng-repeat="option in LocationsList" ng-value="{{option.LocationId}}">{{option.LocationName}}</option>
                                        </select>

                                    </div>
                                </div>

                            </div>
                            <div class="form-actions">
                                <button type="submit" class="btn btn-success" ng-disabled="IsSaveButtonDisabled" ng-click="SaveBooking()"><i class="fa fa-check"></i>Save</button>
                                <button type="button" class="btn btn-danger" ng-click="GoBack()">Cancel</button>
                            </div>
                        </div>
                    </form>
                    <hr style="border: 1px solid darkgray;" />
                    <div class="row" ng-show="IsPaymentSummaryShow">
                        <div class="col-md-6" style="float: right;">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title csk" style="font-size: 20px;">
                                        <strong>Payment summary</strong>
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <table class="table table-condensed table-striped">
                                            <thead>
                                                <tr>
                                                    <td><strong>Room Name</strong></td>
                                                    <td class="text-center"><strong>Room Price</strong></td>
                                                    <td class="text-right"><strong>Totals</strong></td>
                                                </tr>
                                            </thead>
                                            <tbody class="csk1">
                                                <tr>
                                                    <td>{{RoomName}}</td>
                                                    <td class="text-center">${{Price}}</td>
                                                    <td class="text-right">${{Price}}</td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td class="text-center"><strong>Subtotal</strong></td>
                                                    <td class="thick-line text-right">${{Price}}</td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td class=" text-center"><strong>Tax (%)</strong></td>
                                                    <td class=" text-right">{{PaymentTax}} </td>
                                                </tr>
                                                <tr class="panel-footer">
                                                    <td></td>
                                                    <td class=" text-center"><strong>Total</strong></td>
                                                    <td class=" text-right">${{Total}}</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="form-actions" style="float: right;">
                                        <button type="button" class="btn btn-success" ng-click="AddPaymentRedirect()"><i class="fa fa-check"></i>Add Payment</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>






                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.2/jquery-ui.min.js"></script>
    <script src="custom/AddBooking.js"></script>
</asp:Content>
