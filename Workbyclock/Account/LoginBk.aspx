<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    EnableEventValidation="true" CodeBehind="LoginBk.aspx.cs" Inherits="Workbyclock.Account.LoginBk" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="preloader"></div>


    <section class="signin-wrapper min-vh-100 clearfix" style="background-image: url(/images/signup.jpg);"">
        <div class="form-block min-vh-100" style="background-image: url(/images/signup_3.jpg);text-align:center;">
            <div style="background-color:white;padding:30px 20px 20px 20px;">
                <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                </asp:PlaceHolder>
                <asp:TextBox runat="server" type="text" name="signin-username" placeholder="Username" TextMode="Email" ID="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The username field is required." />
                <asp:TextBox runat="server" type="password" name="signin-password" placeholder="Password" ID="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                <%-- <a href="#" class="forgot-password">Forgot password?</a>--%>

                <asp:CheckBox runat="server" ID="RememberMe" Visible="false" />
                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="thm-btn submit" BackColor="red" ForeColor="White" />
                <%--<button type="submit" class="thm-btn">Sign In</button>
                <p class="sign-up-link">New to Payonline? <a href="#">Sign up</a></p>--%>
                <p>
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" NavigateUrl="Forgot" CssClass="forgot-password">Forgot password?</asp:HyperLink>
                </p>

            </div>
        </div>
        <!-- /.form-block -->
        <div class="background-block min-vh-100" style="background-image: url(/images/signup.jpg);">
        </div>
        <!-- /.background-block -->
    </section>
    <!-- /.signin-wrapper -->
    <section id="socialLoginForm">
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" Visible="false" />
    </section>

</asp:Content>
