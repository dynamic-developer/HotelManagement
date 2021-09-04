<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="ViewCompany.aspx.cs" Inherits="Workbyclock.ViewCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
     <!-- row -->
    <div class="row"  ng-app="viewcompanyApp" ng-controller="viewcompanyCtrl">
        <div class="col-md-12">
            <div class="panel panel-defaut">
                <div class="panel-heading">
                    <h3 class="panel-title">{{CompanyName}}</h3>
                </div>
                <div class="panel-body">
                    <form action="#">
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Name: </label>
                                        <label class="control-label"><b>{{CompanyName}} </b></label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Description: </label>
                                        <label class="control-label"><b>{{CompanyDescription}} </b></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Phone: </label>
                                    <label class="control-label"><b>{{CompanyPhone}}</b></label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Email: </label>
                                   <label class="control-label"><b>{{CompanyEmail}}</b></label>
                                </div>
                            </div>
                        </div>
                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Available Locations: </label>
                                     <label class="control-label"><b>{{CompanyNumberOfLocation}}</b></label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Locations Added: </label>
                                     <label class="control-label"><b>3</b></label>
                                </div>
                            </div>
                        </div>
                        <!--/row-->
                         <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Available Employee: </label>
                                     <label class="control-label"><b>{{CompanyNumberOfUsers}}</b></label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Employees Added: </label>
                                     <label class="control-label"><b>10</b></label>
                                </div>
                            </div>
                        </div>
                        <!--/row-->
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group ">
                                    <label class="control-label">Website: </label>
                                     <label class="control-label"><b>{{CompanyWebsite}}</b></label>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-12 ">
                                <div class="form-group">
                                    <label>Street: </label>
                                     <label class="control-label"><b>{{CompanyAddress1}}</b></label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>City: </label>
                                     <label class="control-label"><b>{{CompanyCity}}</b></label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>State: </label>
                                     <label class="control-label"><b>{{CompanyState}}</b></label>
                                </div>
                            </div>
                        </div>
                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Post Code: </label>
                                     <label class="control-label"><b>{{CompanyZip}}</b></label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Country: </label>
                                     <label class="control-label"><b>{{CompanyCountry}}</b></label>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <button type="button" class="btn btn-success" onclick=" window.open('/Location.aspx','_self')"><i class="icon-li-globe-1" ></i>Add Location</button>
                            <button type="button" class="btn btn-success" onclick=" window.open('/User.aspx','_self')"><i class="fa fa-user"  ></i>Add User</button>
                            
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
    <script src="custom/viewcompany.js" ></script>
</asp:Content>
