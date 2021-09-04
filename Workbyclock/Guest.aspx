<%@ Page Title="" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Guest.aspx.cs" Inherits="Workbyclock.Guest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DashboardMainContent" runat="server">
    <!-- row -->
    <div class="row" ng-app="GuestApp" ng-controller="GuestCtrl">
        <div class="col-md-12">
            <div class="panel panel-defaut">
                <div class="panel-heading">
                    <h3 class="panel-title">{{PageTitle}}</h3>
                </div>
                <div class="panel-body">
                    <form action="#" name="CreateForm"   novalidate>
                        <div class="form-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="control-label">Guest Full Name</label>
                                        <input type="text" class="form-control" name="GuestFullName" placeholder="John Smith" ng-model="GuestFullName" required />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group ">
                                        <label class="control-label">Guest Phone</label>
                                        <input type="text" class="form-control" name="GuestPhone" ng-model="GuestPhone" placeholder="123-456-7890" required />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Guest Email</label>
                                    <input type="text" class="form-control" name="GuestEmail" ng-model="GuestEmail" placeholder="xx@gmai.com" />
                                </div>
                            </div>
                            <%--<div class="col-md-6">
                                <div class="form-group ">
                                    <label class="control-label">Company Name</label>
                                    <select class="form-control" name="CompanyId" ng-model="CompanyId" required>
                                        <option ng-value="0" selected="selected">-- Select Company --</option>
                                        <option ng-repeat="option in CompaniesList" ng-value="{{option.CompanyId}}">{{option.CompanyName}}</option>
                                    </select>
                                </div>
                            </div>--%>
                             <div class="col-md-6 ">
                                <div class="form-group">
                                    <label>Guest Address</label>
                                    <textarea name="GuestAddress" ng-model="GuestAddress" class="form-control">Enter Guest Address</textarea>

                                </div>
                            </div>

                        </div>
                        <div class="row">
                           
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Guest Driver License Id</label>
                                    <input type="text" class="form-control" name="GuestDriverLicenseId" required ng-model="GuestDriverLicenseId" />
                                </div>
                            </div>
                            <br />
                            <div class="col-md-6">
                                <div class="form-group checkbox-inline">
                                    <label>Is DNR</label>
                                    <input type="checkbox" ng-model="IsDNR" />
                                </div>
                            </div>

                        </div>
                        <div class="form-actions">
                            <button type="submit" ng-click="SaveGuest()" class="btn btn-success"><i class="fa fa-check"></i>Save</button>
                            <button type="button" class="btn btn-danger"  ng-click="GoBack()">Cancel</button>
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
    <script src="custom/guest.js"></script>
</asp:Content>
