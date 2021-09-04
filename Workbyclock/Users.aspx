<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Workbyclock.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="UsersApp" ng-controller="UsersCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Users</h3>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;"  runat="server" id="btnAddUser">
                            <button type="button" class="btn btn-success" onclick=" window.open('/User.aspx','_self')"><i class="fa fa-folder-open-o"></i>Add User</button>

                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>User Name</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                    <th>Role</th>
                                    <th>Active</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tfoot>
                                
                            </tfoot>
                            <tbody id="tbdUsers">
                                <tr ng-repeat="x in UsersList" ng-model="UsersList">
                                    <td style="vertical-align: middle;"><b>{{x.Id}}</b></td>
                                    <td style="vertical-align: middle;">{{x.UserFullName}}</td>
                                    <td style="vertical-align: middle;">{{x.UserPhone}}</td>
                                    <td style="vertical-align: middle;">{{x.Email}}</td>
                                    <td style="vertical-align: middle;">{{x.UserFullAddress}}</td>
                                    <td style="vertical-align: middle;">{{x.RoleName}}</td>
                                    <td style="vertical-align: middle;">
                                        <input type="checkbox" ng-checked="{{x.Active}}" /></td>
                                    <td style="vertical-align: middle; text-align: center">
                                        <a href="ViewUser.aspx?id={{x.Id}}" class="btn btn-primary">View</a>
                                        <% if (IsAllowedRole)

                                            {%>
                                            <a href="User.aspx?id={{x.Id}}" class="btn btn-success">Edit</a>
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
    <!-- #row -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">

    <script src="custom/users.js"></script>
</asp:Content>
