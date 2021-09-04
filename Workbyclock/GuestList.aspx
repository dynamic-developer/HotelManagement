<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="GuestList.aspx.cs" Inherits="Workbyclock.GuestList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
      <div class="row" ng-app="GuestListApp" ng-controller="GuestListCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Guests</h3>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;">
                            <button type="button" class="btn btn-success" onclick=" window.open('/Guest.aspx','_blank')"><i class="fa fa-folder-open-o"></i>Add Guest</button>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>Guest Name</th>
                                    <th>Guest Phone</th>
                                    <th>Guest Email</th>
                                    <th>Guest Address</th>
                                    <th>Guest Driver License Id</th>
                                    <th>Company Name</th>
                                    <th>Is DNR</th>
                                    <th style="vertical-align:middle;text-align:center">Action(s)</th>
                                </tr>
                            </thead>
                            <tbody id="tbdGuestList">
                                <tr ng-repeat="x in GuestList" ng-model="GuestList" style="vertical-align:middle;">
                                    <td style="vertical-align:middle;" >{{x.GuestFullName}}</td>
                                    <td style="vertical-align:middle;">{{x.GuestPhone}}</td>
                                    <td style="vertical-align:middle;">{{x.GuestEmail}}</td>
                                    <td style="vertical-align:middle;">{{x.GuestAddress}}</td>
                                    <td style="vertical-align:middle;">{{x.GuestDriverLicenseId}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyName}}</td>
                                    <td style="vertical-align:middle;"><input type="checkbox" ng-checked="{{x.IsDNR}}"/></td>
                                    <td >
                                        <a href="Guest.aspx?GuestId={{x.GuestId}}" class="btn btn-success">Edit</a> &nbsp; 
                                        <button type="button" ng-click="DeleteGuest(x.GuestId)" class="btn btn-danger">Delete</button>
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
    <script src="custom/GuestList.js"></script>
</asp:Content>
