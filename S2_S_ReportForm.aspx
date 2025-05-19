<%@ Page Title="" Language="C#" MasterPageFile="~/Site2_Partner.Master" AutoEventWireup="true" CodeBehind="S2_S_ReportForm.aspx.cs" Inherits="badpj_integration_trial4.S2_S_ReportForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">

    <style>
        .validation-error {
            color: red;
        }
        /* Add a background color to the form container */
        .reportForm {
            background-color: #f2f2f2;
            padding: 20px;
        }

            /* Add a background color to the form header */
            .reportForm h1 {
                color: black;
                padding: 10px;
                text-align: center;
            }

        /* Add some spacing between form items */
        .grid-container {
            display: grid;
            grid-gap: 10px;
            background-color: #fff;
            padding: 10px;
            border: 1px solid #ccc;
            margin-bottom: 10px;
        }

        /* Add some basic styling to the form inputs */
        input[type=text], input[type=email], input[type=date], textarea {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
            background-color: #f8f8f8;
            resize: none;
        }

        /* Add some basic styling to the form button */
        input[type=submit] {
            width: 100%;
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            /* Add hover effect to the form button */
            input[type=submit]:hover {
                background-color: #45a049;
            }

        /* Add basic styling to the form dropdown */
        select {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
            background-color: #f8f8f8;
            resize: none;
        }

        /* Add basic styling to the form checkboxes */
        input[type=checkbox] {
            margin: 8px 0;
        }


        #span-disclaimer {
            color: darkblue;
        }


        .g1 {
            float: left;
            width: 49%;
        }

        .g2 {
            margin-right: 19px;
        }
    </style>
    <div class="reportForm">
        <h1>Report an Issue</h1>
        <br />
        <div class="grid-container">
            <p>
                Report ID:
                    <span class="space">
                        <asp:TextBox ID="tb_ID" runat="server" TextMode="SingleLine" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </span>
            </p>
            <div class="grid-1">
                <div class="g1 g2">
                    <p>
                        MALL NAME: &nbsp;&nbsp;&nbsp; 
                    <span class="space">
                        <asp:TextBox ID="tb_Mall" runat="server" TextMode="SingleLine" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </span>
                        &nbsp;
                    </p>
                </div>
                <div class="g1">
                    OUTLET NAME: <span style="color: red;">*</span>
                    <asp:DropDownList ID="ddl_outlet" runat="server" ReadOnly="true">
                    </asp:DropDownList>

                </div>
            </div>

            <div class="grid-1">
                <div class="g1 g2">
                    <p>
                        EMAIL ADDRESS:
      <span class="space">
          <asp:TextBox ID="tb_Email" runat="server" TextMode="Email" ReadOnly="true" CssClass="form-control"></asp:TextBox>
      </span>
                    </p>
                </div>
                <div class="g1">
                    <p>
                        NAME: &nbsp;&nbsp;&nbsp; 
                    <span class="space">
                        <asp:TextBox ID="tb_Name" runat="server" TextMode="SingleLine" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </span>
                        &nbsp;
                    </p>
                </div>
            </div>

            <div class="grid-1">
                <div class="g1 g2">
                    <p>
                        REPORT FAULT:<span style="color: red;"> *</span>
                        <br />
                        <span>
                            <asp:CheckBoxList ID="cbl_item" runat="server">
                                <asp:ListItem Value="SENSOR"></asp:ListItem>
                                <asp:ListItem Value="TRANSMITTER"></asp:ListItem>
                                <asp:ListItem Value="WIRING"></asp:ListItem>
                                <asp:ListItem Value="CONNECTIVITY"></asp:ListItem>
                            </asp:CheckBoxList>

                        </span>
                    </p>
                </div>
                <div class="g1">
                    <p>
                        PREFERRED CHECK-UP DATE:<span style="color: red;"> *</span>
                        <br />
                        <span id="span-disclaimer">Take Note: No closing of outlet required. Our staff will come down and look at the situation.</span>
                        <br />
                        <asp:TextBox ID="tb_date" runat="server" TextMode="Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="tb_date"
                            ErrorMessage="Date is required." Display="Dynamic" SetFocusOnError="True" CssClass="validation-error">
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="tb_date"
                            ErrorMessage="Date must be today or a future date." Display="Dynamic"
                            OnServerValidate="CustomValidator1_ServerValidate" SetFocusOnError="True" CssClass="validation-error">
                        </asp:CustomValidator>
                    </p>
                </div>
            </div>
            <p>
                WHAT IS THE ISSUE? <span style="color: red;">*</span>
                <br />
                <span>
                    <asp:TextBox ID="tb_comment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="tb_comment"
                        ErrorMessage="Please specify the issue." Display="Dynamic" SetFocusOnError="True" CssClass="validation-error">
                    </asp:RequiredFieldValidator>
                </span>
            </p>


            <asp:Button ID="button2" Text="Submit Report" runat="server" OnClick="button_Click" />
        </div>

    </div>
    <script>
        function validateForm() {
            var checkboxList = document.getElementById("cbl_item");
            var errorMessage = document.getElementById("errorMessage");
            var isChecked = false;

            for (var i = 0; i < checkboxList.length; i++) {
                if (checkboxList[i].checked) {
                    isChecked = true;
                    break;
                }
            }

            if (!isChecked) {
                errorMessage.style.display = "inline";
                return false;
            } else {
                errorMessage.style.display = "none";
                return true;
            }
        }
    </script>
</asp:Content>
