<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_E_TransactionView.aspx.cs" Inherits="badpj_integration_trial4.S3_E_TransactionView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 768px) {
            .col-md-7 {
                max-width: 100%;
            }
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- wrapper  -->
    <!-- ============================================================== -->
    <div class="dashboard-wrapper">
        <div class="container-fluid  dashboard-content">
            <!-- ============================================================== -->
            <!-- pagehader  -->
            <!-- ============================================================== -->
            <div class="row">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="page-header">
                        <h3 class="mb-2">Sales Dashboard Template </h3>
                        <p class="pageheader-text">
                            Lorem ipsum dolor sit ametllam fermentum ipsum eu porta consectetur
                            adipiscing elit.Nullam vehicula nulla ut egestas rhoncus.
                        </p>
                        <div class="page-breadcrumb">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="#" class="breadcrumb-link">Dashboard</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Overall Dashboard</li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
            <!-- ============================================================== -->
            <!-- pagehader  -->
            <!-- ============================================================== -->
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Transaction List</h4>
                                </center>
                                <link href="/Css/S2_ReportView.css" rel="stylesheet" />
                                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Visible="false"></asp:Button>

                                <div class="searchbox">
                                    <asp:Label ID="lblSearch" runat="server" Text="Search: "></asp:Label>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                    <asp:DropDownList ID="ddlSearchField" runat="server">
                                        <asp:ListItem Value="Transaction_ID">Transaction ID</asp:ListItem>
                                        <asp:ListItem Value="Transaction_Manager">Manager</asp:ListItem>
                                        <asp:ListItem Value="Transaction_Mall">Mall</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="gvTransaction_Part1" runat="server" AutoGenerateColumns="False" DataKeyNames="Transaction_ID" OnRowCancelingEdit="gvTransaction_Part1_RowCancelingEdit" OnRowDeleting="gvTransaction_Part1_RowDeleting" OnRowEditing="gvTransaction_Part1_RowEditing" OnRowUpdating="gvTransaction_Part1_RowUpdating" OnSelectedIndexChanged="gvTransaction_Part1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Transaction_ID" HeaderText="Transaction Ref" />
                                        <asp:BoundField DataField="Transaction_Manager" HeaderText="Transaction_Manager" />
                                        <asp:BoundField DataField="Transaction_BizEmail" HeaderText="Transaction_BizEmail" />
                                        <asp:BoundField DataField="Transaction_Mall" HeaderText="Transaction_Mall" />
                                        <asp:BoundField DataField="Transaction_OutletsNo" HeaderText="Transaction_OutletsNo" />
                                        <asp:BoundField DataField="Transaction_SensorsNo" HeaderText="Transaction_SensorsNo" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="assets/images/edit.png" CommandName="Edit" Width="20px" Height="20px" ToolTip="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                                <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="assets/images/delete.png" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>

                                <asp:GridView class="table table-striped table-bordered" ID="gvTransaction_Part2" runat="server" DataKeyNames="Transaction_ID" OnRowDeleting="gvTransaction_Part2_RowDeleting" OnSelectedIndexChanged="gvTransaction_Part2_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="assets/images/delete.png" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
