<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Workbyclock.Dashboard" MasterPageFile="~/Authenticated.Master" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="DashboardHeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="DashboardMainContent" runat="server">

    <div id="page-content-wrapper">
        <div class="row cards">
            <div class="col-sm-6 col-md-4 col-lg-3 col-xs-12 animated fadeInLeft">
                <div class="card danger-bg">
                    <div class="card-icon danger-bg">
                        <i class="fa fa-wrench" aria-hidden="true"></i>
                    </div>
                    <div class="display-block card-content">
                        <div>
                            <h4 class="text-center">Locations</h4>
                        </div>
                        <div class="value">
                            <h4 class="odometer text-center" data-precision="0">800</h4>
                        </div>
                        <hr>
                        <h5 class="lastmonth text-center">LastMonth : 50</h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-md-4 col-lg-3 col-xs-12">
                <div class="card primary-bg">
                    <div class="card-icon primary-bg">
                        <i class="fa fa-check" aria-hidden="true"></i>
                    </div>
                    <div class="display-block card-content">
                        <div>
                            <h4 class="text-center clearfix">Employees</h4>
                        </div>
                        <div class="value">
                            <h4 class="odometer text-center" data-precision="0">750</h4>
                        </div>
                        <hr>
                        <h5 class="lastmonth text-center">LastMonth : 20</h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-md-4 col-lg-3 col-xs-12">
                <div class="card warning-bg">
                    <div class="card-icon warning-bg">
                        <i class="fa  fa-exclamation-circle" aria-hidden="true"></i>
                    </div>
                    <div class="display-block card-content">
                        <div>
                            <h4 class="text-center">Users</h4>
                        </div>
                        <div class="value">
                            <h4 class="odometer text-center" data-precision="0">950</h4>
                        </div>
                        <hr>
                        <h5 class="lastmonth text-center">LastMonth : 15</h5>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 col-md-4 col-lg-3 col-xs-12">
                <div class="card success-bg">
                    <div class="card-icon success-bg">
                        <i class="fa fa-file-text-o" aria-hidden="true"></i>
                    </div>
                    <div class="display-block card-content">
                        <div>
                            <h4 class="text-center">Timesheet</h4>
                        </div>
                        <div class="value">
                            <h4 class="odometer text-center" data-precision="0">350</h4>
                        </div>
                        <hr>
                        <h5 class="lastmonth text-center">LastMonth : 10</h5>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- Calendar -->
            <div class="col-md-4 dashboard3date">
                <div class="datepicker">
                    <div class="datepicker-header"></div>
                </div>
            </div>
            <!-- # Calendar -->
            <!-- Line Chart -->
            <div class="col-md-8">
                <div class="linemargin">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Time Reported By Employees
								
                                <ul class="rad-panel-action">
                                    <li><i class="fa fa-chevron-down"></i></li>
                                    <li><i class="fa fa-rotate-right"></i></li>
                                    <li><i class="fa fa-cog"></i></li>
                                    <li><i class="fa fa-close"></i></li>
                                </ul>
                            </h3>
                        </div>
                        <div class="panel-body">
                            <div id="lineChart" class="rad-chart"></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- # Line Chart -->
            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-4 col-xs-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <label>Payroll</label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <h3 class="text-center">2,10,000</h3>
                                <span class="sparkline_one"></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <label>User Activities</label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <h3 class="text-center">110,809</h3>
                                <span class="sparkline_two"></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    <label>Employees</label>
                                </h3>
                            </div>
                            <div class="panel-body">
                                <h3 class="text-center">510,900</h3>
                                <span class="sparkline_one"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12 col-md-8">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Active Employees
							
                            <ul class="rad-panel-action">
                                <li><i class="fa fa-chevron-down"></i></li>
                                <li><i class="fa fa-rotate-right"></i></li>
                                <li><i class="fa fa-cog"></i>
                                    <li><i class="fa fa-close"></i>
                                    </li>
                            </ul>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <div id="areaChart2" class="rad-chart"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-xs-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Activity
								
                            <ul class="rad-panel-action">
                                <li><i class="fa fa-chevron-down"></i></li>
                                <li><i class="fa fa-rotate-right"></i></li>
                                <li><i class="fa fa-close"></i></li>
                                </li>
							
                            </ul>
                        </h3>
                    </div>
                    <div class="panel-body">
                        <div class="rad-activity-body">
                            <div class="rad-list-group group">
                                <div class="rad-list-group-item">
                                    <div class="rad-list-icon  danger-bg pull-left"><i class="fa fa-phone"></i></div>
                                    <div class="rad-list-content">
                                        <strong>Missing Phone Numbers</strong>
                                        <div class="md-text">123</div>
                                    </div>
                                </div>
                                <div class="rad-list-group-item">
                                    <div class="rad-list-icon primary-bg pull-left"><i class="fa fa-refresh"></i></div>
                                    <div class="rad-list-content">
                                        <strong>Missing Timecards</strong>
                                        <div class="md-text">3</div>
                                    </div>
                                </div>

                               <%-- <div class="rad-list-group-item">
                                    <div class="rad-list-icon  success-bg pull-left"><i class="fa fa-envelope"></i></div>
                                    <div class="rad-list-content">
                                        <strong>New Invitation</strong>
                                        <div class="md-text">For New Clients</div>
                                    </div>
                                </div>
                                <div class="rad-list-group-item">
                                    <div class="rad-list-icon warning-bg pull-left"><i class="fa fa-shopping-cart"></i></div>
                                    <div class="rad-list-content">
                                        <strong>Delivery Report</strong>
                                        <div class="md-text">Intimate to Managers</div>
                                    </div>
                                </div>--%>
                                <div class="rad-list-group-item">
                                    <div class="rad-list-icon  info-bg pull-left"><i class="fa fa-pencil"></i></div>
                                    <div class="rad-list-content">
                                        <strong>New Timecards</strong>
                                        <div class="md-text">10</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- # Page-content-wrapper -->
</asp:Content>
