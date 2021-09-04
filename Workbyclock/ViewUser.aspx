<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Workbyclock.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="ViewUserApp" ng-controller="ViewUserCtrl">
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
                                         <label><b>{{UserFullName}}</b></label>
                                      
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Role :</label>
                                         <label><b>{{RoleName}}</b></label>
                                       
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                        
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Email :</label>
                                     <label><b>{{Email}}</b></label>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label>Phone :</label>
                                     <label><b>{{UserPhone}}</b></label>
                                    
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6 ">
                                <div class="form-group">
                                    <label>Street :</label>
                                     <label><b>{{UserAddress1}}</b></label>
                                   
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Active :</label>
                                    <input type="checkbox" ng-model="Active" ng-checked="Active"/>
                                </div>
                            </div>
                        </div>
                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>City :</label>
                                     <label><b>{{UserCity}}</b></label>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>State :</label>
                                     <label><b>{{UserState}}</b></label>
                                 
                                </div>
                            </div>
                        </div>
                        <!--/row-->

                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Post Code :</label>
                                     <label><b>{{UserZip}}</b></label>
                                   
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Country :</label>
                                     <label><b>{{UserCountry}}</b></label>
                                  
                                </div>
                            </div>
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
    <script src="custom/viewuser.js"></script>
</asp:Content>
