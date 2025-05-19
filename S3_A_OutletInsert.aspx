<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_A_OutletInsert.aspx.cs" Inherits="badpj_integration_trial4.S3_A_OutletInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 1514px;
        }

        .auto-style4 {
            width: 207px;
        }

        .auto-style5 {
            width: 174px;
        }
        .validation-error {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center">OUTLET REGISTRATION</h2>
    <div class="container mt-5">
        <div class="row">
            <div class="col-sm-3">
                <label>Mall Name:</label>
            </div>
            <div class="col-sm-9">
                <asp:DropDownList ID="ddl_MallID" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="Mall_Name" DataValueField="Mall_ID">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CrowdFeedDTB %>" SelectCommand="SELECT [Mall_ID], [Mall_Name] FROM [Malls]"></asp:SqlDataSource>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-sm-3">
                <label>Outlet Name:</label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="tb_OutletName" runat="server" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfv_OutletName" runat="server" ErrorMessage="Please enter an outlet name" ControlToValidate="tb_OutletName" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
          
            </div>
            <div class="col-sm-3">
                <label>Outlet Code:</label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="tb_OutletCode" runat="server" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfv_OutletCode" runat="server" ErrorMessage="Please enter an outlet code" ControlToValidate="tb_OutletCode" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
          
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-sm-3">
                <label>No. of Seats:</label>
            </div>
            <div class="col-sm-3">
                <asp:TextBox ID="tb_OutletSeatNo" runat="server" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfv_OutletSeatNo" runat="server" ErrorMessage="Please enter number of seats" ControlToValidate="tb_OutletSeatNo" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
          
            </div>
            <div class="col-sm-3">
                <label>Outlet Image:</label>
            </div>
            <div class="col-sm-3">
                <asp:FileUpload ID="fl_OutletImage" runat="server" class="form-control" />
                <asp:Label ID="lbl_Result" runat="server" Text="" class="mt-2"></asp:Label>
                 <asp:RequiredFieldValidator ID="rfv_OutletImage" runat="server" ErrorMessage="Please add an outlet image" ControlToValidate="fl_OutletImage" Display="Dynamic" CssClass="validation-error"></asp:RequiredFieldValidator>
          
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-sm-3"></div>
            <div class="col-sm-3">
               
            </div>
        </div>
    </div>
    <asp:Button ID="btn_Insert" runat="server" Text="Insert" class="btn btn-primary mt-3 mx-auto d-block" OnClick="btn_Insert_Click" />
</asp:Content>

