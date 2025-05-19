<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S3_S_ReportDetails.aspx.cs" Inherits="badpj_integration_trial4.S3_S_ReportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 2% 2% 2% 2%;">
        <h2>Report Details</h2>
        <asp:GridView class="table" ID="gvReport" runat="server" AutoGenerateColumns="False" DataKeyNames="Report_Id_AutoIncrement" OnRowDeleting="gvReport_RowDeleting" OnRowCancelingEdit="gvReport_RowCancelingEdit" OnRowEditing="gvReport_RowEditing" OnRowUpdating="gvReport_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Report_Id_AutoIncrement" HeaderText="Report Ref"/>
                <asp:BoundField DataField="Mall_Name" HeaderText="Mall Name"/>
                <asp:BoundField DataField="Outlet_Name" HeaderText="Outlet Name" />
                <asp:BoundField DataField="Business_Email" HeaderText="Business Email" />
                <asp:BoundField DataField="Partner_Name" HeaderText="Partner_Name Email" />
                <asp:BoundField DataField="Report_Fault" HeaderText="Report Fault" />
                <asp:BoundField DataField="Report_Issue" HeaderText="Report Issue" />
                <asp:BoundField DataField="CheckUp_Date" HeaderText="Check Up Date" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CancelImageUrl="~/Imgs/icons/icons8-cancel-24.png" DeleteImageUrl="~/Imgs/icons/icons8-trash-16.png" EditImageUrl="~/Imgs/icons/icons8-create-16.png" UpdateImageUrl="~/Imgs/icons/icons8-checkmark-24.png" ButtonType="Image" HeaderText="Actions" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
