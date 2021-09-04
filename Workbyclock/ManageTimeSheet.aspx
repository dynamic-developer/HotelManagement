<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="ManageTimeSheet.aspx.cs" Inherits="Workbyclock.ManageTimeSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="ManageTimesheetApp" ng-controller="ManageTimesheetCtrl">
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
                                        <div class="form-group ">
                                        <label class="control-label">Employee Name</label>
                                        <input type="text" class="form-control" ng-model="EmployeeName" placeholder="John Smith" required />
                                    </div>
                                        
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label><b>Locations</b></label>
                                        <select class="form-control" ng-options="item.LocationName for item in LocationList track by item.LocationId"
                                            ng-model="LocationId" id="selLocations" required>
                                        </select>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label><b>Time In</b></label>

                                    <input type="datetime-local" class="form-control"
                                        ng-model="TimeIn"
                                        id="dtStart"
                                        placeholder="01/01/1979" required />

                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label><b>Time Out</b></label>
                                    <input type="datetime-local" class="form-control"
                                        ng-model="TimeOut"
                                        id="dtEnd"
                                        placeholder="01/01/1979" required />
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-12">
                                <div class="form-group ">
                                    <label><b>Reason</b></label>
                                    <input type="text" maxlength="99" ng-model="Reason" required />
                                    </div>
                                </div>
                             </div>

                        <div class="form-actions">
                            <button type="submit" class="btn btn-success" ng-click="SaveEmployeeTimeSheet()"><i class="fa fa-check"></i>Save</button>
                            <button type="button" class="btn btn-danger" ng-click="DeleteEmployeeTimeSheet()" *ngIf="EmployeeTimeCardId > 0">Delete</button>
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
    <script src="custom/managetimesheet.js"></script>
</asp:Content>


