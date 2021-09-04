<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="Workbyclock.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="AddRoomApp" ng-controller="AddRoomCtrl">
        <div class="col-md-12">
            <div class="panel panel-defaut">
                <div class="panel-heading">
                    <h3 class="panel-title">{{PageTitle}}</h3>
                </div>
                <div class="panel-body">
                    <form action="#" name="CreateFormRoom" novalidate>
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Room Name</label>
                                        <input type="text" class="form-control" name="RoomName" placeholder="Enter Room Name" ng-model="RoomName" required />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Room Desc</label>
                                        <input type="text" class="form-control" name="RoomDesc" ng-model="RoomDesc" placeholder="Enter Room Description" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Room Beds</label>
                                    <input type="number" class="form-control" name="RoomBeds" ng-model="RoomBeds" placeholder="Room Beds" required />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Room Status</label>
                                    <select class="form-control" name="RoomStatusId" ng-model="RoomStatusId" required>
                                        <option ng-value="0" selected="selected">-- Select Room Status --</option>
                                        <option ng-repeat="option in RoomStatusList" ng-value="{{option.StatusId}}">{{option.StatusName}}</option>
                                    </select>

                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <%-- <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Company</label>
                                    <select class="form-control" name="CompanyId" ng-model="CompanyId" required>
                                        <option ng-value="0" selected="selected">-- Select Company --</option>
                                        <option ng-repeat="option in CompanyList"  ng-value="{{option.CompanyId}}">{{option.CompanyName}}</option>
                                    </select>

                                </div>
                            </div>--%>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Price</label>
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-dollar"></i></span>
                                        <input type="number" class="form-control" ng-model="RoomPrice" placeholder="Room Price" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Location</label>
                                    <select class="form-control" name="Locationid" ng-model="Locationid" required>
                                        <option ng-value="0" selected="selected">-- Select Location --</option>
                                        <option ng-repeat="option in LocationsList" ng-value="{{option.LocationId}}">{{option.LocationName}}</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <div class="form-actions">
                            <button type="submit" ng-click="SaveRoom()" class="btn btn-success"><i class="fa fa-check"></i>Save</button>
                            <button type="button" ng-click="GoBack()" class="btn btn-danger">Cancel</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- #row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
    <script src="custom/AddRoom.js"></script>
</asp:Content>
