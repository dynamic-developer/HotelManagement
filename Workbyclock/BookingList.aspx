<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="BookingList.aspx.cs" Inherits="Workbyclock.BookingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
     <div class="row" ng-app="BookingListApp" ng-controller="BookingListCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Reservation</h3>
                    <br />
                    <div class="row" style="padding: 10px 10px 10px 10px; border: double; border-width: 3px; vertical-align: middle;">
                        <div class="col-lg-12" style="text-align: left;" id="Div1">
                            <div class="row">
                                <div class="col-lg-3">
                                    <label><b>From Date</b></label>
                                    <input type="datetime-local" class="form-control" ng-model="FromDate" id="dtStart" placeholder="01/01/1979"  required />
                                </div>
                                <div class="col-lg-3">
                                    <label><b>To Date</b></label>
                                    <input type="datetime-local" class="form-control" ng-model="ToDate" id="dtEnd" placeholder="01/01/1979" required />
                                </div>
                                <div class="col-lg-2" style="vertical-align: middle;padding-top:17px;">
                                    <button class="btn btn-primary" ng-click="SearchReservationByDateCriteria()" type="button">Search</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;">
                            <button type="button" class="btn btn-success" onclick=" window.open('/RoomBooking.aspx','_blank')"><i class="fa fa-folder-open-o"></i>Add Reservation</button>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>Room Name</th>
                                    <th>Guest Name</th>
                                    <th>Price</th>
                                    <th>Check-In</th>
                                    <th>Checked-Out</th>
                                    <th>Booking Type</th>
                                    <th>Booking Date</th>
                                    <th>Company Name</th>
                                    <th>Location Name</th>
                                    <th>Reservation Status</th>
                                    <th>Payment</th>
                                    <th>Create Date</th>
                                    <th>Action(s)</th>
                                    <th>Payment</th>
                                </tr>
                            </thead>
                            <tfoot>
                               
                            </tfoot>
                            <tbody id="tbdGuestList">
                                <tr ng-repeat="x in BookingList" style="vertical-align:middle;">
                                    <td style="vertical-align:middle;">{{x.RoomName}}</td>
                                    <td style="vertical-align:middle;">{{x.GuestName}}</td>
                                    <td style="vertical-align:middle;width:8%">$ {{x.Price}}</td>
                                    <td style="vertical-align:middle;">{{formatDate(x.FromDate) | date:'MM/dd/yyyy h:mma'}}</td>
                                    <td style="vertical-align:middle;">{{formatDate(x.ToDate) | date:'MM/dd/yyyy h:mma'}}</td>
                                    <td style="vertical-align:middle;">{{x.BookingTypeName}}</td>
                                    <td style="vertical-align:middle;">{{formatDate(x.BookingDate) | date:'MM/dd/yyyy h:mma'}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyName}}</td>
                                    <td style="vertical-align:middle;">{{x.LocationName}}</td>
                                    <td style="vertical-align:middle;">
                                        <span ng-class="{'label label-primary': x.RoomBookingStatusId == 1 || x.RoomBookingStatusId == 2 , 
                                            'label label-danger': x.RoomBookingStatusId == 3 || x.RoomBookingStatusId == 6 ,
                                            'label label-success': x.RoomBookingStatusId == 4 || x.RoomBookingStatusId == 5}">
                                            {{x.RoomBookingStatusName}}
                                        </span>
                                    </td>
                                    <td style="vertical-align:middle;" >
                                        
                                        <span ng-class="{'label label-danger': x.BookingPaymentId == null}" ng-show="x.BookingPaymentId == null">
                                            $ {{x.PaymentAmount == null ? 0 : x.PaymentAmount}}
                                        </span>

                                        <span ng-class="{'label label-primary': {{priceCalculation(x.PaymentAmount,x.Price)}} , 'label label-warning': {{priceCalculationTrue(x.PaymentAmount,x.Price)}} }" ng-show="x.BookingPaymentId != null">
                                            $ {{x.PaymentAmount == null ? 0 : x.PaymentAmount}}
                                        </span>
                                    </td>
                                    <td style="vertical-align:middle;">{{formatDate(x.CreateDate) | date:'MM/dd/yyyy'}}</td>
                                    <td style="vertical-align:middle;text-align:center;width: 1%">
                                        <a href="RoomBooking.aspx?RoomBookingId={{x.RoomBookingId}}" class="btn btn-success">Edit</a>
                                    </td>
                                    <td style="vertical-align:middle;text-align:center;width: 1%" ng-show="x.BookingPaymentId != null">
                                        <a href="BookingPaymentList.aspx?RoomBookingId={{x.RoomBookingId}}" class="btn btn-success">View Payment</a>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
    <script src="custom/BookingList.js"></script>
</asp:Content>
