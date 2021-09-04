<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Timesheet.aspx.cs" Inherits="Workbyclock.Timesheet" %>

<asp:Content ID="Content2" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="TimesheetApp" ng-controller="TimesheetCtrl" ng-init="SetReportDate()">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title" style="padding: 10px 10px 10px 10px;">All Timesheet</h3>
                    <div class="row" style="padding: 10px 10px 10px 10px; border: double; border-width: 3px; vertical-align: middle;">
                        <div class="col-lg-12" style="text-align: left;" runat="server" id="Div1">
                            <div class="row">
                                <div class="col-lg-2">
                                    <label><b>From Date</b></label>
                                   
                                    <input type="datetime-local" class="form-control"
                                        ng-model="ReportStartDate"
                                        id="dtStart"
                                        placeholder="01/01/1979"  required />
                                    
                                </div>
                                <div class="col-lg-2">
                                    <label><b>To Date</b></label>
                                    <input type="datetime-local" class="form-control"
                                        ng-model="ReportEndDate"
                                        id="dtEnd"
                                        placeholder="01/01/1979" required />
                                  
                                </div>
                                <div class="col-lg-2">
                                    <label><b>Locations</b></label>
                                    <select class="form-control" ng-options="item.LocationName for item in LocationList track by item.LocationId" 
                                            ng-model="LocationId"  id="selLocations"  required> </select>
                                  
                                </div>
                                <div class="col-lg-2">
                                    <label><b>Employees</b></label>
                                   <select  class="form-control" ng-model="EmployeeType" ng-options="x for x in EmployeeTypes"></select>
                                  
                                </div>
                                <div class="col-lg-2" style="vertical-align: middle;padding-top:10px;">
                                    
                                    <button class="btn btn-primary" ng-click="GetAllTimesheet()" type="button">Get Report</button>
                                </div>
                            </div>
                        </div>
                      
                    </div>
                </div>
                <div class="panel-body" >
                    <div class="table-responsive" >
                        <table class="table table-striped table-bordered datatable" >
                            <thead>
                                <tr>
                                    <th>Employee ID</th>
                                    <th>Employee Name</th>
                                    <th>Hours</th>
                                    <th>Earning</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tfoot>
                                
                            </tfoot>
                            <tbody id="tbdTimesheet">
                                <tr ng-repeat="x in TimesheetList" ng-model="TimesheetList" style="vertical-align: middle;">
                                    <td style="vertical-align: middle;"><b><a href="ViewEmployee.aspx?id={{x.EmployeeId}}&locationid={{x.LocationId}}" >{{x.EmployeeId}}</a></b></td>
                                    <td style="vertical-align: middle;">{{x.EmployeeName}}</td>
                                    <td style="vertical-align: middle;">{{x.Hours}}</td>
                                    <td style="vertical-align: middle;">{{x.grossRate}}</td>
                                    <td style="vertical-align: middle; text-align: center">
                                        <a href="EmployeeTimesheet.aspx?id={{x.EmployeeId}}&sd={{ReportStartDate}}&ed={{ReportEndDate}}&en={{x.EmployeeName}}" class="btn btn-primary">View</a>


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
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
 
  
    <script src="custom/timesheet.js"></script>
</asp:Content>
