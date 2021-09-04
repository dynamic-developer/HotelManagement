<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Authenticated.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Workbyclock.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="DashboardMainContent" runat="server">


    <div class="row">
        <div class="col-md-12">
            <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
                <p class="text-success"><%: SuccessMessage %></p>
            </asp:PlaceHolder>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Change your password</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server"  />
                    </dd>

                    <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" Visible="false" />




                </dl>
            </div>
        </div>
    </div>

</asp:Content>
