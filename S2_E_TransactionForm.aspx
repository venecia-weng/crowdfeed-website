<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S2_E_TransactionForm.aspx.cs" Inherits="badpj_integration_trial4.S2_E_TransactionForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Add bootstrap CDN links here -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <div class="container mt-5">
        <form>
            <div class="form-group">
                <label for="tb_TransactionID">Transaction ID (Please Insert Today's Date as Name_DD/MM/YY)</label>
                <asp:TextBox ID="tb_TransactionID" CssClass="form-control" placeholder="Name_DD/MM/YY" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tb_TransactionManager">Name</label>
                <asp:TextBox CssClass="form-control" ID="tb_TransactionManager" runat="server" placeholder="Name" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tb_BizEmail">Business Email Address</label>
                <asp:TextBox CssClass="form-control" ID="tb_BizEmail" runat="server" placeholder="Business Email Address" ReadOnly="True"></asp:TextBox>
                <asp:Button ID="btn_TransactionOTP" runat="server" Text="Send OTP" OnClick="btn_TransactionOTP_Click1" />
            </div>

            <div class="form-group">
                <label for="tb_Mall">Mall Name</label>
                <asp:TextBox CssClass="form-control" ID="tb_Mall" runat="server" placeholder="Mall Name" ReadOnly="True"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tb_OutletsNo">Number of Outlets in Mall</label>
                <asp:TextBox ID="tb_OutletsNo" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="tb_SensorsNo">Number of Sensors</label>
                <asp:TextBox ID="tb_SensorsNo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btn_Next" CssClass="btn btn-primary btn-block mt-3" runat="server" Text="Next" OnClick="btn_Next_Click" />

        </form>
    </div>
</asp:Content>
