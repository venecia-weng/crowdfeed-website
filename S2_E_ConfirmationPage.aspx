<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S2_E_ConfirmationPage.aspx.cs" Inherits="badpj_integration_trial4.S2_E_ConfirmationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img {
            display: block;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <tbody>
            <img src="assets/images/checked.png" width="100" height="100">
            <h1>Payment Completed</h1>
            <p>Your transaction has been completed successfully. We'll be contacting you shortly for further discussion. Thank you for trusting CrowdFeed.</p>
            <h2>Transaction Details:</h2>
            <table style="margin: 0 auto;">
                <tr>
                    <td>Transaction ID:</td>
                    <td>
                        <asp:Label ID="lbl_TransactionID" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </tbody>
    </div>
</asp:Content>
