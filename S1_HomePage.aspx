<%@ Page Title="" Language="C#" MasterPageFile="~/Site1_Customer.Master" AutoEventWireup="true" CodeBehind="S1_HomePage.aspx.cs" Inherits="badpj_integration_trial4.S1_HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="/Css/S1_HomePage.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link href="/Css/S1_Logo.css" rel="stylesheet" />
    <link href="/Css/S1_HomeCard.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.5.1/gsap.min.js"></script>

    <div class="newbody">
        <div class="cursor"></div>
        <div class="shapes">
            <div class="shape shape-1"></div>
            <div class="shape shape-2"></div>
            <div class="shape shape-3"></div>
        </div>
    </div>
    <div class="newcontent" style="display: flex;">
        <div class="content">
            <h1 id="welcome2">Welcome To CrowdFeed!
                <span style="font-size: 30px; font-weight: 500">CrowdFeed by ProSensors</span>
            </h1>
        </div>
    </div>

    <!-- sections card -->
    <section class="new-card">
        <div class="legend_search">
            <div id="landing-search" style="margin-top: 2%; margin-bottom: 2%;">
                <input type="text" id="search-input" placeholder="Search Mall/Outlet Name">
                <img src="/Imgs/Nav/search.png" alt="Alternate Text" style="width: 2.5%; margin-right: 5px;" />
            </div>
            <div class="legend">
                <h3 class="legend_title">Legend:</h3>
                <div class="legend_items">
                    <div class="green-dot"></div>
                    <div class="dot-title" style="width: 100%;">
                        60% - 100% seats available
                    </div>
                </div>
                <div class="legend_items">
                    <div class="yellow-dot"></div>
                    <div class="dot-title" style="width: 100%;">
                        40% - 59% seats available

                    </div>
                </div>
                <div class="legend_items">
                    <div class="red-dot"></div>
                    <div class="dot-title" style="width: 100%;">
                        0% - 39% seats available
                    </div>
                </div>
            </div>
        </div>

        <div id="no-results-message" style="display: none; margin: 0px 15% 1% 15%;">No malls or outlets with that name</div>

        <div class="below_search">
            <div class="outlet_header">
                <h3 class="outlet_headerTitle">Our Outlets</h3>
            </div>
            <div class="outlet_fs">
                <div class="outlet-filter">
                    <p>FILTER</p>
                </div>
                <div class="outlet-sort">
                    <p>SORT</p>
                </div>
            </div>
        </div>

        <div class="card-container" style="height: auto;">
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="display">
                        <div class="row">
                            <asp:Repeater ID="MallInfoRepeater" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-3" style="margin-bottom: 27px;">
                                        <div class="card">
                                            <img class="card-img-top" src='<%# "/Imgs/" + Eval("Outlet_Image") %>' alt="Card image cap">
                                            <div class="card-body" style="display: grid; grid-template-columns: auto auto;">
                                                <div class="card-body-split">
                                                    <h5 class="card-text" style="font-weight: bold;"><%# Eval("Outlet_Name") %></h5>
                                                    <div class="card-body-split-2" style="display: grid; grid-template-columns: auto auto;">
                                                        <p class="card-text"><%# Eval("Mall_Name") %></p>
                                                    </div>
                                                    <p class="card-text">#<%# Eval("Outlet_Code") %></p>

                                                </div>
                                                <div class="card-body-split" style="align-content: center;">
                                                    <p class="card-text" style="padding: 50px 0;">
                                                        <span class='random-number' data-outlet-seatno='<%# Eval("Outlet_SeatNo") %>'></span>
                                                        /<%# Eval("Outlet_SeatNo") %>
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
    </section>

    <!-- SCRIPTS -->
    <script>
        function searchOutlet() {
            // Get the input field value
            let input = document.getElementById("search-input").value;
            // Get the Repeater elements
            let mallInfoElements = document.getElementsByClassName("col-sm-3");
            // Get the no results message element
            let noResultsMessage = document.getElementById("no-results-message");
            let hasResults = false;
            // Loop through the Repeater elements
            for (let i = 0; i < mallInfoElements.length; i++) {
                // Get the outlet name element
                let outletName = mallInfoElements[i].getElementsByTagName("h5")[0];
                // Get the mall name element
                let mallName = mallInfoElements[i].getElementsByTagName("p")[0];
                // If the outlet name or mall name does match the search input, show the element
                if (outletName.innerHTML.toUpperCase().indexOf(input.toUpperCase()) > -1 || mallName.innerHTML.toUpperCase().indexOf(input.toUpperCase()) > -1) {
                    mallInfoElements[i].style.display = "";
                    hasResults = true;
                } else {
                    mallInfoElements[i].style.display = "none";
                }
            }
            // If there are no matches, show the no results message
            if (!hasResults) {
                noResultsMessage.style.display = "";
            } else {
                noResultsMessage.style.display = "none";
            }
        }
        // Add event listener to the search input field to trigger the search function
        document.getElementById("search-input").addEventListener("keyup", searchOutlet);
    </script>

    <script>
        function generateRandomNumber() {
            var elements = document.getElementsByClassName("random-number");
            for (var i = 0; i < elements.length; i++) {
                var max = parseInt(elements[i].getAttribute('data-outlet-seatno'));
                var min = 1;
                var randomNumber = Math.floor(Math.random() * (max - min + 1)) + min;
                var percent = (randomNumber / max) * 100;
                elements[i].innerHTML = randomNumber;

                if (percent < 30) {
                    elements[i].style.color = "red";
                } else if (percent >= 31 && percent <= 50) {
                    elements[i].style.color = "orange";
                } else {
                    elements[i].style.color = "green";
                }
            }
        }

        window.onload = function () {
            generateRandomNumber();
            setInterval(generateRandomNumber, 10000);
        }
    </script>

    <script>
        document.body.addEventListener("mousemove", evt => {
            const mouseX = evt.clientX;
            const mouseY = evt.clientY;
            gsap.set(".cursor", {
                x: mouseX,
                y: mouseY
            });
            gsap.to(".shape", {
                x: mouseX,
                y: mouseY,
                stagger: -0.1
            });
        });
    </script>
</asp:Content>
