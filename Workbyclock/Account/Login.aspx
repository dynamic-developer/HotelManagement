<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workbyclock.Account.Login" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4></h4>
                    <hr />
                    <br />
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label" ForeColor="Red">Email</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="The email field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" ForeColor="Red">Password</asp:Label>
                            <div class="col-md-6">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" Visible="false" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe" Visible="false">Remember me?</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-3 col-md-10">
                                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="thm-btn submit" />
                            </div>
                        </div>
                    </div>
                    <p>
                        <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled" ForeColor="Red">Forgot your password?</asp:HyperLink>
                    </p>
                </section>
            </div>

            <%--<div class="col-md-4">
                <section id="socialLoginForm">
                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
                </section>
            </div>--%>
        </div>
</asp:Content>

