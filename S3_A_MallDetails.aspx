<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_A_MallDetails.aspx.cs" Inherits="badpj_integration_trial4.S3_A_MallDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Css/S4_A_MallDetails.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Favicon-->
    <link rel="icon" type="image/x-icon" href="assets/favicon.ico" />
    <!-- Bootstrap icons-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.5.0/font/bootstrap-icons.css" rel="stylesheet" />
    <!-- Core theme CSS (includes Bootstrap)-->
    <body>
        <main class="flex-shrink-0">
            <!-- Header-->
            <header class="bg-dark py-5">
                <div class="container px-5">
                    <div class="row gx-5 align-items-center justify-content-center">
                        <div class="col-lg-8 col-xl-7 col-xxl-6">
                            <div class="my-5 text-center text-xl-start">
                                <p class="lead fw-normal text-white-50 mb-4">
                                    ID: <asp:Label ID="lbl_MallID" runat="server" Text=""></asp:Label>
                                </p>
                                <h1 class="display-5 fw-bolder text-white mb-2">
                                    <asp:Label ID="lbl_MallName" runat="server" Text=""></asp:Label></h1>
                                <div class="d-grid gap-3 d-sm-flex justify-content-sm-center justify-content-xl-start">
                                    <p class="lead fw-normal text-white-50 mb-4">
                                    is located in <asp:Label ID="lbl_MallLocation" runat="server" Text=""></asp:Label>
                                </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-5 col-xxl-6 d-none d-xl-block text-center">
                            <asp:Image ID="img_MallImage" class="img-fluid rounded-3 my-5" Style="width: 600px; height: 400px; object-fit: cover;" runat="server" />
                        </div>
                    </div>
                </div>
            </header>
            <!-- Testimonial section-->
            <div class="py-5 bg-light">
                <div class="container px-5 my-5">
                    <div class="row gx-5 justify-content-center">
                        <div class="col-lg-10 col-xl-7">
                            <div class="text-center">
                                <h1 class="display-5 fw-bolder text-dark mb-2">Outlet Details</h1>
                                <asp:GridView ID="gvOutlet" runat="server" AutoGenerateColumns="False" Width="542px">
                                    <Columns>
                                        <asp:BoundField DataField="Mall_ID" HeaderText="Mall ID" />
                                        <asp:BoundField DataField="Outlet_Name" HeaderText="Outlet Name" />
                                        <asp:BoundField DataField="Outlet_Code" HeaderText="Outlet Code" />
                                        <asp:BoundField DataField="Outlet_SeatNo" HeaderText="Outlet No. of Seats" />
                                        <asp:BoundField DataField="Outlet_Image" HeaderText="Outlet Image" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Bootstrap core JS-->
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
            <!-- Core theme JS-->
            <script src="js/scripts.js"></script>
    </body>

</asp:Content>
