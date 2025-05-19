<%@ Page Title="" Language="C#" MasterPageFile="~/Site4_Empty.Master" AutoEventWireup="true" CodeBehind="S4_V_EnterOTP.aspx.cs" Inherits="badpj_integration_trial4.S4_V_EnterOTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="/Css/S4_V_ManagerLogReg.css" rel="stylesheet" />
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <div class="form_wrapper">
        <div class="form_container">
            <div class="title_container">
                <h2>CrowdFeed One-Time Pin (OTP)</h2>
            </div>
            <div class="row clearfix">
                <div class="">
                    <form>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_OTP" runat="server" placeholder="Copy & paste OTP from your email"></asp:TextBox>
                        </div>

                        <asp:Button class="btn btn-success btn-block btn-lg" ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" />

                    </form>
                </div>
            </div>

        </div>
    </div>
    <p class="credit">Developed by CrowdFeed</p>

</asp:Content>

