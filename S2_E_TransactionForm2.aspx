<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S2_E_TransactionForm2.aspx.cs" Inherits="badpj_integration_trial4.S2_E_TransactionForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <%--bootstrap css--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />


    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <style>
        .form-group {
            margin-bottom: 0px;
        }
    </style>
    <form>
        <div class="container">
            <div class="row">
                    <h3>Transaction Details</h3>
                    <table class="table" style="margin-bottom: 50px;">
                        <tr>
                            <td>Transaction ID (Please Insert Today's Date as Name_DD/MM/YY)</td>
                            <td>
                                <asp:Label ID="lbl_TransactionID" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Number of Outlets in Mall (No. of Transmitters x $150)</td>
                            <td>
                                <asp:Label ID="lbl_OutletsNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Number of Sensors (No. of Sensors x $5) </td>
                            <td>
                                <asp:Label ID="lbl_SensorsNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Service Charge</td>
                            <td>$50</td>
                        </tr>
                        <tr>
                            <td>Maintenance Fee</td>
                            <td>$50</td>
                        </tr>
                        <tr>
                            <td>Tax 8%</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Total</td>
                            <td>
                                <asp:Label ID="lbl_Total" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <h3>Payment Details</h3>
                    <table class="table">
                        <tr>
                            <td>Transaction ID (Please Enter according to the previous form)</td>
                            <td>
                                <asp:TextBox ID="tb_TransactionID" runat="server" class="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Card Number </td>
                            <td>
                                <asp:TextBox ID="tb_TransactionCardNo" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Card Expiry Date </td>
                            <td>
                                <asp:TextBox ID="tb_TransactionExpiryDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">Card CVC</td>
                            <td>
                                <asp:TextBox ID="tb_TransactionCVC" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <!-- <asp:Button ID="Button1" runat="server" Text="Show Password" OnClick="ShowPasswordButton_Click" /> -->
                            </td>
                        </tr>
                        <div class="form-group">
                            <tr>
                                <td class="auto-style3">OTP Code</td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="tb_TransactionOTP" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>

                    </table>
                    <asp:Button ID="btn_Confirm" runat="server" Text="Confirm" OnClick="btn_Confirm_Click" CssClass="btn btn-primary" />

                </div>
    </form>

</asp:Content>
