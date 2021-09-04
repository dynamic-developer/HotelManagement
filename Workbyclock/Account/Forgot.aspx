<%@ Page Title="Forgot password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.cs" Inherits="Workbyclock.Account.ForgotPassword" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="preloader"></div>
   
     <section class="signin-wrapper min-vh-100 clearfix" style="background-image: url(/images/signup.jpg);"">
    <div  class="form-block min-vh-100" style="background-image: url(/images/signup_3.jpg);text-align:center;">
        <div style="background-color:white;padding:30px 20px 20px 20px;">
            <asp:PlaceHolder id="loginForm" runat="server">
                <div class="form-horizontal">
                    <h4>Forgot your password?</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12">
                            <asp:Button runat="server" OnClick="Forgot" Text="Email Link"  CssClass="thm-btn submit" BackColor="red" ForeColor="White"/>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <p class="text-info">
                    Please check your email to reset your password.
                </p>
            </asp:PlaceHolder>
        </div>
    </div>
</section>
  
</asp:Content>
