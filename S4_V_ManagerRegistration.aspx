<%@ Page Title="" Language="C#" MasterPageFile="~/Site4_Empty.Master" AutoEventWireup="true" CodeBehind="S4_V_ManagerRegistration.aspx.cs" Inherits="badpj_integration_trial4.S4_V_ManagerRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
         .validation-error {
            color: red;
        }
    </style>
    <link href="/Css/S4_V_ManagerLogReg.css" rel="stylesheet" />
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <div class="form_wrapper">
        <div class="form_container">
            <div class="title_container">
                <h2> CrowdFeed Registration Form</h2>
            </div>
            <div class="row clearfix">
                <div class="">
                    <form>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-envelope"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_ManagerID" runat="server" placeholder="Email"></asp:TextBox>
                            <br />                   
                        </div>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-user"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_Name" runat="server" placeholder="Name"></asp:TextBox>
                            <br />
                           
                        </div>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-building"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_MallName" runat="server" placeholder="Mall Name"></asp:TextBox>
                            <br />
                            
                        </div>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_Password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <br />
                           
                             </div>
                        <div class="input_field">
                            <span><i aria-hidden="true" class="fa fa-lock"></i></span>
                            <asp:TextBox CssClass="form-control" ID="tb_ConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                            <br />
                        
                        </div>
                        <asp:Button class="btn btn-info btn-block btn-lg" ID="btn_SignUp" runat="server" Text="Sign Up" OnClick="btn_SignUp_Click" />
                    </form>
                     <asp:RequiredFieldValidator ID="rfv_managerID" runat="server" ErrorMessage="Please enter your email." ControlToValidate="tb_ManagerID" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:RequiredFieldValidator>            
                        <asp:RegularExpressionValidator ID="rev_managerID" runat="server" ControlToValidate="tb_ManagerID"
                        ErrorMessage="Invalid email address." SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="Dynamic" CssClass="validation-error">
                        </asp:RegularExpressionValidator>
                    <br />
                     <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Please enter your name." ControlToValidate="tb_Name" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:RequiredFieldValidator>
                        <br />
                    <asp:RequiredFieldValidator ID="rfv_mallName" runat="server" ErrorMessage="Please enter a mall name." ControlToValidate="tb_MallName" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:RequiredFieldValidator>
                       <br />
                    <asp:RequiredFieldValidator ID="rfv_pw" runat="server" ErrorMessage="Please enter a password." ControlToValidate="tb_Password" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev_pw" runat="server" ErrorMessage="Password must include 8-15 characters, 1 uppercase, 1 lowercase, 1 number, 1 symbol" ControlToValidate="tb_Password" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:RegularExpressionValidator>
                         <br />
                    <asp:RequiredFieldValidator ID="rfv_CPw" runat="server" ErrorMessage="Please enter password again." ControlToValidate="tb_ConfirmPassword" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cv_ConfirmPw" runat="server" ErrorMessage="Please ensure both passwords are the same" ControlToCompare="tb_Password" ControlToValidate="tb_ConfirmPassword" Display="Dynamic" SetFocusOnError="True" CssClass="validation-error"></asp:CompareValidator>
                       
                </div>
            </div>
        </div>
    </div>
    <p class="credit">Developed by CrowdFeed</p>

</asp:Content>