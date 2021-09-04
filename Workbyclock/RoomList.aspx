<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="Workbyclock.RoomList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
         <div class="row" ng-app="RoomListApp" ng-controller="RoomListCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Room</h3>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;">
                            <button type="button" class="btn btn-success" onclick=" window.open('/Room.aspx','_blank')"><i class="fa fa-folder-open-o"></i>Add Room</button>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>Room Name</th>
                                    <th>Room Desc</th>
                                    <th>No of Beds</th>
                                    <th>Room Price</th>
                                    <th>Room Status</th>
                                    <th>Company</th>
                                    <th>Location</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody id="tbdRoomList">
                                <tr ng-repeat="x in RoomList" style="vertical-align:middle;"
                                    ng-class="{'success':x.RoomStatusId == 1, 'danger': x.RoomStatusId == 2, 'warning': x.RoomStatusId == 3 }">
                                    <td style="vertical-align:middle;" >{{x.RoomName}}</td>
                                    <td style="vertical-align:middle;">{{x.RoomDesc}}</td>
                                    <td style="vertical-align:middle;">{{x.RoomBeds}}</td>
                                    <td style="vertical-align:middle;">{{x.RoomPrice}}</td>
                                    <td style="vertical-align:middle;">{{x.RoomStatusName}}
                                        <%--<span ng-class="{'label-success': (x.RoomStatusId == '1') , 'label-danger': (x.RoomStatusId == 2) , 'label-danger': x.RoomStatusId == 3}">
                                        </span>--%>
                                    </td>
                                    <td style="vertical-align:middle;">{{x.CompanyName}}</td>
                                    <td style="vertical-align:middle;">{{x.LocationName}}</td>
                                    <td style="vertical-align:middle;text-align:center">
                                        <a href="Room.aspx?RoomId={{x.RoomId}}" class="btn btn-success">Edit</a>
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
    <script src="custom/RoomList.js"></script>
</asp:Content>
