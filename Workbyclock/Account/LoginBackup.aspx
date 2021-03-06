<%@ Page Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="LoginBackup.aspx.cs" Inherits="Workbyclock.Account.LoginBackup" 
    Async="true" EnableEventValidation="false"  %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <div class="form-block min-vh-100" style="background-image: url(/images/signup_3.jpg);text-align:center;">
        <div class="row" style="padding-top:75px;">
            <div class="col-md-3">
                </div>
            <div class="col-md-3" style="background-color:white;padding:30px 20px 20px 20px;">

                <section id="loginForm">
                    <div class="form-horizontal">
                        
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="The email field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                        </div>
                        <div class="form-group">
                            
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="thm-btn submit"
                                    />
                               
                            </div>
                        </div>
                    </div>
                    <p>
                        <%--  --%>
                    </p>
                    <p>
                        <%-- Enable this once you have account confirmation enabled for password reset functionality --%>
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                       
                    </p>
                </section>
            </div>

            <div class="col-md-6">
                <section id="socialLoginForm">
                    
                </section>
            </div>
        </div>
            </div>
   
</asp:Content>
