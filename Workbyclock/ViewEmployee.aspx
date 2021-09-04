<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="ViewEmployee.aspx.cs" Inherits="Workbyclock.ViewEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="ViewEmployeeApp" ng-controller="ViewEmployeeCtrl">
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
                                         <label><b>{{EmployeeName}}</b></label>
                                       
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Pin :</label>
                                         <label><b>{{EmployeePin}}</b></label>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">DOB :</label>
                                     <label><b>{{EmployeeBirthDate}}</b></label>
                                   
                                   
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Hire Date :</label>
                                     <label><b>{{EmployeeHireDate}}</b></label>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Is Hourly? :</label>
                                     <input type="checkbox" ng-model="EmployeeIsHourly" ng-checked="{{EmployeeIsHourly}}"/>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Termination Date :</label>
                                     <label><b>{{EmployeeLeftDate}}</b></label>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Last Four SSN :</label>
                                     <label><b>XXXX</b></label>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Hourly Rate :</label>
                                     <label><b>{{EmployeeRate}}</b></label>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Phone :</label>
                                     <label><b>{{EmployeePhone}}</b></label>
                                   
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">

                                    <label class="control-label">Email :</label>
                                     <label><b>{{EmployeeEmail}}</b></label>
                                   
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 ">
                                <div class="form-group">
                                    <label>Street :</label>
                                     <label><b>{{EmployeeAddress1}}</b></label>
                                   
                                </div>
                            </div>

                        </div>
                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>City :</label>
                                     <label><b>{{EmployeeCity}}</b></label>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>State :</label>
                                     <label><b>{{EmployeeState}}</b></label>
                                   
                                </div>
                            </div>
                        </div>
                        <!--/row-->

                        <!--/row-->
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Post Code :</label>
                                     <label><b>{{EmployeeZip}}</b></label>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Country :</label>
                                    <label><b>{{EmployeeCountry}}</b></label>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Active :</label>
                                    <input type="checkbox" ng-model="Active" ng-checked="{{Active}}"/>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Location Id :</label>
                                    <label><b>{{LocationId}}</b></label>

                                </div>
                            </div>
                        </div>
                         <div class="form-actions">
                           <button type="button" class="btn btn-primary"  ng-click="AddTimeCard()" >Add Timecard</button>
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
    <script src="custom/ViewEmployee.js"></script>
</asp:Content>
