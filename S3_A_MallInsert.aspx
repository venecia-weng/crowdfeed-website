<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_A_MallInsert.aspx.cs" Inherits="badpj_integration_trial4.S3_A_MallInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 203px;
        }
        .validation-error {
            color: red;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">MALL REGISTRATION</h2>
    <div class="container">
        <form>
            <div class="form-group">
                <label for="tb_MallID">Mall ID</label>
                <asp:TextBox ID="tb_MallID" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                </div>
            <div class="form-group">
                <label for="ddl_MallName">Mall Name</label>
                <asp:DropDownList ID="ddl_MallName" runat="server" DataSourceID="SqlDataSource1" DataTextField="Mall_Name" DataValueField="Mall_Name" class="form-control"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CrowdFeedDTB %>" SelectCommand="SELECT [Mall_Name] FROM [Managers]"></asp:SqlDataSource>
                  </div>
            <div class="form-group">
                <label for="tb_MallLocation">Mall Location</label>
                <asp:TextBox ID="tb_MallLocation" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_MallName" runat="server" ErrorMessage="Please enter a mall location" Display="Dynamic" ControlToValidate="tb_MallLocation" CssClass="validation-error"></asp:RequiredFieldValidator>
              
            </div>
            <div class="form-group">
                <label for="fl_MallImage">Mall Image</label>
                <asp:FileUpload ID="fl_MallImage" runat="server" class="form-control-file" /><asp:Label ID="lbl_Result" runat="server" Text=""></asp:Label>
            <asp:RequiredFieldValidator ID="rfv_MallImage" runat="server" ErrorMessage="Please add an image" ControlToValidate="fl_MallImage" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
              
            </div>
            <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="btn_Insert_Click" class="btn btn-primary" />
        </form>
    </div>
</asp:Content>

