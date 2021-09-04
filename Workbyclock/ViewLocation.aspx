<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="ViewLocation.aspx.cs" Inherits="Workbyclock.ViewLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="locationApp" ng-controller="locationCtrl">
        <div class="col-md-12">
            <div class="panel panel-defaut">
                <div class="panel-heading">
                    <h3 class="panel-title">{{PageTitle}}</h3>
                </div>
                <div class="panel-body">
                    <form action="#">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Name :</label>
                                        <label><b>{{LocationName}}</b></label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Description :</label>
                                        <label><b>{{LocationDescription}}</b></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Phone</label>
                                    <label><b>{{LocationPhone}}</b></label>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Email</label>
                                    <label><b>{{LocationEmail}}</b></label>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 ">
                                <div class="form-group">
                                    <label>Street</label>
                                    <label><b>{{LocationAddress1}}</b></label>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>City</label>
                                    <label><b>{{LocationCity}}</b></label>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>State</label>
                                    <label><b>{{LocationState}}</b></label>

                                </div>
                            </div>
                        </div>
                        <!--/row-->

                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Post Code</label>
                                    <label><b>{{LocationZip}}</b></label>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Country</label>
                                    <label><b>{{LocationCountry}}</b></label>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Active</label>
                                    <input type="checkbox" ng-model="Active" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Company Id: </label>
                                    <label><b>{{CompanyId}}</b></label>

                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="button" class="btn btn-success" ng-click="AddEmployee()"><i class="fa fa-users"></i>Add Employee</button>
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
    <script src="custom/viewlocation.js"></script>
</asp:Content>
