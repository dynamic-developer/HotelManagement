<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Workbyclock.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="EmployeesApp" ng-controller="EmployeesCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Employees</h3>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;">
                            <%--<button type="button" class="btn btn-success" onclick=" window.open('/Location.aspx','_blank')"><i class="fa fa-folder-open-o"></i>Add Location</button>--%>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Employee Name</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                    <th>Rate</th>
                                    
                                    <th>Active</th>
                                    <th>Location ID</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tfoot>
                               
                            </tfoot>
                            <tbody id="tbdEmployees">
                                <tr ng-repeat="x in EmployeesList" ng-model="EmployeesList" style="vertical-align:middle;">
                                    <td style="vertical-align:middle;"><b>{{x.EmployeeId}}</b></td>
                                    <td style="vertical-align:middle;" >{{x.EmployeeName}}</td>
                                    <td style="vertical-align:middle;">{{x.EmployeePhone}}</td>
                                    <td style="vertical-align:middle;">{{x.EmployeeEmail}}</td>
                                    <td style="vertical-align:middle;">{{x.EmployeeFullAddress}}</td>
                                    <td style="vertical-align:middle;">{{x.EmployeeRate}}</td>
                                    
                                    <td style="vertical-align:middle;"><input type="checkbox" ng-checked="{{x.Active}}"/></td>
                                    <td style="vertical-align:middle;">
                                        <a href="ViewLocation.aspx?id={{x.LocationId}}">{{x.LocationId}}</a>

                                    </td>
                                    <td style="vertical-align:middle;text-align:center">
                                        <a href="ViewEmployee.aspx?locationid={{x.LocationId}}&id={{x.EmployeeId}}" class="btn btn-primary">View</a>
                                        <a href="Employee.aspx?locationid={{x.LocationId}}&id={{x.EmployeeId}}" class="btn btn-success">Edit</a>
                                        
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
    <script src="custom/employees.js"></script>
</asp:Content>
