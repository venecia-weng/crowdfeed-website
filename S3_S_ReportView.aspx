<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_S_ReportView.aspx.cs" Inherits="badpj_integration_trial4.S3_S_ReportView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 768px) {
            .col-md-7 {
                max-width: 100%;
            }
        }

        .scrollable {
            overflow-y: scroll;
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
                <div class="card scrollable">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Report List</h4>

                                </center>
                                <link href="/Css/S2_ReportView.css" rel="stylesheet" />
                                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Visible="false"></asp:Button>

                                <div class="searchbox">
                                    <asp:Label ID="lblSearch" runat="server" Text="Search: "></asp:Label>
                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                    <asp:DropDownList ID="ddlSearchField" runat="server">
                                        <asp:ListItem Value="Mall_Name">Mall Name</asp:ListItem>
                                        <asp:ListItem Value="Outlet_Name">Outlet Name</asp:ListItem>
                                        <asp:ListItem Value="Business_Email">Business Email</asp:ListItem>
                                        <asp:ListItem Value="Partner_Name">Partner Name</asp:ListItem>
                                        <asp:ListItem Value="Report_Fault">Report Fault</asp:ListItem>
                                        <asp:ListItem Value="Report_Issue">Report Issue</asp:ListItem>
                                        <asp:ListItem Value="CheckUp_Date">Check Up Date</asp:ListItem>
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

                                <asp:GridView class="table table-striped table-bordered" ID="gvReport" runat="server" AutoGenerateColumns="False" DataKeyNames="Report_Id_AutoIncrement" OnRowDeleting="gvReport_RowDeleting" OnRowCancelingEdit="gvReport_RowCancelingEdit" OnRowEditing="gvReport_RowEditing" OnRowUpdating="gvReport_RowUpdating">
                                    <Columns>
                                        <asp:BoundField DataField="Report_Id_AutoIncrement" HeaderText="Report Ref" />
                                        <asp:BoundField DataField="Mall_Name" HeaderText="Mall Name" />
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
