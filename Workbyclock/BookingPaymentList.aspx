<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="BookingPaymentList.aspx.cs" Inherits="Workbyclock.BookingPaymentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
     <div class="row" ng-app="BookingPaymentsListApp" ng-controller="BookingPaymentsListCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Booking Payment</h3>
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
                                    <button class="btn btn-primary" ng-click="SearchBookingPaymentByDateCriteria()" type="button">Search</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>Room Name</th>
                                    <th>Room Price</th>
                                    <th>Guest Name</th>
                                    <th>Payment Type</th>
                                    <th>Payment Amount</th>
                                    <th>Payment Date</th>
                                    <th>Payment Accepted By</th>
                                </tr>
                            </thead>
                            <tfoot>
                               
                            </tfoot>
                            <tbody id="tbdGuestList">
                                <tr ng-repeat="x in BookingPaymentsList" style="vertical-align:middle;">
                                    <td style="vertical-align:middle;" >{{x.RoomName}}</td>
                                    <td style="vertical-align:middle;" >$ {{x.RoomPrice}}</td>
                                    <td style="vertical-align:middle;" >{{x.GuestName}}</td>
                                    <td style="vertical-align:middle;" >{{x.PaymentTypeName}}</td>
                                    <td style="vertical-align:middle;">$ {{x.PaymentAmount}}</td>
                                    <td style="vertical-align:middle;">{{formatDate(x.PaymentDate) | date:'MM/dd/yyyy h:mma'}}</td>
                                    <td style="vertical-align:middle;">{{x.PaymentAcceptedBy}}</td>
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
    <script src="custom/BookingPaymentsList.js"></script>
</asp:Content>
