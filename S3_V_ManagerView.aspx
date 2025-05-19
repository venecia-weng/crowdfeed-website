<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_V_ManagerView.aspx.cs" Inherits="badpj_integration_trial4.S3_V_ManagerView" %>

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
                                    <h4>Managers List</h4>
                                </center>
                                <link href="/Css/S2_ReportView.css" rel="stylesheet" />
                                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Visible="false"></asp:Button>

                                <div class="searchbox">
                                    <asp:Label ID="lblSearch" runat="server" Text="Search: "></asp:Label>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                    <asp:DropDownList ID="ddlSearchField" runat="server">
                                        <asp:ListItem Value="Manager_ID">Manager ID</asp:ListItem>
                                        <asp:ListItem Value="Name">Name</asp:ListItem>
                                        <asp:ListItem Value="Mall_Name">Mall Name</asp:ListItem>
                                        <asp:ListItem Value="Password">Password</asp:ListItem>
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
                                <asp:GridView class="table table-striped table-bordered" ID="gvManager" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvManager_SelectedIndexChanged" DataKeyNames="Manager_ID" OnRowDeleting="gvManager_RowDeleting" OnRowCancelingEdit="gvManager_RowCancelingEdit" OnRowEditing="gvManager_RowEditing" OnRowUpdating="gvManager_RowUpdating">
                                    <Columns>
                                        <asp:BoundField DataField="Manager_ID" HeaderText="Manager ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Manager Name" />
                                        <asp:BoundField DataField="Mall_Name" HeaderText="Mall Name" />
                                        <asp:BoundField DataField="Password" HeaderText="Password" />
                                        <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" CancelImageUrl="~/Imgs/icons/icons8-cancel-24.png" DeleteImageUrl="~/Imgs/icons/icons8-trash-16.png" EditImageUrl="~/Imgs/icons/icons8-create-16.png" SelectImageUrl="~/Images/icons/icons8-view-16.png" UpdateImageUrl="~/Images/icons/icons8-checkmark-24.png" ButtonType="Image" HeaderText="Actions" />
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
