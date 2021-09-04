<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="Workbyclock.Locations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="locationsApp" ng-controller="locationsCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Locations</h3>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;"  runat="server" id="btnAddLocation">
                            <button type="button" class="btn btn-success" onclick=" window.open('/Location.aspx','_self')"><i class="fa fa-folder-open-o"></i>Add Location</button>
                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Location Name</th>
                                    <th>Description</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                     <% if (IsSystemAdmin)

                                            {%>
                                    <th>Company Name</th>
                                    <th>Company ID</th>
                                     <% } %>
                                    <th>Active</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tfoot>
                               
                            </tfoot>
                            <tbody id="tbdLocations">
                                <tr ng-repeat="x in LocationsList" ng-model="LocationsList" style="vertical-align:middle;">
                                    <td style="vertical-align:middle;"><b>{{x.LocationId}}</b></td>
                                    <td style="vertical-align:middle;" >{{x.LocationName}}</td>
                                    <td style="vertical-align:middle;">{{x.LocationDescription}}</td>
                                    <td style="vertical-align:middle;">{{x.LocationPhone}}</td>
                                    <td  style="vertical-align:middle;">{{x.LocationEmail}}</td>
                                    <td style="vertical-align:middle;">{{x.LocationFullAddress}}</td>
                                     <% if (IsSystemAdmin)

                                            {%>
                                    <td style="vertical-align:middle;">{{x.CompanyName}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyId}}</td>
                                     <% } %>
                                    <td style="vertical-align:middle;"><input type="checkbox" ng-checked="{{x.Active}}"/></td>
                                    <td style="vertical-align:middle;text-align:center">
                                        <a href="ViewLocation.aspx?id={{x.LocationId}}" class="btn btn-primary">View</a>
                                        
                                        <% if (IsAllowedRole)

                                            {%>
                                            <a href="Location.aspx?id={{x.LocationId}}" class="btn btn-success">Edit</a>
                                        <% } %>
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
    <script src="custom/locations.js"></script>
</asp:Content>
