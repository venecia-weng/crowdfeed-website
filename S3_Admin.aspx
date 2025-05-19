<%@ Page Title="" Language="C#" MasterPageFile="~/Site3_Admin.Master" AutoEventWireup="true" CodeBehind="S3_Admin.aspx.cs" Inherits="badpj_integration_trial4.S3_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <p class="pageheader-text">Lorem ipsum dolor sit ametllam fermentum ipsum eu porta consectetur
                            adipiscing elit.Nullam vehicula nulla ut egestas rhoncus.</p>
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
            <div class="row">
                <!-- metric -->
                <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="text-muted">Accounts</h5>
                            <div class="metric-value d-inline-block">
                                <h1 class="mb-1 text-primary">32,100 </h1>
                            </div>
                            <div class="metric-label d-inline-block float-right text-success">
                                <i class="fa fa-fw fa-caret-up"></i><span>5.27%</span>
                            </div>
                        </div>
                        <div id="sparkline-1"></div>
                    </div>
                </div>
                <!-- /. metric -->
                <!-- metric -->
                <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="text-muted">Mall Managers</h5>
                            <div class="metric-value d-inline-block">
                                <h1 class="mb-1 text-primary">4,200 </h1>
                            </div>
                            <div class="metric-label d-inline-block float-right text-danger">
                                <i class="fa fa-fw fa-caret-down"></i><span>1.08%</span>
                            </div>
                        </div>
                        <div id="sparkline-2"></div>
                    </div>
                </div>
                <!-- /. metric -->
                <!-- metric -->
                <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="text-muted">Malls</h5>
                            <div class="metric-value d-inline-block">
                                <h1 class="mb-1 text-primary">$5,656</h1>
                            </div>
                            <div class="metric-label d-inline-block float-right text-danger">
                                <i class="fa fa-fw fa-caret-down"></i><span>7.00%</span>
                            </div>
                        </div>
                        <div id="sparkline-3">
                        </div>
                    </div>
                </div>
                <!-- /. metric -->
                <!-- metric -->
                <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <h5 class="text-muted">Fault Reports</h5>
                            <div class="metric-value d-inline-block">
                                <h1 class="mb-1 text-primary">+28.45% </h1>
                            </div>
                            <div class="metric-label d-inline-block float-right text-success">
                                <i class="fa fa-fw fa-caret-up"></i><span>4.87%</span>
                            </div>
                        </div>
                        <div id="sparkline-4"></div>
                    </div>
                </div>
                <!-- /. metric -->
            </div>
            <!-- ============================================================== -->


            <div class="row">
                <!-- ============================================================== -->
                <!-- top selling products  -->
                <!-- ============================================================== -->
                <div class="col">
                    <div class="card">
                        <h5 class="card-header">Transactions</h5>
                        <div class="card-body p-0">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="bg-light">
                                    <tr class="border-0">
                                        <th class="border-0">#</th>
                                        <th class="border-0">Transaction ID</th>
                                        <th class="border-0">Mall Name</th>
                                        <th class="border-0">Product Id</th>
                                        <th class="border-0">Quantity</th>
                                        <th class="border-0">Price</th>
                                        <th class="border-0">Order Time</th>
                                        <th class="border-0">Customer</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                    <tr>
                                        <td>1</td>
                                        <td>
                                            <div class="m-r-10"><img src="assets/images/product-pic.jpg" alt="user"
                                                                     class="rounded" width="45"></div>
                                        </td>
                                        <td>Product #1</td>
                                        <td>id000001</td>
                                        <td>20</td>
                                        <td>$80.00</td>
                                        <td>27-08-2018 01:22:12</td>
                                        <td>Patricia J. King</td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>
                                            <div class="m-r-10"><img src="assets/images/product-pic-2.jpg" alt="user"
                                                                     class="rounded" width="45"></div>
                                        </td>
                                        <td>Product #2</td>
                                        <td>id000002</td>
                                        <td>12</td>
                                        <td>$180.00</td>
                                        <td>25-08-2018 21:12:56</td>
                                        <td>Rachel J. Wicker</td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td>
                                            <div class="m-r-10"><img src="assets/images/product-pic-3.jpg" alt="user"
                                                                     class="rounded" width="45"></div>
                                        </td>
                                        <td>Product #3</td>
                                        <td>id000003</td>
                                        <td>23</td>
                                        <td>$820.00</td>
                                        <td>24-08-2018 14:12:77</td>
                                        <td>Michael K. Ledford</td>
                                    </tr>
                                    <tr>
                                        <td>4</td>
                                        <td>
                                            <div class="m-r-10"><img src="assets/images/product-pic-4.jpg" alt="user"
                                                                     class="rounded" width="45"></div>
                                        </td>
                                        <td>Product #4</td>
                                        <td>id000004</td>
                                        <td>34</td>
                                        <td>$340.00</td>
                                        <td>23-08-2018 09:12:35</td>
                                        <td>Michael K. Ledford</td>
                                    </tr>
                                    <tr>
                                        <td colspan="8"><a href="#" class="btn btn-outline-light float-right">View
                                            Details</a></td>
                                    </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- ============================================================== -->
                <!-- end top selling products  -->
                <!-- ============================================================== -->
                </div>
            </div>
        </div>
</asp:Content>
