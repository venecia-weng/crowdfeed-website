<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S2_S_ReportRedirect.aspx.cs" Inherits="badpj_integration_trial4.S2_S_ReportRedirect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link href="/Css/S2_S_ReportRedirect.css" rel="stylesheet" />
    <div class="card-container" style="height: 520px;">
        <asp:ScriptManager runat="server" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="display">
                    <div class="row">
                        <asp:Repeater ID="ReportInfoRepeater" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-12" style="margin-bottom: 27px;">
                                    <div class="card">
                                        <div class="card-id">
                                            <p class="header-title">Report ID #</span><%# Eval("Report_Id_AutoIncrement") %></p>
                                        </div>
                                        <hr />
                                        <div class="card-body" style="display: grid; grid-template-columns: auto auto;">
                                            <div class="card-body-split2">
                                                <p class="card-text">
                                                    <span class="text-title">Name:</span><br />
                                                    <span class="text-show"><%# Eval("Partner_Name") %></span>
                                                </p>
                                                <p class="card-text">
                                                    <span class="text-title">Business Email:</span><br />
                                                    <span class="text-show"><%# Eval("Business_Email") %></span>
                                                </p>
                                            </div>
                                            <div class="card-body-split2" style="align-content: center;">
                                                <p class="card-text">
                                                    <span class="text-title">Mall Name:</span><br />
                                                    <span class="text-show"><%# Eval("Mall_Name") %></span>
                                                </p>
                                                <p class="card-text">
                                                    <span class="text-title">Outlet Name:</span><br />
                                                    <span class="text-show"><%# Eval("Outlet_Name") %></span>
                                                </p>
                                            </div>
                                            <div class="card-body-split2" style="align-content: center;">
                                                <div class="split2">
                                                    <p class="card-text">
                                                        <span class="text-title">Check-Up Date:</span><br />
                                                        <span class="text-show"><%# Eval("CheckUp_Date") %></span>
                                                    </p>
                                                    <p class="card-text">
                                                        <span class="text-title">Report Fault:</span><br />
                                                        <span class="text-show"><%# Eval("Report_Fault") %></span>
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="card-body-split2">
                                                <p class="card-text">
                                                    <span class="text-title">Report Issue:</span><br />
                                                    <span class="text-show"><%# Eval("Report_Issue") %></span>


                                                </p>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
