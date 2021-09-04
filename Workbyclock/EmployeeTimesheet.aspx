<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="EmployeeTimesheet.aspx.cs" Inherits="Workbyclock.custom.EmployeeTimesheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="EmployeeTimesheetApp" ng-controller="EmployeeTimesheetCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title" style="padding: 10px 10px 10px 10px;">{{PageTitle}}</h3>
                    <div class="row" style="padding: 10px 10px 10px 10px; border: double; border-width: 3px; vertical-align: middle;">
                        <div class="col-lg-9" style="text-align: left;" runat="server" id="Div1">
                            <div class="row">
                                <div class="col-lg-3">
                                    <label><b>From Date</b></label>
                                   
                                    <input type="datetime-local" class="form-control"
                                        ng-model="ReportStartDate"
                                        id="dtStart"
                                        placeholder="01/01/1979"  required />
                                    
                                </div>
                                <div class="col-lg-3">
                                    <label><b>To Date</b></label>
                                    <input type="datetime-local" class="form-control"
                                        ng-model="ReportEndDate"
                                        id="dtEnd"
                                        placeholder="01/01/1979" required />
                                  
                                </div>
                                <div class="col-lg-3" style="vertical-align: middle;padding-top:10px;">
                                    
                                    <button class="btn btn-primary" ng-click="GetReportEmployeeTimesheet()" type="button">Get Report</button>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3" style="text-align: right;" runat="server" id="btnAddTimesheet">
                             <button type="button" class="btn btn-primary" ng-click="EmailTimesheet()"><i class="fa fa-folder-open-o"></i>Email Timesheet</button>
                            <button type="button" class="btn btn-success" ng-click="ManageTimesheet()"><i class="fa fa-folder-open-o"></i>Add Timesheet</button>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>Timecard ID</th>
                                    <th>Start Time</th>
                                    <th>Start Device ID</th>
                                    <th>End Time</th>
                                    <th>End Device ID</th>
                                    <th>Hours</th>
                                    <th></th>

                                </tr>
                            </thead>
                            <tfoot>
                               
                            </tfoot>
                            <tbody id="tbdTimesheet">
                                <tr ng-repeat="x in EmployeeTimesheet" ng-model="EmployeeTimesheet" style="vertical-align: middle;">
                                    <td style="vertical-align: middle;"><b>{{x.EmployeeTimeCardId}}</b></td>
                                    <td style="vertical-align: middle;">{{x.TimeInSt}}</td>
                                    <td style="vertical-align: middle;">{{x.DeviceId}}</td>
                                    <td style="vertical-align: middle;">{{x.TimeOutSt}}</td>
                                    <td style="vertical-align: middle;">{{x.DeviceIdOut}}</td>
                                    <td style="vertical-align: middle;">{{x.Hours}}</td>
                                    
                                    <td style="vertical-align: middle; text-align: center">
                                        <a href="ManageTimesheet.aspx?id={{x.EmployeeId}}&en={{EmployeeName}}&tid={{x.EmployeeTimeCardId}}&sd={{ReportStartDate}}&ed={{ReportEndDate}}" class="btn btn-primary">Manage</a>
                                        

                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- #row -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
    <script src="custom/employeetimesheet.js"></script>
</asp:Content>


