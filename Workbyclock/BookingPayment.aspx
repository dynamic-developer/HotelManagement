<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="BookingPayment.aspx.cs" Inherits="Workbyclock.BookingPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="AddBookingPaymentApp" ng-controller="AddBookingPaymentCtrl">
        <div class="col-md-12">
            <div class="panel panel-defaut">
                <div class="panel-heading">
                    <h3 class="panel-title">{{PageTitle}}</h3>
                </div>
                <div class="panel-body">
                    <form action="#" name="BookingPayment" novalidate>
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Payment Type</label>
                                        <select class="form-control" ng-model="PaymentTypeId">
                                            <option ng-value="0">-- Select Payment Type --</option>
                                            <option ng-repeat="option in PaymentTypesList" ng-value="{{option.PaymentTypeId}}">{{option.PaymentTypeName}}</option>
                                        </select>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Payment Amount</label>
                                        <input type="number" class="form-control" name="RoomBeds" ng-model="PaymentAmount" placeholder="Payment Amount" required />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Payment Accepted By</label>
                                        <input type="text" class="form-control" name="PaymentAcceptedBy" ng-model="PaymentAcceptedBy" placeholder="Payment Accepted By" required />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Paid Amount</label>
                                        <input type="number" disabled="disabled" class="form-control" name="AmountPaid" ng-model="AmountPaid" placeholder="Paid Amount" required />
                                    </div>
                                </div>
                            </div>
                             
                        </div>
                        <div class="form-actions">
                            <button type="submit" class="btn btn-success" ng-click="SaveBookingPayments()"><i class="fa fa-check"></i>Save</button>
                            <button type="button" class="btn btn-danger" ng-click="GoBack()">Cancel</button>
                        </div>
                    </form>
                </div>

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
                                                <td><strong>Room Type</strong></td>
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
    <script src="custom/BookingPayments.js"></script>
</asp:Content>
