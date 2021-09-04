<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="Workbyclock.Companies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <div class="row" ng-app="companiesApp" ng-controller="companiesCtrl">
        <div class="col-md-12">
            <div class="panel panel-default panel-with-options">
                <div class="panel-heading">
                    <h3 class="panel-title">All Companies</h3>
                    <div class="row">
                        <div class="col-lg-12" style="text-align: right;">
                            <button type="button" class="btn btn-success" onclick=" window.open('/Company.aspx','_blank')"><i class="fa fa-folder-open-o"></i>Add Company</button>

                        </div>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered datatable">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Company Name</th>
                                    <th>Description</th>
                                    <th>Phone</th>
                                    <th>Email</th>
                                    <th>Address</th>
                                    <th>Locations</th>
                                    <th>Employees</th>
                                    <th>Active</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tfoot>
                               
                            </tfoot>
                            <tbody id="tbdCompanies">
                                 <tr ng-repeat="x in CompaniesList" ng-model="CompaniesList">
                                    <td style="vertical-align:middle;"><b>{{x.CompanyId}}</b></td>
                                    <td style="vertical-align:middle;">{{x.CompanyName}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyDescription}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyPhone}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyEmail}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyFullAddress}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyNumberOfLocation}}</td>
                                    <td style="vertical-align:middle;">{{x.CompanyNumberOfUsers}}</td>
                                    <td style="vertical-align:middle;"><input type="checkbox" ng-checked="{{x.Active}}"/></td>
                                     <td style="vertical-align:middle;text-align:center"><button type="button" class="btn btn-primary"  ng-click="ViewCompany(x.CompanyId)">View</button>
                                     <a href="Company.aspx?id={{x.CompanyId}}"  class="btn btn-success"  > Edit</a></td>
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
    
    <script src="custom/companies.js"></script>
</asp:Content>
