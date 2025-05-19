<%@ Page Title="" Language="C#" MasterPageFile="~/Site4_Empty.Master" AutoEventWireup="true" CodeBehind="S4_V_ManagerLogin.aspx.cs" Inherits="badpj_integration_trial4.S4_V_ManagerLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="/Css/S4_V_ManagerLogReg.css" rel="stylesheet" />
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <div class="form_wrapper">
        <div class="form_container">
            <div class="title_container">
                <h2>CrowdFeed Partners Login</h2>
            </div>
            <div class="row clearfix">
                <div class="">
                    <form>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-envelope"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_ManagerID" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_Password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>

                        <asp:Button class="btn btn-success btn-block btn-lg" ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click1" />
                        <asp:Button class="btn btn-info btn-block btn-lg" ID="btn_SignUp" runat="server" Text="Sign Up" OnClick="btn_SignUp_Click" style="background-color: dark-blue;"/>

                    </form>
                </div>
            </div>
            <asp:LinkButton class="nav-link" ID="Lbtn_ResetPw" runat="server" OnClick="Lbtn_ResetPw_Click">Forgot Password?</asp:LinkButton>

        </div>
    </div>
    <p class="credit">Developed by CrowdFeed</p>

</asp:Content>
